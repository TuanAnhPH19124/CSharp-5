namespace CSharp5.Models
{
    public class DiaChi
    {
        public int Id { get; set; }
        public string diachi { get; set; }
        public int Id_Nguoidung { get; set; }
        public NguoiDung nguoiDung { get; set; }
    }
}
