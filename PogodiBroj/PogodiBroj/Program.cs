using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogodiBroj
{
    internal class PogodiBroj
    {
       
        
            static void Main(string[] args)
            {
                int SkriveniBroj = new Random().Next(1, 101); 
                int Pogodi;

                Console.WriteLine("Dobrodošli u igru pogodi broj!");
                Console.WriteLine("Pogodi broj između 1 - 100 :");

                for (int i = 1; i <= 7; i++) 
                {
                    Pogodi = int.Parse(Console.ReadLine());

                    if (Pogodi == SkriveniBroj)
                    {
                        Console.WriteLine("Čestitam! Pogodio/la si skriveni broj iz " + i + " pokušaja.");
                        return;
                    }
                    else if (Pogodi < SkriveniBroj)
                    {
                        Console.WriteLine("Pre nizak. Pokušaj ponovo.");
                    }
                    else
                    {
                        Console.WriteLine("Pre visok. Pokušaj ponovo.");
                    }
                }

                Console.WriteLine("Dostigao/la si maksimalan broj pokušaja.");
                Console.WriteLine("Skriveni broj je:  " + SkriveniBroj);
            }
        }
    }
    

