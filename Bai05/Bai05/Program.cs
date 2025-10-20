using System;
using System.Text;


// Tạo class KhuDat
class cKhuDat
{
    protected string diadiem;
    protected double giaban;
    protected double dientich;

    public cKhuDat()
    {
        diadiem = "";
        giaban = dientich = 0;
    }
    public double getGiaBan()
    {
        return giaban;
    }
    public double getDienTich()
    {
        return dientich;
    }
    public string getDiaDiem()
    {
        return diadiem;
    }
    public virtual string Loai()
    {
        return "Khu Dat";
    }
    public virtual void Input()
    {
        Console.Write("Nhap dia diem: "); diadiem = Console.ReadLine();
        do
        {
            Console.Write("Nhap gia ban: "); giaban = Convert.ToDouble(Console.ReadLine());
        }
        while (giaban <= 0);
        do
        {
            Console.Write("Nhap dien tich: "); dientich = Convert.ToDouble(Console.ReadLine());
        }
        while (dientich <= 0);
    }

    public virtual void Output()
    {
        Console.WriteLine(Loai());
        Console.WriteLine("Dia diem: " + diadiem);
        Console.WriteLine("Gia ban: " + giaban);
        Console.WriteLine("Dien tich: " + dientich);
    }

}

//Tạo class NhaPho
class cNhaPho : cKhuDat
{
    private int namxaydung;
    private int sotang;

    public cNhaPho()
    {
        namxaydung = sotang = 0;
    }

    public override void Input()
    {
        base.Input();
        do
        {
            Console.Write("Nhap nam xay dung: "); namxaydung = Convert.ToInt32(Console.ReadLine());
        }
        while (namxaydung <= 0);
        do
        {
            Console.Write("Nhap so tang: "); sotang = Convert.ToInt32(Console.ReadLine());
        } while (sotang <= 0);
    }

    public override void Output()
    {
        base.Output();
        Console.WriteLine("Nam xay dung: " + namxaydung);
        Console.WriteLine("So tang: " + sotang);
    }

    public override string Loai()
    {
        return "Nha Pho";
    }

    public int getNamXayDung()
    {
        return namxaydung;
    }
}

// Tạo class ChungCu
class cChungCu : cKhuDat
{
    private int tang;

    public cChungCu()
    {
        tang = 0;
    }

    public override void Input()
    {
        base.Input();
        do
        {
            Console.Write("Nhap tang: "); tang = Convert.ToInt32(Console.ReadLine());
        }
        while (tang <= 0);
    }

    public override void Output()
    {
        base.Output();
        Console.WriteLine("Tang: " + tang);
    }
    public override string Loai()
    {
        return "Chung Cu";
    }
}

// Tạo class DanhSach chứa thông tin các bất động sản
class cDanhSach
{
    private List<cKhuDat> ds;
    private int n;

    public cDanhSach()
    {
        ds = new List<cKhuDat>();
        Console.Write("Nhap so bat dong san (Khu dat, Nha pho, Chung cu) can quan ly: ");
        this.n = Convert.ToInt32(Console.ReadLine());
    }

    // Nhập danh sách thông tin các bất động sản
    public void NhapDs()
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("1.Khu Dat");
            Console.WriteLine("2.Nha Pho");
            Console.WriteLine("3.Chung Cu");
            Console.Write("Nhap lua chon cua ban: ");
            int luachon = Convert.ToInt32(Console.ReadLine());
            if (luachon == 1)
            {
                var kd = new cKhuDat();
                kd.Input();
                ds.Add(kd);
            }
            if (luachon == 2)
            {
                var np = new cNhaPho();
                np.Input();
                ds.Add(np);
            }
            if (luachon == 3)
            {
                var chc = new cChungCu();
                chc.Input();
                ds.Add(chc);
            }
        }
    }

    // Xuất thông tin danh sách các bất động sản
    public void XuatDs()
    {
        for (int i = 0; i < n; i++)
            ds[i].Output();
    }

    // Tính tổng giá bán cho 3 loại (Khu đất, Nhà phố, Chung Cư) 
    public double TongGiaBan()
    {
        double tong = 0;
        for (int i = 0; i < n; i++)
            tong += ds[i].getGiaBan();
        return tong;
    }

    // Xuất danh sách các khu đất có diện tích > 100m2 hoặc là nhà phố mà có diện tích >60m2 và năm xây dựng >= 2019 (nếu có).
    public void XuatDSTheoDieuKien()
    {
        bool flag = false;
        for (int i = 0; i < n; i++)
        {
            if (ds[i].Loai() == "Khu Dat" && ds[i].getDienTich() > 100)
            {
                if (!flag)
                {
                    Console.WriteLine("Danh sach cac khu dat co dien tich > 100 hoac la nha pho ma co dien tich > 60 va nam xay dung >= 2019 (neu co):");
                    flag = true;
                }
                ds[i].Output();
                Console.WriteLine("------------------------------------");
            }
            else if (ds[i].Loai() == "Nha Pho" && ds[i].getDienTich() > 60 && ((cNhaPho)ds[i]).getNamXayDung() >= 2019)
            {
                if (!flag)
                {
                    Console.WriteLine("Danh sach cac khu dat co dien tich > 100 hoac la nha pho ma co dien tich > 60 va nam xay dung >= 2019 (neu co):");
                    flag = true;
                }
                ds[i].Output();
                Console.WriteLine("------------------------------------");
            }
        }
        if (!flag)
        {
            Console.WriteLine("Khong ton tai cac khu dat co dien tich > 100 hoac la nha pho ma co dien tich > 60 va nam xay dung >= 2019!");
            Console.WriteLine("------------------------------------");
        }
    }

    // Xuất thông  tin danh sách tất cả các nhà phố hoặc chung cư phù hợp yêu cầu. (có địa điểm chứa chuỗi tìm kiếm
    // không phân biệt hoa thường, có giá <= giá tìm kiếm, và diện tích >= diện tích cần tìm kiếm)
    public void TimKiemTheoYeuCau(string diadiemtk, double giatk, double dientichtk)
    {
        diadiemtk = diadiemtk.ToLower();
        bool flag = false;
        for (int i = 0; i < n; i++)
        {
            string diadiem = ds[i].getDiaDiem();
            diadiem = diadiem.ToLower();
            int idx = diadiem.IndexOf(diadiemtk);
            if ((ds[i].Loai() == "Nha Pho" || ds[i].Loai() == "Chung Cu") && (ds[i].getGiaBan() <= giatk && ds[i].getDienTich() >= dientichtk && idx != -1))
            {
                if (!flag)
                {
                    Console.WriteLine("Thong tin danh sach tat ca cac nha pho hoac chung cu phu hop yeu cau");
                    flag = true;
                }
                ds[i].Output();
                Console.WriteLine("------------------------------------");
            }
        }
        if (!flag)
            Console.WriteLine("Khong co cac nha pho hoac chung cu nao phu hop yeu cau!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        cDanhSach ds = new cDanhSach();

        // Nhập thông tin danh sách
        Console.WriteLine("Nhap danh sach thong tin( Khu dat, Nha pho, Chung cu");
        ds.NhapDs();

        // Xuất thông tin danh sách
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Xuat danh sach thong tin");
        ds.XuatDs();

        // Tính tổng giá bán cho 3 loại (Khu đất, Nhà phố, Chung Cư) của công ty Đại Phú.
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Tong gia ban cho 3 loai (Khu dat, Nha pho, Chung cu) cua cong ty Dai Phu la: " + ds.TongGiaBan());

        //Xuất danh sách các khu đất có diện tích > 100m2 hoặc là nhà phố mà có diện tích > 60m2 và năm xây dựng >= 2019(nếu có).
        Console.WriteLine("------------------------------------");
        ds.XuatDSTheoDieuKien();

        //Nhập vào các thông tin cần tìm kiếm(địa điểm, giá, diện tích)
        Console.Write("Nhap diem diem can tim: ");
        string diadiemtk = Console.ReadLine();
        Console.Write("Nhap gia ban can tim: ");
        double giatk = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhap dien tich can tim: ");
        double dientichtk = Convert.ToDouble(Console.ReadLine());

        // Xuất thông tin danh sách tất cả các nhà phố hoặc chung cư phù hợp yêu cầu. (có địa điểm chứa chuỗi tìm
        // kiếm không phân biệt hoa thường, có giá <= giá tìm kiếm, và diện tích >= diện tích cần tìm kiếm)
        ds.TimKiemTheoYeuCau(diadiemtk, giatk, dientichtk);
    }
}