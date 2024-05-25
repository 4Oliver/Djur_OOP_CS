using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DjurProgram : MonoBehaviour
{
    void Start()
    {
        Ko kol = new Ko("Rosa", 117, 3);
        print("Kon " + kol.Namn() + " väger " + kol.Vikt() + " ger:" + kol.MjolkVolym() + " liter");

        Lamm lamm1 = new Lamm("Lennart", 37);
        print("Lammet: " + lamm1.Namn() + " har ullmängden " + lamm1.UllMangd());

        Gris gris1 = new Gris(88);
        print("Grisen: " + gris1.Namn() + " har styrkan " + gris1.Styrka());

        List<Djur> djuren = new List<Djur>();
        djuren.Add(new Ko("Korra", 195, 4));
        djuren.Add(new Lamm("Laban", 43));
        djuren.Add(new Gris(107));

        foreach (Djur djur in djuren)
        {
            print("Djuret " + djur.Namn());
        }

        Ko ko2 = new Ko("Rosa", 112, 4);
        print("Kon " + ko2.Namn() + " väger " + ko2.Vikt() + " ger:" + ko2.MjolkVolym() + " liter");

        Djur d2 = new Ko("Mu", 174, 5);
        print("Djuret " + d2.Namn() + " väger " + d2.Vikt() + " ger:" + ((Ko)d2).MjolkVolym() + " liter");

        if (d2 is Ko)
        {
            d2.okaVolym(2);
            print("Djuret som är en ko och heter " + d2.Namn() + " har mjölkvolym " + ((Ko)d2).MjolkVolym() + " liter");
            print("Väger " + d2.Vikt() + " ger:" + d2.Varde());
        }

        print("Värdet på alla djuren är " + summaVarde(djuren) + " kr");


        int summaVarde(List<Djur> djuren2)
        {
            int summa = 0;
            foreach (Djur djur in djuren2)
            {
                summa += djur.Varde();
            }
            return summa;
        }
    }

    abstract class Djur
    {
        private string namn;
        protected int vikt;

        abstract public int Varde();

        public string Namn()
        {
            return namn;
        }

        public int Vikt()
        {
            return vikt;
        }

        public Djur(string na, int v)
        {
            namn = na;
            vikt = v;
        }

        public Djur()
        {
        }

        public void okaVolym(int x)
        {
            vikt += x;
        }
    }

    class Ko : Djur
    {
        private int mjolkvolym;

        public int MjolkVolym()
        {
            return mjolkvolym;
        }

        public Ko(string na, int v, int mjo) : base(na, v)
        {
            mjolkvolym = mjo;
        }

        public new void okaVolym(int x)
        {
            mjolkvolym += x;
        }

        override public int Varde()
        {
            return vikt * mjolkvolym;
        }
    }

    class Lamm : Djur
    {
        private int ullMangd;

        public int UllMangd()
        {
            return ullMangd;
        }

        public Lamm(string na, int ull) : base(na, 40)
        {
            ullMangd = ull;
        }

        public new void okaVolym(int x)
        {

        }

        override public int Varde()
        {
            return ullMangd * ullMangd;
        }
    }

    class Gris : Djur
    {
        private int styrka;

        public int Styrka()
        {
            return styrka;
        }

        public Gris(int sty)
        {
            styrka = sty;
        }

        public void okaStyrka(int x)
        {
            styrka += x;
        }

        override public int Varde()
        {
            return vikt * 3 + styrka;
        }

    }

}