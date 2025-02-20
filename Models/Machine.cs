using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CNCWebAPI.Models
{
    public class Machine
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal XSizeValue { get; set; }
        public decimal YSizeValue { get; set; }
        public decimal ZSizeValue { get; set; }
        public decimal XSpeedValue { get; set; }
        public decimal YSpeedValue { get; set; }
        public decimal ZSpeedValue { get; set; }
        
        public int ModelSelected {  get; set; }
    }

}
