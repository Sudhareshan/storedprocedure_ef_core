using System.ComponentModel.DataAnnotations;

namespace SP_EfCore.Models
{
    public class Employe
    {
        [Key]
        public int EmployeId { get; set; }
        public String Name { get;set; }
        public decimal Salary { get; set; }
    }
}
