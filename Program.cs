using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> tinhToan;
            tinhToan = (a, b) => {
                int kq = a + b;
                return kq;
            };
            Action<string, string> thongbao;

            thongbao = (msg, name) => {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(msg + " " + name);
                Console.ResetColor();
            };
            thongbao?.Invoke("Xin chao", "Phuoc Nguyen");
            Console.WriteLine(tinhToan.Invoke(5, 6));

            Console.WriteLine("Cac so khong chia het cho 2");
            int[] mang = { 2, 4, 6, 8, 10, 9, 11 };
            mang.ToList().ForEach((x) =>
            {
                if (x % 2 != 0)
                    Console.WriteLine(x);
            });

            Console.WriteLine("Cac so chia het cho 4");
            var kq1 = mang.Where((x) =>
            {
                return x % 4 == 0;
            });

            foreach (var n in kq1)
            {
                Console.WriteLine(n);
            }
        }
    }
}
