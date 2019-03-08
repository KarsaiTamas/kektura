using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kektura
{
    class Turaszakasz
    {
       

        public string Kiindulo_Hely { get; set; }
        public string Vegpont_Hely { get; set; }
        public float Hossza { get; set; }
        public int Emelkedes_Osszesen { get; set; }
        public int Lejtes_Osszesen { get; set; }
        public string Vegpont_Pecsetelo_Hely { get; set; }

        public Turaszakasz(string kiindulo_Hely, string vegpont_Hely, float hossza, int emelkedes_Osszesen, int lejtes_Osszesen, string vegpont_Pecsetelo_Hely)
        {
            Kiindulo_Hely = kiindulo_Hely;
            Vegpont_Hely = vegpont_Hely;
            Hossza = hossza;
            Emelkedes_Osszesen = emelkedes_Osszesen;
            Lejtes_Osszesen = lejtes_Osszesen;
            Vegpont_Pecsetelo_Hely = vegpont_Pecsetelo_Hely;
        }

        public bool HianyosNev()
        {
            return (Vegpont_Pecsetelo_Hely.Equals("i") && !Vegpont_Hely.Contains("pecsetelohely"))?true:false;
        }
        public string Kiir_File()
        {
            string vissza = "";
            if (HianyosNev())
            {
                
                vissza = String.Format(
                    Kiindulo_Hely+";" +
                    Vegpont_Hely+ " pecsetelohely;" +
                    Hossza+";" +
                    Emelkedes_Osszesen+";" +
                    Lejtes_Osszesen+";" +
                    Vegpont_Pecsetelo_Hely
                    );
            }
            else
            {
                vissza = String.Format(
                                  Kiindulo_Hely + ";" +
                                  Vegpont_Hely + ";" +
                                  Hossza + ";" +
                                  Emelkedes_Osszesen + ";" +
                                  Lejtes_Osszesen + ";" +
                                  Vegpont_Pecsetelo_Hely
                                  );
            }
             
            return vissza;
        }
        public string Kiir_Adatai()
        {
            string vissza = String.Format(
                "\n Kezdete: {0} " +
                "\n Vége: {1} " +
                "\n Hossza: {2} km",
                Kiindulo_Hely,
                Vegpont_Hely,
                Hossza);
            return vissza;
        }

        public override string ToString()
        {
            string vissza = String.Format("A túraszakasz " +
                "\n kezdete: {0} " +
                "\n vége: {1} " +
                "\n hossza: {2} km" +
                "\n összes emelkedés: {3} m" +
                "\n összes lejtés: {4} m" +
                "\n pecsételő hely: {5}",
                Kiindulo_Hely,
                Vegpont_Hely,
                Hossza,
                Emelkedes_Osszesen,
                Lejtes_Osszesen,
                Vegpont_Pecsetelo_Hely);
            return vissza;
        }

    }
}
