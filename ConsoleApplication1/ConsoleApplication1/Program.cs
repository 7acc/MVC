using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        public static string randomize()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);      
            var strängen = "";
            
                var nr = rnd.Next(1, 3);
                if(nr == 1)
                {
                    strängen = "J&D";
                }
                else
                {
                    strängen = "petra";
                }
            return strängen;

        }
        static void Main(string[] args)
        {
            List<string> List = new List<string>();

            for (int i = 0; i < 200000; i++)
            {
                var val = randomize();
               
                Console.Write(val);
                List.Add(val);
            }

            var jd = List.Where(x => x == "J&D").ToList().Count;
            var petra = List.Where(x => x == "petra").ToList().Count;
            Console.WriteLine();
            Console.WriteLine("petra: " + petra);
            Console.WriteLine("J&D: " + jd);
            Console.ReadKey();
        }
    }
}
