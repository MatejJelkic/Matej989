using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Automobili.Automobil;

namespace Automobili
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            try
            {

                Automobil automobil = new Automobil();

                Console.WriteLine("Unesi naziv automobila: ");
                automobil.Naziv = Console.ReadLine();

                Console.WriteLine("Unesi godinu proizvodnje automobila: ");
                automobil.GodinaProizvodnje(int.Parse(Console.ReadLine()));

                Console.WriteLine("Unesi osnovnu cijenu automobila: ");
                automobil.OsnovnaCijena = double.Parse(Console.ReadLine());


                automobil.IspisAutomobila();

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Greška" + e.Message);
            }
        }
        private static void PromjenaGodineProizvodnje(object sender, GodinaProizvodnjeEventArgs e)
        {
            Console.WriteLine("Godina proizvodnje je promijenjena sa " + e.StaraGodinaProizvodnje + " na " + e.NovaGodinaProizvodnje + ".");
        }
    }
    }

