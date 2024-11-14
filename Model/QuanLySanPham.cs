using System.Text.Json;

class QuanLySanPham
{
    private List<SanPhamData> danhSachSanPham;

    private readonly ISanPhamStorage _storage;

    public QuanLySanPham(ISanPhamStorage storage)
    {
        _storage = storage;
        danhSachSanPham = _storage.GetLstSanPham();
    }
    public void ThemSanPham(SanPham sanPham)
    {
        _storage.SaveSanPham(sanPham);
    }

    public void HienThiDanhSachSanPham()
    {
        Console.Clear();
        Console.WriteLine("=== DANH SÁCH SẢN PHẨM ===\n");
        var sps = _storage.GetLstSanPham();
        if(!sps.Any()){
            Console.WriteLine("Chưa có sản phẩm nào!");
            return;
        }
        foreach(var sp in sps){
            Console.WriteLine($"Mã SP: {sp.MaSanPham}");
            Console.WriteLine($"Tên SP: {sp.TenSanPham}");
            Console.WriteLine($"Giá gốc: {sp.GiaGoc:N0} VND");
            Console.WriteLine($"Mã loại: {sp.PhanLoai}");
            Console.WriteLine($"Giá bán: {sp.GiaBan}");
            if (sp.Thue != null)
            {
                Console.WriteLine($"Thuế: {sp.Thue}");
            }
            if (sp.GiamGia != null)
            {
                Console.WriteLine($"Giảm giá: {sp.GiamGia}");
            }
            if (sp.PhiVanChuyen != null)
            {
                Console.WriteLine($"Phí vận chuyển: {sp.PhiVanChuyen}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }

    public void TinhTongDoanhThu()
    {
        double tongDoanhThu = 0;
        foreach (var sanPham in danhSachSanPham)
        {
            tongDoanhThu += sanPham.GiaBan;
        }
        Console.WriteLine($"Tổng doanh thu: {tongDoanhThu}");
    }


}
