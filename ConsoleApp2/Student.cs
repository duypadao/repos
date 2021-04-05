using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Student
    {
        private string _hoTen;
        private int _tuoi;
        private double _diemVan;
        private double _diemToan;
        private double _diemTrungBinh;
        
        public string HoTen 
        { 
            get { return _hoTen; }
            set {_hoTen = value; }
        }
        public int Tuoi
        {
            get { return _tuoi; }
            set { _tuoi = value; }
        }
        public double DiemVan
        {
            get { return _diemVan; }
            set { _diemVan = value; }
        }
        public double DiemToan
        {
            get { return _diemToan; }
            set { _diemToan = value; }
        }
        public double DiemTrungBinh
        {
            get { return Math.Round(((DiemVan + DiemToan)/2),2); }
            set { _diemTrungBinh = value; }
        }

        public Student()
        {
            HoTen = "";
            DiemVan = 0.0;
            DiemToan = 0.0;
            DiemTrungBinh = 0.0;
        }

        public void nhap()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap diem Van: ");
            double temp;
            temp = double.Parse(Console.ReadLine());
        }
    }

    
}
