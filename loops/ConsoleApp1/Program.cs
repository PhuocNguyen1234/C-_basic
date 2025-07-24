// See https://aka.ms/new-console-template for more information
//int count = 0;
// while (count < 10)
// {
//     Console.WriteLine("Hello, World!");
//     count ++;
// }
Console.WriteLine("-----------------");
// do
// {
//     Console.WriteLine("Hello, World!");
//     count ++;
// } while (count < 10);
// for (int i = 0; i < 10; i++)
// {
//     Console.WriteLine($"Hello world!. Value i: {i}");
// }
// for (int i = 0; i < 5; i++)
// {
//     for (char j = 'a'; j <= 'e'; j++)
//     {
//         Console.WriteLine($"The cell is: {i} : {j}");
//     }
// }
//Tính tổng các sô chia hết cho 3 trong khoảng 20
int sum = 0;
Console.WriteLine("Cac so chia het cho 3: ");
for (int i = 1; i <= 20; i++)
{
    if (i % 3 == 0)
    {
        Console.WriteLine(" " + i);
        sum += i;
    }
}
Console.WriteLine($"Tong cac so chia het cho 3 trong khoang tu 1 den 20 la: {sum}");