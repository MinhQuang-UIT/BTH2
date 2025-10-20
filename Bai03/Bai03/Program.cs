using System;

namespace BTH2_Bai02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nhập số dòng, số cột của ma trận
            Console.Write("Nhap so dong cua ma tran: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap so cot cua ma tran: ");
            int m = Convert.ToInt32(Console.ReadLine());
            if (n < 1 || m < 1)
            {
                Console.WriteLine("Thong tin khong hop le!");
                return;
            }
            int[,] a = new int[n, m];

            // a) Nhập/ xuất ma trận hai chiều các số nguyên
            Console.WriteLine("Nhap ma tran:");
            Input(a, n, m);
            Console.WriteLine("Ma tran vua nhap:");
            Output(a, n, m);

            // b) Tìm kiếm một phân tử trong ma trận
            Console.Write("Nhap phan tu can tim: ");
            int x = Convert.ToInt32(Console.ReadLine());
            TimKiem(a, n, m, x);

            // c) Xuất các phần tử là số nguyên tố
            CacSoNguyenTo(a, n, m);

            // d) Dòng chứa nhiều số nguyên tố nhất
            int row = DongChuaNhieuSntNhat(a, n, m);
            if (row != -1)
                Console.WriteLine("\nDong chua nhieu so nguyen to nhat o vi tri: " + row);
            else
                Console.WriteLine("\nKhong co dong nao chua so nguyen to!");

        }

        // Nhập ma trận
        static void Input(int[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                    a[i, j] = int.Parse(row[j]);
            }
        }

        // Xuất ma trận
        static void Output(int[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j] + " ");
                Console.Write("\n");
            }
        }

        //Tìm kiếm 1 phần tử
        static void TimKiem(int[,] a, int n, int m, int x)
        {
            int dong = -1, cot = -1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] == x)
                    {
                        dong = i;
                        cot = j;
                    }
            if (dong == -1)
                Console.WriteLine("Phan tu " + x + " khong ton tai trong ma tran");
            else
                Console.WriteLine("Vi tri cua phan tu " + x + " trong ma tran: dong " + dong + " cot " + cot);
        }

        //Kiểm tra 1 số có phải là số nguyên tố hay không
        static bool LaSnt(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        // Kiểm tra ma trận có tồn tại số nguyên tố nào không
        static bool KiemTraSntTrongMaTran(int[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (LaSnt(a[i, j]))
                        return true;
            return false;
        }

        //Xuất các phần tử là số nguyên tố
        static void CacSoNguyenTo(int[,] a, int n, int m)
        {
            if (KiemTraSntTrongMaTran(a, n, m))
            {
                Console.Write("Cac phan tu la so nguyen to: ");
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        if (LaSnt(a[i, j]))
                            Console.Write(a[i, j] + " ");
            }
            else
                Console.Write("Khong ton tai so nguyen to trong ma tran!");
        }

        // Cho biết dòng nào có nhiều số nguyên tố nhất
        static int DongChuaNhieuSntNhat(int[,] a, int n, int m)
        {
            int row = -1;
            int countmx = 0;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                    if (LaSnt(a[i, j]))
                        ++count;
                if (count > countmx)
                {
                    row = i;
                    countmx = count;
                }
            }
            return row;
        }
    }
}
