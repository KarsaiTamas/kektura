using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kektura
{
    class Program
    {
        static List<Turaszakasz> egesz_tura = new List<Turaszakasz>();
        static string elso_sor;
        public static void Beolvasas()
        {
            try
            {
                var sr = new StreamReader("kektura.csv");
                elso_sor=sr.ReadLine();
                string sor;

                while (!sr.EndOfStream)
                {
                    sor=sr.ReadLine();
                    string[] adatok = sor.Split(';');
                    egesz_tura.Add(new Turaszakasz(adatok[0],
                        adatok[1],
                        float.Parse(adatok[2]),
                        int.Parse(adatok[3]),
                        int.Parse(adatok[4]),
                        adatok[5]));
                }

                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Hibás fájl"+ e);
            }

        }

        public static void Tura_Kiir()
        {
            foreach (var item in egesz_tura)
            {
                Console.WriteLine(item);
            }
        }
        private static void Feladat3()
        {
            Console.Write("3.feladat: ");
            Console.WriteLine("Szakaszok száma {0} db",egesz_tura.Count);
        }
        
        private static void Feladat4()
        {
            Console.Write("4.feladat: ");
            Console.WriteLine("A túra teljes hossza: {0} km",Tura_Teljes_Hossza());
        }
        private static void Feladat5()
        {
            Console.Write("5. feladat: ");
            Console.WriteLine("A legrövidebb szakasz adatai: {0}", Legrovidebb_szakasz_Adatai());
        }
        private static void Feladat7()
        {
            Console.Write("7. feladat: ");
            Console.WriteLine("Hiányos állomásnevek: ");
            Console.WriteLine(Hianyos_Allomas_Nevek());
        }
        private static void Feladat8()
        {
            Console.Write("8. feladat: ");
            string legmagasabb_pont_neve;
            int legmagasabb_pont=Legmagasabb_Pont(out legmagasabb_pont_neve);
            Console.WriteLine("A végpont neve: {0}", legmagasabb_pont_neve);
            Console.WriteLine("A végpont tengerszint feletti magassága: {0}", legmagasabb_pont);
        }
        public static void Teszt()
        {
            foreach (var item in egesz_tura)
            {
                Console.WriteLine(item.Kiir_File());
            }
        }
        private static void Feladat9()
        {
            try
            {
                var sw = new StreamWriter("kektura2.csv");
                sw.WriteLine(elso_sor);
                foreach (var item in egesz_tura)
                {
                    sw.WriteLine(item.Kiir_File());
                }
                sw.Close();
            }
            catch (IOException e)
            {

                Console.WriteLine("Hiba a kiíráskor"+ e);
            }

        }

        private static int Legmagasabb_Pont(out string vissza)
        {
            int maxi=0;
            int szamlalas=int.Parse(elso_sor);
            int legnagyobb = szamlalas;
            for (int i = 0; i < egesz_tura.Count; i++)
            {
                szamlalas += (egesz_tura[i].Emelkedes_Osszesen - egesz_tura[i].Lejtes_Osszesen);
                if (legnagyobb<szamlalas)
                {
                    maxi = i;
                    legnagyobb = szamlalas;
                }
            }
            vissza = egesz_tura[maxi].Vegpont_Hely;
            return legnagyobb;
        }

        

        private static string Hianyos_Allomas_Nevek()
        {
            string vissza="";
            foreach (var item in egesz_tura)
            {
                if (item.HianyosNev())
                {
                    vissza += item.Vegpont_Hely+"\n";
                }
            }
            return vissza;
        }

        private static string Legrovidebb_szakasz_Adatai()
        {
            var tura= egesz_tura[Legrovidebb()];
            string vissza = String.Format(tura.Kiir_Adatai());

            return vissza;
        }

        private static int Legrovidebb()
        {
            int min=0;
            for (int i = 0; i < egesz_tura.Count; i++)
            {
                if (egesz_tura[min].Hossza>egesz_tura[i].Hossza)
                {
                    min = i;
                }
            }
            return min;
        }

        private static float Tura_Teljes_Hossza()
        {
            float vissza=0;
            foreach (var item in egesz_tura)
            {
                vissza += item.Hossza;
            }
            return vissza;
        }

        static void Main(string[] args)
        {
            Beolvasas();
            //Tura_Kiir();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat7();
            Feladat8();
            Feladat9();
            //Teszt();








            Console.ReadKey();

           
        }

       
    }
}
