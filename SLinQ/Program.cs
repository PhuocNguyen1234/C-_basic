namespace SLinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataSource = DanhSach();
            Print(dataSource);
            var query = from data in dataSource
                        where GreaterThan0(data)
                        select data;
            //var query = dataSource.Where(data => GreaterThan0(data));
            Print(query);
            Console.WriteLine("Tong cac so lon hon 0");
            Console.WriteLine(query.Sum());
            Console.WriteLine($"Co bao nhieu so lon hon 0: {query.Count()}");
            Console.ReadLine();


        }
        static Boolean GreaterThan0(int n)
        {
            return n > 0;
        }
        static IEnumerable<int> DanhSach() 
        {
            var ds = new[] { 10, 9, 19, 20, -2, 14 };
            return ds;
        }
        static void Print(IEnumerable<int> value)
        {
            Console.WriteLine("--------------");
            foreach(var i in value)
            {
                Console.WriteLine(" " + i);
            }
        }
    }
}
