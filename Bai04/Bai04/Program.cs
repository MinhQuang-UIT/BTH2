using System;
using System.Xml;

namespace BTH02_Bai04
{

    class cPhanSo
    {
        private int tuso;
        private int mauso;

        public cPhanSo()
        {
            tuso = 0;
            mauso = 1;
        }
        public cPhanSo(int ts, int ms)
        {
            this.tuso = ts;
            this.mauso = ms;
        }
        public cPhanSo(int tuso)
        {
            this.tuso = tuso;
            this.mauso = 1;
        }

        public int getTuso()
        {
            return tuso;
        }

        // Tìm ucln
        public static int gcd(int a, int b)
        {
            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }

        //Rút gọn phân số
        public static void RutGon(ref cPhanSo a)
        {
            int ucln = gcd(a.tuso, a.mauso);
            a.tuso /= ucln;
            a.mauso /= ucln;
        }

        // Toán tử +
        public static cPhanSo operator +(cPhanSo a, cPhanSo b)
        {
            if (a.mauso == b.mauso)
                return new cPhanSo(a.tuso + b.tuso, a.mauso);
            cPhanSo c = new cPhanSo();
            c.tuso = a.tuso * b.mauso + a.mauso * b.tuso;
            c.mauso = a.mauso * b.mauso;
            RutGon(ref c);
            return c;
        }

        //Toán tử -
        public static cPhanSo operator -(cPhanSo a, cPhanSo b)
        {
            if (a.mauso == b.mauso)
                return new cPhanSo(a.tuso - b.tuso, a.mauso);
            cPhanSo c = new cPhanSo();
            c.tuso = a.tuso * b.mauso - a.mauso * b.tuso;
            c.mauso = a.mauso * b.mauso;
            RutGon(ref c);
            return c;
        }

        //Toán tử *
        public static cPhanSo operator *(cPhanSo a, cPhanSo b)
        {
            cPhanSo c = new cPhanSo();
            c.tuso = a.tuso * b.tuso;
            c.mauso = a.mauso * b.mauso;
            RutGon(ref c);
            return c;
        }

        //Toán tử /
        public static cPhanSo operator /(cPhanSo a, cPhanSo b)
        {
            cPhanSo c = new cPhanSo();
            c.tuso = a.tuso * b.mauso;
            c.mauso = a.mauso * b.tuso;
            RutGon(ref c);
            return c;
        }

        // Toán tử < 
        public static bool operator <(cPhanSo a, cPhanSo b)
        {
            return (a.tuso * b.mauso < a.mauso * b.tuso);
        }

        // Toán tử >
        public static bool operator >(cPhanSo a, cPhanSo b)
        {
            return (a.tuso * b.mauso > a.mauso * b.tuso);
        }

        //Nhập phân số
        public void Input()
        {
            while (true)
            {
                string[] args = Console.ReadLine().Split('/');

                if (args.Length == 2)
                {
                    tuso = int.Parse(args[0]);
                    mauso = int.Parse(args[1]);
                }
                else
                {
                    tuso = int.Parse(args[0]);
                    mauso = 1;
                }
                if (mauso != 0)
                    break;
                else
                    Console.Write("Phan so khong hop le! Nhap lai: ");
            }
        }

        // Xuất phân số
        public void Output()
        {
            if (mauso < 0)
            {
                tuso = -tuso;
                mauso = -mauso;
            }
            Console.Write(tuso + "/" + mauso);
        }
    }

    class cDanhSachPhanSo
    {
        private List<cPhanSo> dsps = new List<cPhanSo>();
        private int n;

        public cDanhSachPhanSo()
        {
            Console.Write("\nNhap so luong phan so cua day: ");
            this.n = int.Parse(Console.ReadLine());
        }

        // Nhập danh sách phân số
        public void Input()
        {
            for (int i = 0; i < n; i++)
            {
                cPhanSo ps = new cPhanSo();
                ps.Input();
                dsps.Add(ps);
            }
        }

        //Xuất danh sách phân số
        public void Output()
        {
            for (int i = 0; i < n; i++)
            {
                dsps[i].Output();
                Console.Write(" ");
            }
        }
        // Tìm phân số lớn nhất trong dãy
        public void TimPhanSoMax()
        {
            cPhanSo psmax = dsps[0];
            for (int i = 1; i < n; i++)
            {
                if (dsps[i] > psmax)
                    psmax = dsps[i];
            }
            Console.Write("Phan so lon nhat trong day la: "); psmax.Output();
        }

        //Sắp xếp các phân số trong dãy tăng dân
        public void SapXepTangDan()
        {
            for (int i = 1; i < n; i++)
            {
                int idx = i - 1;
                cPhanSo temp = dsps[i];
                while (idx >= 0 && dsps[idx] > temp)
                {
                    dsps[idx + 1] = dsps[idx];
                    idx--;
                }
                dsps[idx + 1] = temp;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Nhập phân số thứ nhất
            cPhanSo ps1 = new cPhanSo();
            Console.Write("Nhap phan so thu nhat: "); ps1.Input();

            //Nhập phân số thứ hai
            cPhanSo ps2 = new cPhanSo();
            Console.Write("Nhap phan so thu hai: "); ps2.Input();

            //Tổng hai phân số
            if (ps1.getTuso() == 0 && ps2.getTuso() == 0)
                Console.Write("Ket qua cong phan so thu nhat voi phan so thu hai: " + 0);
            else
            {
                Console.Write("Ket qua cong phan so thu nhat voi phan so thu hai: "); (ps1 + ps2).Output();
            }

            //Hiệu hai phân số
            if (ps1.getTuso() == 0 && ps2.getTuso() == 0)
                Console.Write("\nKet qua tru phan so thu nhat voi phan so thu hai: " + 0);
            else
            {
                Console.Write("\nKet qua tru phan so thu nhat voi phan so thu hai: "); (ps1 - ps2).Output();
            }

            //Tích hai phân số
            if (ps1.getTuso() == 0 || ps2.getTuso() == 0)
                Console.Write("\nKet qua nhan phan so thu nhat voi phan so thu hai: " + 0);
            else
            {
                Console.Write("\nKet qua nhan phan so thu nhat voi phan so thu hai: "); (ps1 * ps2).Output();
            }

            //Thương hai phân số
            if (ps2.getTuso() == 0)
                Console.Write("\nKhong the thuc hien phep chia phan so thu nhat cho phan so thu hai");
            else if (ps1.getTuso() == 0)
                Console.Write("\nKet qua chia phan so thu nhat voi phan so thu hai: " + 0);
            else
            {
                Console.Write("\nKet qua chia phan so thu nhat voi phan so thu hai: "); (ps1 / ps2).Output();
            }

            Console.Write("\n-------------------------------------------------");
            cDanhSachPhanSo ds = new cDanhSachPhanSo();

            // Nhập danh sách phân số
            Console.WriteLine("Nhap danh sach phan so: ");
            ds.Input();

            //Tìm phân số lớn nhất của dãy
            ds.TimPhanSoMax();

            //Sắp xếp các phân số tăng dần
            ds.SapXepTangDan();

            // In danh sách phân số sau khi sắp xếp
            Console.Write("\nDanh sach phan so sau khi sap xep tang dan: ");
            ds.Output();
        }

    }
}