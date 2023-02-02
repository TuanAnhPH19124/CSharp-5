using System.Collections.Generic;

namespace CSharp5.Models
{
    public class Mau
    {
        public int Id { get; set; }
        public string MaHex { get; set; }
        public string MaRGB { get; set; }

        public List<SPCT_Mau> sPCT_Maus { get; set; }
    }
}
