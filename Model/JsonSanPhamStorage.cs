using System.Text.Json;

public class ISanPhamStorage{
    private readonly string _jsonPath = "sanpham.json";
    private List<SanPhamData> _sanpham;
    private int _lastId = 0;
    public ISanPhamStorage(){
        LoadSanPham();
    }
    public void LoadSanPham(){
        if (File.Exists(_jsonPath))
        {
            string jsonContent = File.ReadAllText(_jsonPath);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            _sanpham = JsonSerializer.Deserialize<List<SanPhamData>>(jsonContent, options) ?? new List<SanPhamData>();
            _lastId = _sanpham.Any() ? _sanpham.Max(t => t.MaSanPham) : 0;
        }
        else
        {
            _sanpham = new List<SanPhamData>();
        }
    }
    public void SaveSanPham(SanPham sanPham){
        sanPham.MaSanPham=++_lastId;
        var spData = sanPham.ToSanPhamData();
        _sanpham.Add(spData);
        var option = new JsonSerializerOptions {WriteIndented = true };
        string jsonConvert = JsonSerializer.Serialize(_sanpham,option);
        File.WriteAllText(_jsonPath,jsonConvert);
    }
    public List<SanPhamData> GetLstSanPham()
    {
        return _sanpham;
    }
}