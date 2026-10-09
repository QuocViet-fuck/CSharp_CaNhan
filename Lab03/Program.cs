using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BaiThucHanhLINQ;

public sealed class MonHoc
{
    public string MaMon { get; set; } = "";
    public string TenMon { get; set; } = "";
    public string He { get; set; } = "";
    public byte SoTiet { get; set; }
}

public sealed class He
{
    public string MaHe { get; set; } = "";
    public string TenHe { get; set; } = "";
}

public static class DuLieu
{
    public static List<MonHoc> DS_Mon() => new()
    {
        new() { MaMon = "HP2_1", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
        new() { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
        new() { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
        new() { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
        new() { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
        new() { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
        new() { MaMon = "JQUE", TenMon = "JQuery", He = "CD", SoTiet = 22 },
        new() { MaMon = "XML", TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
        new() { MaMon = "CRYS", TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
        new() { MaMon = "BWEB", TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
        // XYZ cố ý để trống hệ nhằm kiểm tra full outer join.
        new() { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
    };

    public static List<He> DS_He() => new()
    {
        new() { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
        new() { MaHe = "CD", TenHe = "Chuyên đề" },
        new() { MaHe = "QT", TenHe = "Chứng chỉ quốc tế" }
    };
}

internal static class Program
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("THỰC HÀNH LINQ CƠ BẢN - LAB 03");
        Console.WriteLine(new string('=', 70));
        Bai21(); Bai22(); Bai31(); Bai32(); Bai51(); Bai52(); Bai62();
    }

    private static void TieuDe(string text) => Console.WriteLine($"\n\n{text}\n{new string('-', text.Length)}");
    private static void In<T>(IEnumerable<T> values) => Console.WriteLine(string.Join(", ", values));
    private static void InMon(IEnumerable<MonHoc> values)
    {
        foreach (var m in values) Console.WriteLine($"{m.MaMon,-7} | {m.TenMon,-48} | {m.He,-3} | {m.SoTiet,3} tiết");
    }

    // Bai 2.1: lọc và biến đổi mảng số bằng LINQ.
    private static void Bai21()
    {
        TieuDe("Bài 2.1 - Truy vấn mảng số nguyên");
        int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };
        // Query Syntax: chia hết cho cả 4 và 3.
        var chiaHetQuery = from so in mangSo where so % 4 == 0 && so % 3 == 0 select so;
        // Method Syntax: biểu diễn cùng yêu cầu để đối chiếu.
        var chiaHetMethod = mangSo.Where(so => so % 4 == 0 && so % 3 == 0);
        Console.Write("a) Chia hết cho 4 và 3 (Query): "); In(chiaHetQuery);
        Console.Write("   Chia hết cho 4 và 3 (Method): "); In(chiaHetMethod);
        Console.Write("b) Nhỏ hơn hoặc bằng 3: "); In(mangSo.Where(so => so <= 3));
        var bienDoi = mangSo.Select(so => so % 2 == 0 ? so / 2 : so);
        Console.Write("c) Số chẵn chia đôi, số lẻ giữ nguyên: "); In(bienDoi);
    }

    // Bai 2.2: truy vấn chuỗi, chuẩn hóa hoa/thường và chọn theo ký tự đầu.
    private static void Bai22()
    {
        TieuDe("Bài 2.2 - Truy vấn mảng chuỗi");
        string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };
        var bonKyTuQuery = from tu in mangChuoi where tu.Length == 4 orderby tu[0] select tu;
        Console.Write("a) Có 4 ký tự, tăng theo ký tự đầu (Query): "); In(bonKyTuQuery);
        Console.Write("   Có 4 ký tự (Method): "); In(mangChuoi.Where(tu => tu.Length == 4).OrderBy(tu => tu[0]));
        Console.WriteLine("b) Dạng chữ thường - CHỮ HOA:");
        foreach (var tu in mangChuoi) Console.WriteLine($"   {tu.ToLower(Vi)} - {tu.ToUpper(Vi)}");
        Console.Write("c) Chứa ký tự u: "); In(mangChuoi.Where(tu => tu.Contains('u', StringComparison.CurrentCultureIgnoreCase)));
        Console.Write("d) Từ bắt đầu bằng chữ in hoa: "); In(mangChuoi.Where(tu => tu.Length > 0 && char.IsUpper(tu[0])));
    }

    // Bai 3.1: thống kê số và GroupBy theo số dư.
    private static void Bai31()
    {
        TieuDe("Bài 3.1 - Thống kê mảng số");
        int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };
        Console.WriteLine($"a) Tổng số phần tử: {mangSo.Length}; chẵn: {mangSo.Count(x => x % 2 == 0)}; lẻ: {mangSo.Count(x => x % 2 != 0)}");
        Console.WriteLine($"b) Tổng: {mangSo.Sum()}; lớn nhất: {mangSo.Max()}; nhỏ nhất: {mangSo.Min()}");
        Console.WriteLine($"c) Số giá trị khác nhau: {mangSo.Distinct().Count()}");
        Console.WriteLine("d) Nhóm theo số dư khi chia 5:");
        foreach (var group in mangSo.GroupBy(x => x % 5).OrderBy(g => g.Key))
        {
            Console.WriteLine($"   Dư {group.Key}: {string.Join(", ", group)}");
        }
    }

    // Bai 3.2: thống kê độ dài và nhóm món theo từ đầu tiên.
    private static void Bai32()
    {
        TieuDe("Bài 3.2 - Thống kê mảng chuỗi");
        string[] monAn =
        {
            "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
            "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây",
            "Mì xào", "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả",
            "Hủ tiếu Nam vang"
        };
        int min = monAn.Min(x => x.Length), max = monAn.Max(x => x.Length);
        Console.WriteLine($"a) Độ dài ngắn nhất: {min}: {string.Join("; ", monAn.Where(x => x.Length == min))}");
        Console.WriteLine($"   Độ dài dài nhất: {max}: {string.Join("; ", monAn.Where(x => x.Length == max))}");
        Console.WriteLine("b) Nhóm theo từ đầu tiên:");
        foreach (var group in monAn
            .GroupBy(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0])
            .OrderBy(g => g.Key))
        {
            Console.WriteLine($"   {group.Key}: {string.Join("; ", group)}");
        }
        Console.WriteLine($"c) Số món bắt đầu bằng Bánh: {monAn.Count(x => x.StartsWith("Bánh", StringComparison.CurrentCulture))}");
    }

    // Bai 5.1: các truy vấn lọc/sắp xếp cơ bản trên List<MonHoc>.
    private static void Bai51()
    {
        TieuDe("Bài 5.1 - Truy vấn cơ bản trên List<MonHoc>");
        var ds = DuLieu.DS_Mon();
        var lapTrinh = from m in ds where m.TenMon.StartsWith("Lập trình", StringComparison.CurrentCulture) select m.TenMon;
        Console.WriteLine("a) Tên môn bắt đầu bằng Lập trình (Query):"); In(lapTrinh);
        Console.WriteLine("   (Method):");
        In(ds
            .Where(m => m.TenMon.StartsWith("Lập trình", StringComparison.CurrentCulture))
            .Select(m => m.TenMon));
        Console.WriteLine("b) Hệ CD, số tiết giảm dần rồi mã tăng dần:");
        InMon(ds
            .Where(m => m.He == "CD")
            .OrderByDescending(m => m.SoTiet)
            .ThenBy(m => m.MaMon));
        Console.WriteLine("c) Tên chứa từ web (không phân biệt hoa thường):");
        foreach (var m in ds.Where(m => m.TenMon.Contains("web", StringComparison.CurrentCultureIgnoreCase)))
        {
            Console.WriteLine($"   {m.TenMon} | {m.He}");
        }
        Console.WriteLine("d) Hệ KTV, mã tăng dần:"); InMon(ds.Where(m => m.He == "KTV").OrderBy(m => m.MaMon));
    }

    // Bai 5.2: thống kê, phân nhóm và tổng hợp trên List<MonHoc>.
    private static void Bai52()
    {
        TieuDe("Bài 5.2 - Thống kê trên List<MonHoc>");
        var ds = DuLieu.DS_Mon();
        Console.WriteLine($"a) Tổng số môn: {ds.Count}");
        Console.WriteLine($"b) Tên bắt đầu Lập trình: {ds.Count(m => m.TenMon.StartsWith("Lập trình", StringComparison.CurrentCulture))}");
        Console.WriteLine($"c) Tổng số tiết hệ KTV: {ds.Where(m => m.He == "KTV").Sum(m => m.SoTiet)}");
        Console.WriteLine("d) Tổng số môn theo hệ:");
        foreach (var g in ds.GroupBy(m => m.He))
        {
            Console.WriteLine($"   {(string.IsNullOrEmpty(g.Key) ? "(trống)" : g.Key)}: {g.Count()}");
        }
        Console.WriteLine("e) Nhóm theo số tiết:");
        foreach (var g in ds.GroupBy(m => m.SoTiet).OrderByDescending(g => g.Key))
        {
            Console.WriteLine($"   {g.Key} tiết: {g.Count()} môn");
        }
        var max = ds.Max(m => m.SoTiet); Console.WriteLine("f) Môn có số tiết cao nhất:"); InMon(ds.Where(m => m.SoTiet == max));
        Console.WriteLine("g) Thống kê theo hệ:");
        foreach (var g in ds.GroupBy(m => m.He))
        {
            Console.WriteLine($"   {g.Key,-3}: môn={g.Count()}, tổng tiết={g.Sum(m => m.SoTiet)}, max={g.Max(m => m.SoTiet)}, min={g.Min(m => m.SoTiet)}");
        }
        Console.WriteLine("h) Môn học phân nhóm theo hệ:");
        foreach (var g in ds.GroupBy(m => m.He))
        {
            Console.WriteLine($"   Hệ {(string.IsNullOrEmpty(g.Key) ? "(trống)" : g.Key)}");
            InMon(g.OrderBy(m => m.MaMon));
        }
        Console.WriteLine("i) Môn học phân nhóm theo số tiết, tăng dần:");
        foreach (var g in ds.GroupBy(m => m.SoTiet).OrderBy(g => g.Key))
        {
            Console.WriteLine($"   {g.Key} tiết");
            InMon(g.OrderBy(m => m.MaMon));
        }
        Console.WriteLine("j) Hệ KTV nhóm theo học phần HP2-HP5:");
        foreach (var g in ds
            .Where(m => m.He == "KTV")
            .GroupBy(m => m.MaMon.Split('_')[0])
            .OrderBy(g => g.Key))
        {
            Console.WriteLine($"   {g.Key}");
            InMon(g.OrderBy(m => m.MaMon));
        }
        Console.WriteLine("k) Theo hệ, chỉ lấy số tiết > 40:");
        foreach (var g in ds.Where(m => m.SoTiet > 40).GroupBy(m => m.He))
        {
            Console.WriteLine($"   Hệ {g.Key}");
            InMon(g.OrderBy(m => m.MaMon));
        }
    }

    // Bai 6.2: join, outer join, DefaultIfEmpty và đánh số trong nhóm.
    private static void Bai62()
    {
        TieuDe("Bài 6.2 - Join và các toán tử tập hợp");
        var mon = DuLieu.DS_Mon(); var he = DuLieu.DS_He();
        Console.WriteLine("a) Inner join: Tên hệ | Mã môn | Tên môn");
        var inner =
            from h in he
            join m in mon on h.MaHe equals m.He
            select new { h.TenHe, m.MaMon, m.TenMon };
        foreach (var x in inner)
        {
            Console.WriteLine($"   {x.TenHe} | {x.MaMon} | {x.TenMon}");
        }
        Console.WriteLine("b) Left outer join, gồm hệ chưa có môn:");
        var leftJoin = he
            .GroupJoin(mon, h => h.MaHe, m => m.He, (h, ms) => new { h, ms })
            .SelectMany(x => x.ms.DefaultIfEmpty(), (x, m) => new { x.h, m });
        foreach (var x in leftJoin)
        {
            Console.WriteLine($"   {x.h.TenHe} | {x.m?.MaMon ?? "(chưa có)"} | {x.m?.TenMon ?? "(chưa có)"}");
        }
        Console.WriteLine("c) Full outer join, gồm hệ và môn chưa khai báo:");
        var fullFromHe = he
            .GroupJoin(mon, h => h.MaHe, m => m.He, (h, ms) => new { h, ms })
            .SelectMany(x => x.ms.DefaultIfEmpty(), (x, m) => new
            {
                He = x.h.TenHe,
                Ma = m?.MaMon ?? "(chưa có)",
                Ten = m?.TenMon ?? "(chưa có)"
            });
        foreach (var x in fullFromHe)
        {
            Console.WriteLine($"   {x.He} | {x.Ma} | {x.Ten}");
        }
        foreach (var m in mon.Where(m => string.IsNullOrEmpty(m.He)))
        {
            Console.WriteLine($"   (chưa khai báo hệ) | {m.MaMon} | {m.TenMon}");
        }
        Console.WriteLine("d) Chỉ các hệ chưa có môn và môn chưa khai báo hệ:");
        foreach (var h in he.Where(h => !mon.Any(m => m.He == h.MaHe)))
        {
            Console.WriteLine($"   Hệ chưa có môn: {h.MaHe} - {h.TenHe}");
        }
        foreach (var m in mon.Where(m => string.IsNullOrEmpty(m.He)))
        {
            Console.WriteLine($"   Môn chưa khai báo hệ: {m.MaMon} - {m.TenMon}");
        }
        Console.WriteLine("e) 5 môn đầu tiên theo số tiết giảm dần:");
        var topFive =
            from m in mon.OrderByDescending(m => m.SoTiet).Take(5)
            join h in he on m.He equals h.MaHe into gj
            from h in gj.DefaultIfEmpty()
            select new
            {
                He = h?.TenHe ?? "(chưa khai báo)",
                m.MaMon,
                m.TenMon,
                m.SoTiet
            };
        foreach (var x in topFive)
        {
            Console.WriteLine($"   {x.He} | {x.MaMon} | {x.TenMon} | {x.SoTiet}");
        }
        Console.WriteLine("f) Tổng số môn mỗi hệ:");
        foreach (var h in he)
        {
            Console.WriteLine($"   {h.MaHe} | {h.TenHe} | {mon.Count(m => m.He == h.MaHe)}");
        }
        Console.WriteLine($"g) Số loại số tiết khác nhau: {mon.Select(m => m.SoTiet).Distinct().Count()}");
        var first = mon.FirstOrDefault(m =>
            m.TenMon.StartsWith("Lập trình", StringComparison.CurrentCulture));
        Console.WriteLine($"h) Môn đầu tiên bắt đầu Lập trình: {first?.MaMon} - {first?.TenMon}");
        Console.WriteLine("i) Môn theo từng hệ, đánh số trong nhóm:");
        foreach (var group in mon.GroupBy(m => m.He).OrderBy(g => g.Key))
        {
            Console.WriteLine($"   Hệ {(string.IsNullOrEmpty(group.Key) ? "(trống)" : group.Key)}");
            var numbered = group.OrderBy(m => m.MaMon)
                .Select((m, index) => new { m, STT = index + 1 });
            foreach (var item in numbered)
            {
                Console.WriteLine($"   {item.STT}. {item.m.MaMon} - {item.m.TenMon}");
            }
        }
    }
}