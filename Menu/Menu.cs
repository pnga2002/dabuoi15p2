public class Menu{
            
    private readonly QuanLySanPham quanLySanPham;
    public Menu(){
        quanLySanPham = new QuanLySanPham(new ISanPhamStorage());
    }
    public void ShowMainMenu(){
        while(true){
            Console.WriteLine("----- Menu Quản Lý Sản Phẩm -----");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm");
            Console.WriteLine("3. Tính tổng doanh thu");
            Console.WriteLine("4. Thoát");
            Console.Write("Chọn chức năng: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ThemSanPham(quanLySanPham);
                    break;
                case "2":
                    quanLySanPham.HienThiDanhSachSanPham();
                    break;
                case "3":
                    quanLySanPham.TinhTongDoanhThu();
                    break;
                case "4":
                    Console.WriteLine("Thoát chương trình.");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
            Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }
    }
    static void ThemSanPham(QuanLySanPham quanLySanPham)
    {
        Console.WriteLine("Chọn loại sản phẩm:");
        Console.WriteLine("1. Điện tử");
        Console.WriteLine("2. Thời trang");
        Console.WriteLine("3. Thực phẩm");
        int loaiSanPham = int.Parse(Console.ReadLine());

        Console.Write("Nhập tên sản phẩm: ");
        string tenSanPham = Console.ReadLine();
        Console.Write("Nhập giá gốc: ");
        double giaGoc = double.Parse(Console.ReadLine());

        switch (loaiSanPham)
        {
            case 1:
                Console.Write("Nhập thuế (%): ");
                double thue = double.Parse(Console.ReadLine());
                DienTu dienTu = new DienTu
                {
                    TenSanPham = tenSanPham,
                    GiaGoc = giaGoc,
                    Thue = thue
                };
                quanLySanPham.ThemSanPham(dienTu);
                break;
            case 2:
                Console.Write("Nhập giảm giá (%): ");
                double giamGia = double.Parse(Console.ReadLine());
                ThoiTrang thoiTrang = new ThoiTrang
                {
                    TenSanPham = tenSanPham,
                    GiaGoc = giaGoc,
                    GiamGia = giamGia
                };
                quanLySanPham.ThemSanPham(thoiTrang);
                break;
            case 3:
                Console.Write("Nhập phí vận chuyển: ");
                double phiVanChuyen = double.Parse(Console.ReadLine());
                ThucPham thucPham = new ThucPham
                {
                    TenSanPham = tenSanPham,
                    GiaGoc = giaGoc,
                    PhiVanChuyen = phiVanChuyen
                };
                quanLySanPham.ThemSanPham(thucPham);
                break;
            default:
                Console.WriteLine("Loại sản phẩm không hợp lệ.");
                break;
        }
    }
}