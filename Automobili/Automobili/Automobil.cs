using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Automobili
{
    public class Automobil
    {
        public string Naziv { get; set; }
        public int _GodinaProizvodnje;
        public double OsnovnaCijena { get; set; }

        public int GodinaProizvodnje()
        { return _GodinaProizvodnje; }

        public void GodinaProizvodnje(int value)
        {
            _GodinaProizvodnje = value;
        }

        public int StarostAutomobila()
        {
            return DateTime.Now.Year - _GodinaProizvodnje;
        }

        public double UkupnaCijena()
        {
            if (OsnovnaCijena <= 70000)
                return OsnovnaCijena * 1.3;
            else if (OsnovnaCijena > 70000 && OsnovnaCijena < 100000)
                return OsnovnaCijena * 1.4;
            else
                return OsnovnaCijena * 1.5;
        }
        public class GodinaProizvodnjeEventArgs : EventArgs
{
         public int StaraGodinaProizvodnje { get; set; }
         public int NovaGodinaProizvodnje { get; set; }
}

        public event EventHandler<GodinaProizvodnjeEventArgs> NaPromjenuGodineProizvodnje;


        public void GodinaProizvodnje_(int value)
        {
            int staraGodinaProizvodnje = _GodinaProizvodnje;
            _GodinaProizvodnje = value;
            NaPromjenuGodineProizvodnje?.Invoke(this, new GodinaProizvodnjeEventArgs()
            {
                StaraGodinaProizvodnje = staraGodinaProizvodnje,
                NovaGodinaProizvodnje = value
            });
        }
        public void IspisAutomobila()
        {
            Console.WriteLine("Naziv: " + Naziv);
            Console.WriteLine("Godina Proizvodnje: " + GodinaProizvodnje());
            Console.WriteLine("Starost vozila: " + StarostAutomobila());
            Console.WriteLine("Osnovna cijena: " + OsnovnaCijena);
            Console.WriteLine("Ukupna cijena: " + UkupnaCijena());
        }
    }

}

