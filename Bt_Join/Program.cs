using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bt_Join
{
    class Employee
    {
        private String maNV;
        private String hoTen;
        private int tuoi;
        private float soGioLam;
        private float luongMotGio;
        private int iD;
        
        public Employee() { }
        public Employee(String maNV, String hoTen, int tuoi, float soGioLam, float luongMotGio, int iD)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.tuoi = tuoi;
            this.soGioLam = soGioLam;
            this.luongMotGio = luongMotGio;
            this.iD = iD;
        }
        public String MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        public String HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public int Tuoi
        {
            get { return tuoi; }
            set { tuoi = value; }
        }
        public float SoGioLam
        {
            get { return soGioLam; }
            set { soGioLam = value; }
        }
        public float LuongMotGio
        {
            get { return luongMotGio; }
            set { luongMotGio = value; }
        }
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public float tinhLuong()
        {
            return soGioLam * luongMotGio;
        }
    }
    class Department
    {
        private int iD;
        private String tenChucVu;
        public Department (){}
        public Department(int iD, string tenChucVu)
        {
            this.iD = iD;
            this.tenChucVu = tenChucVu;
        }
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public String TenChucVu
        {
            get { return tenChucVu; }
            set { tenChucVu = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dsnv = new List<Employee>
            {
                new Employee { MaNV = "NV01", HoTen = "Nguyen Huu Phuoc", Tuoi = 20, SoGioLam = 120, LuongMotGio = 20000, ID = 1 },
                new Employee { MaNV = "NV02", HoTen = "Nguyen Hoai Nam", Tuoi = 18, SoGioLam = 110, LuongMotGio = 20000, ID = 2 },
                new Employee { MaNV = "NV03", HoTen = "Nguyen Dang Khoa", Tuoi = 19, SoGioLam = 113, LuongMotGio = 20000, ID = 3 },
                new Employee { MaNV = "NV04", HoTen = "Le Viet Dat", Tuoi = 23, SoGioLam = 100, LuongMotGio = 20000, ID = 1 },
                new Employee { MaNV = "NV05", HoTen = "Vo My Dung", Tuoi = 21, SoGioLam = 80, LuongMotGio = 20000, ID = 2 },
                new Employee { MaNV = "NV06", HoTen = "Nguyen Van Ly", Tuoi = 22, SoGioLam = 150, LuongMotGio = 20000, ID = 2 },
            };

            var dscv = new List<Department>
            {
                new Department {ID = 1, TenChucVu = "Pha che"},
                new Department {ID = 2, TenChucVu = "Phuc vu"},
                new Department {ID = 3, TenChucVu = "Thu ngan"},
            };

            void HienThiDanhSach(IEnumerable<dynamic> query, string tieuDe)
            {
                Console.WriteLine(tieuDe);
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("| {0,-6} | {1,-20} | {2,-5} | {3,-10} | {4,-10} | {5,-10} | {6,-10} |",
                                  "MaNV", "Ho Ten", "Tuoi", "So Gio", "Luong/h", "Luong", "Ten chuc vu");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                foreach (var emp in query)
                {
                    Console.WriteLine("| {0,-6} | {1,-20} | {2,-5} | {3,-10} | {4,-10} | {5,-10} | {6,-10} |",
                                      emp.MaNV, emp.HoTen, emp.Tuoi, emp.SoGioLam, emp.LuongMotGio, emp.Luong, emp.TenChucVu);
                }
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }
            var dstoanbonv = from emp in dsnv
                             join dep in dscv on emp.ID equals dep.ID
                             select new
                             {
                                 emp.MaNV,
                                 emp.HoTen,
                                 emp.Tuoi,
                                 emp.SoGioLam,
                                 emp.LuongMotGio,
                                 Luong = emp.tinhLuong(),
                                 dep.TenChucVu
                             };
            var tuoitrungbinh = from emp in dsnv
                                join dep in dscv on emp.ID equals dep.ID
                                group emp by dep.TenChucVu into g
                                select new
                                {
                                    phongBan = g.Key,
                                    tuoiTrungBinh = Math.Round(g.Average(e => e.Tuoi), 2)
                                };
            var nhanVienSapXep = dstoanbonv.OrderBy(emp => emp.Tuoi);
            var luongTrungBinh = Math.Round(dstoanbonv.Average(emp => emp.SoGioLam * emp.LuongMotGio), 2);

            Console.WriteLine("1. Hien thi danh sach toan bo nhan vien\n2. Hien thi danh sach nhan vien theo tuoi tang dan" +
                                "\n3. Hien thi tuoi trung binh cua sinh vien theo phong ban\n4. Hien thi luong trung binh cua cong ty");
            Console.Write("Chon danh sach hien thi: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            switch (choice) 
            {
                case 1:
                    //Hien thi danh sach nhan vien
                    HienThiDanhSach(dstoanbonv, "Danh sach toan bo nhan vien");
                    break;
                case 2:
                    //Hien thi danh sach nhan vien theo tuoi
                    HienThiDanhSach(nhanVienSapXep, "Danh sach nhan vien theo tuoi tang dan");
                    break;
                case 3:
                    //Hien thi tuoi trung binh cua sinh vien theo phong ban
                    Console.WriteLine("Tuoi trung binh theo tung ban");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("| {0,-15} | {1,-10} |", "Phong Ban", "TB Tuoi");
                    Console.WriteLine("-----------------------------------");
                    foreach (var it in tuoitrungbinh)
                    {
                        Console.WriteLine("| {0,-15} | {1,-10} |", it.phongBan, it.tuoiTrungBinh);
                    }
                    Console.WriteLine();
                    break;
                case 4:
                    //Hien thi luong trung binh cua cong ty
                    Console.WriteLine("Luong trung binh: {0} VND", luongTrungBinh);
                    break;
                default:
                    break;
            } 
        }
    }
 }
