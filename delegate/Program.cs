using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @delegate
{
    public delegate void Showlog(string message);
    class Program
    {
        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static void Tong(int a, int b, Showlog log)
        {
            int kq = a + b;
            log?.Invoke("Tong la " + kq);
        }
        static int Hieu(int a, int b) => a - b;
        static void Main(string[] args)
        {
            //Showlog log = null;
            //log = Info;
            //log("Xin chao");
            //log = Warning;
            //log?.Invoke("Xin chao abc");

            //Action<string> action2;
            //action2 = Warning;
            //action2 += Info;

            //action2?.Invoke("Thong bao tu action");
            
            Func<int> f1;
            Tong(4, 5, Warning);
            
        }
    }
}
