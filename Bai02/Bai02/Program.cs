using System;
using System.IO;

namespace BTH02_Bai02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap duong dan thu muc: ");
            string strFile = Console.ReadLine();

            if (Directory.Exists(strFile))
            {
                // Lấy tất cả file và thư mục con 
                string[] path = Directory.GetFileSystemEntries(strFile, "*", SearchOption.AllDirectories);

                if (path.Length != 0)
                {
                    Console.WriteLine("Danh sach tat ca tap tin (bao gom thu muc con):\n");
                    foreach (string file in path)
                    {
                        if (Directory.Exists(file))
                            Console.WriteLine(File.GetLastWriteTime(file) + "   <DIR>          " + Path.GetFileName(file));
                        else if (File.Exists(file))
                        {
                            FileInfo fi = new FileInfo(file);
                            Console.WriteLine(File.GetLastWriteTime(file) + $"{fi.Length.ToString("N0"),17}" + " " + Path.GetFileName(file));
                        }
                    }
                }
                else
                    Console.WriteLine("Khong co tap tin hay thu muc con nao trong thu muc!");
            }
            else
                Console.WriteLine("Khong tim thay thu muc!");

            Console.ReadLine();
        }
    }
}

