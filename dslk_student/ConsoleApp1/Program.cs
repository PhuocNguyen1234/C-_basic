// See https://aka.ms/new-console-template for more information
// Cài đặt một cấu trúc danh sách liên kết đơn cho kiểu dữ liệu Sinh viên, với các thao tác: 
//1) Khởi tạo danh sách; 
//2) kiểm tra rỗng 
//3) thêm phần tử vào cuối (hoặc đầu) danh sách 
//4) Tìm kiếm phần tử trong danh sách; 
//5) Xóa phần tử cuối cùng khỏi danh sách; 
//6) Duyệt danh sách; 
//7) Sắp xếp danh sách
using System;
namespace DSLK
{
    public class SinhVien
    {
        private string hoTen;
        private int tuoi;
        private string lop;
        private double diem;
        public SinhVien(string hoTen, int tuoi, string lop, double diem)
        {
            this.hoTen = hoTen;
            this.tuoi = tuoi;
            this.lop = lop;
            this.diem = diem;
        }
        public void PrintDs()
        {
            Console.WriteLine($"Ten: {this.hoTen} - Lop: {this.lop} - Tuoi: {this.tuoi} - Diem: {this.diem}");
        }
    }

    public class Node
    {
        public SinhVien data;
        public Node? next;
        public Node(SinhVien data)
        {
            this.data = data;
            this.next = null;
        }
    }
    public class DanhSachSV
    {
        Node? head;
        public DanhSachSV()
        {
            this.head = null;
        }
        public void KiemTraNull()
        {
            if (head == null)
            {
                Console.WriteLine("Danh sach rong");
            }
            return;
        }
        public void DuyetDs()
        {
            Node? curr = head;
            while (curr != null)
            {
                curr.data.PrintDs();
                curr = curr.next;
            }
        }

        public void AddHead(SinhVien sv)
        {
            Node newNode = new Node(sv);
            newNode.next = head;
            head = newNode;
        }
    }
    public class Program
    {
        public static void Main()
        {
            SinhVien sv1 = new SinhVien("Huu Phuoc", 12, "10A1", 9);
            SinhVien sv2 = new SinhVien("Huu Phuoc Le", 12, "10A1", 9);
            DanhSachSV ds = new DanhSachSV();
            ds.AddHead(sv1);
            ds.AddHead(sv2);
            ds.DuyetDs();
        }
    }
}

   





