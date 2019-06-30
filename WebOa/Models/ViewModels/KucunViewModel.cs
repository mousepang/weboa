using System.ComponentModel.DataAnnotations;

namespace WebOa.Models
{
    public class KucunViewModel
    {
        public int id { get; set; }
        [Display(Name = "大区")]
        public string dataServer { get; set; }
        [Display(Name = "服务器")]
        public string server { get; set; }
        [Display(Name = "转移库存")]
        public int oldGil { get; set; }
        [Display(Name = "实时库存")]
        public int nowGil { get; set; }
        [Display(Name = "总库存")]
        public int totalGil { get; set; }
        [Display(Name = "更新时间")]
        public string updataTime { get; set; }
    }
}
