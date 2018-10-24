using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testCurr.Models
{
    public class DovizKuru
    {   [Key]
        public int DK_ID  { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public float Buying { get; set; }

        [DisplayFormat(DataFormatString = "{4,2}")]
        public float Selling { get; set; }
        public DateTime Dtime { get; set; }
        

    }
}
