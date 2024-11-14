using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public abstract class SanPham
{
    public int MaSanPham { get; set; }
    public string TenSanPham { get; set; }
    public double GiaGoc { get; set; }

    public abstract double TinhGiaBan();
    public abstract string GetLoaiSanPham();
    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"Mã sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham}, Giá gốc: {GiaGoc}");
    }
    public virtual SanPhamData ToSanPhamData()
    {
        return new SanPhamData
        {
            MaSanPham = MaSanPham,
            TenSanPham = TenSanPham,
            GiaGoc = GiaGoc,
            PhanLoai = GetLoaiSanPham()
        };
    }
}

class DienTu : SanPham
{
    public DienTu() { }
    public double Thue { get; set; }

    public override double TinhGiaBan()
    {
        return GiaGoc + GiaGoc * Thue / 100;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Thuế: {Thue}%");
    }
    public override string GetLoaiSanPham() => "Điện tử";
    public override SanPhamData ToSanPhamData()
    {
        var data = base.ToSanPhamData();
        data.Thue = Thue;
        data.GiaBan = TinhGiaBan();
        return data;
    }

}

class ThoiTrang : SanPham
{
    public ThoiTrang() { }
    public double GiamGia { get; set; }

    public override double TinhGiaBan()
    {
        return GiaGoc - GiaGoc * GiamGia / 100;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Giảm giá: {GiamGia}%");
    }
    public override string GetLoaiSanPham() => "Thời trang";
    public override SanPhamData ToSanPhamData()
    {
        var data = base.ToSanPhamData();
        data.GiamGia = GiamGia;
        data.GiaBan = TinhGiaBan();
        return data;
    }

}

class ThucPham : SanPham
{
    public ThucPham() { }
    public double PhiVanChuyen { get; set; }

    public override double TinhGiaBan()
    {
        return GiaGoc + PhiVanChuyen;
    }

    public override void HienThiThongTin()
    {
        base.HienThiThongTin();
        Console.WriteLine($"Phí vận chuyển: {PhiVanChuyen}");
    }
    public override string GetLoaiSanPham() => "Thực phẩm";
    public override SanPhamData ToSanPhamData()
    {
        var data = base.ToSanPhamData();
        data.PhiVanChuyen = PhiVanChuyen;
        data.GiaBan = TinhGiaBan();
        return data;
    }
}
