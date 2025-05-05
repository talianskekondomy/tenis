using System;
/*
 1 gam = 40 bodů - 0, 15, 30, 40, AD (AD = shoda)
1 set ->7 gam
2 sety
*/

class Program
{
    // body, gemy, sety
    static int bodyA = 0;
    static int bodyB = 0;

    static int gemyA = 0;
    static int gemyB = 0;

    static int setyA = 0;
    static int setyB = 0;

    static bool konecZapasu = false;

    static void Main()
    {
        while (true) 
        {
            Console.Clear();

            //"menu"
            Console.WriteLine("Sety: " + setyA + " - " + setyB);
            Console.WriteLine("Gemy: " + gemyA + " - " + gemyB);
            Console.WriteLine("Body: " + Prevod(bodyA) + " - " + Prevod(bodyB));

            if (konecZapasu)
            {
                Console.WriteLine("Zápas skončil.");
                Console.WriteLine("Stiskni Enter pro reset zápasu.");
                Console.ReadLine();
                Reset();
                continue;
            }

            // ovládání
            Console.WriteLine();
            Console.WriteLine("1 = Bod pro Hráče A");
            Console.WriteLine("2 = Bod pro Hráče B");
            Console.WriteLine("r = Reset zápasu");

            //přidávání bodů
            string volba = Console.ReadLine();

            if (volba == "1")
            {
                PridejBodA();
            }
            else if (volba == "2")
            {
                PridejBodB();
            }
            else if (volba == "r")
            {
                Reset();
            }
        }
    }


    //převod
    static string Prevod(int body)
    {
        if (body == 0) return "0";
        if (body == 1) return "15";
        if (body == 2) return "30";
        if (body == 3) return "40";
        return "AD"; 
    }

    //reset
    static void Reset()
    {
        bodyA = 0;
        bodyB = 0;
        gemyA = 0;
        gemyB = 0;
        setyA = 0;
        setyB = 0;
        konecZapasu = false;
    }

    static void PridejBodA()
    {

        if (konecZapasu) return;

        //pokud A B = 40 -> řešení výhody
        if (bodyA >= 3 && bodyB >= 3)
        {
            if (bodyA == bodyB) //shoda -> výhoda A
            {
                bodyA++;
            }
            else if (bodyA > bodyB) // hráč A výhoda -> gam
            {
                gemyA++;
                bodyA = 0;
                bodyB = 0;

                if (gemyA == 7)
                {
                    setyA++;
                    gemyA = 0;
                    gemyB = 0;

                    if (setyA == 2)
                    {
                        Console.Clear();
                        konecZapasu = true;

                    }

                }
            }
            else  //hráč B výhoda -> zpět na shodu
            {
                bodyB = 3;
            }
        }
        else if (bodyA == 3) //pokud má A 40 a B méně, A vyhrává gam
        {
            gemyA++;
            bodyA = 0;
            bodyB = 0;

            if (gemyA == 7)
            {
                setyA++;
                gemyA = 0;
                gemyB = 0;

                if (setyA == 2) //2 sety A
                {
                    Console.Clear();
                    konecZapasu = true;
                }

            }
        }
        else //jinak přičteme bod normálně
        {
            bodyA++;
        }
    }

    static void PridejBodB()
    {

        if (konecZapasu) return;

        if (bodyB >= 3 && bodyA >= 3) 
        {
            if (bodyB == bodyA)  //shoda -> výhoda B
            {
                bodyB++;
            }
            else if (bodyB > bodyA)  //hráč B výhoa -> gam
            {
                gemyB++;
                bodyB = 0;
                bodyA = 0;

                if (gemyB == 7)
                {
                    setyB++;
                    gemyB = 0;
                    gemyA = 0;

                    if (setyB == 2) //2 sety B
                    {
                        Console.Clear();
                        konecZapasu = true;
                    }
                }

            }
            else //hráč A výhoa -> zpět na shodu
            {
                bodyA = 3;
            }
        }
        else if (bodyB == 3) //pokud má B 40 a A méně, B vyhrává gam
        {
            gemyB++;
            bodyB = 0;
            bodyA = 0;

            if (gemyB == 7)
            {
                setyB++;
                gemyB = 0;
                gemyA = 0;

                if (setyB == 2)
                {
                    Console.Clear();
                    konecZapasu = true;
                }
            }
        }
        else //jinak přičteme bod normálně
        {
            bodyB++;
        }
    }
}