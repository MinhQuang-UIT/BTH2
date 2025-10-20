using System;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BTTH1_BT1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nhập tháng, năm
            Console.Write("Nhap thang va nam: ");
            string thoigian = Console.ReadLine();

            // Tách tháng và năm
            string[] part = thoigian.Split('/');
            int month = Convert.ToInt32((part[0]));
            int year = Convert.ToInt32((part[1]));

            // Kiểm tra dữ liệu đầu vào
            if (month < 1 || month > 12 || year < 1)
            {
                Console.WriteLine("Input khong hop le!");
                return;
            }

            // In lịch
            string[] thu = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            foreach (string th in thu)
                Console.Write(th + " ");
            Console.Write("\n");
            string day = ThuTrongTuan(1, month, year);
            int songaycuathang = SoNgayCuaThang(month, year);
            bool flag = false;
            int ngay = 1;
            while (ngay <= songaycuathang)
            {
                for (int i = 0; i < thu.Length; i++)
                {
                    if (flag)
                    {
                        Console.Write($"{ngay,3} ");
                        ++ngay;
                    }
                    else if (!flag && thu[i] != day)
                        Console.Write("    ");
                    else if (!flag && thu[i] == day)
                    {
                        Console.Write($"{ngay,3} ");
                        flag = !flag;
                        ++ngay;
                    }
                    if (ngay > songaycuathang)
                        break;
                }
                Console.Write("\n");
            }
        }

        // Kiểm tra năm nhuận
        static bool NamNhuan(int year)
        {
            return ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0));
        }

        // Xác định số ngày của tháng
        static int SoNgayCuaThang(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if (NamNhuan(year))
                        return 29;
                    return 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
            }
            return 0;
        }

        // Xác định thứ trong tuần 
        static string ThuTrongTuan(int day, int month, int year)
        {
            if (month == 1 || month == 2)
            {
                month += 12;
                year -= 1;
            }
            int k = year % 100;
            int j = year / 100;
            int h = (day + 13 * (month + 1) / 5 + k + k / 4 + j / 4 + 5 * j) % 7;
            switch (h)
            {
                case 0:
                    return "Sat";
                case 1:
                    return "Sun";
                case 2:
                    return "Mon";
                case 3:
                    return "Tue";
                case 4:
                    return "Wed";
                case 5:
                    return "Thu";
                case 6:
                    return "Fri";
            }
            return "";
        }

    }
}