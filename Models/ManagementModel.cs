using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBusinessManagement.Models
{
    public class ManagementModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100, MinimumLength=3, ErrorMessage ="Nome deve ter entre 3 e 100 caracteres")]
        public string Name { get; set; }
        
        //TO DO: fk departament
        //[ForeignKey("Department")]
        //public int DepartmentId { get; set; }
        //public virtual DepartmentModel Department { get; set; }


        [Display(Name="Cargo")]
        [Required(ErrorMessage = "O campo Setor é obrigatório")]
        public string Role { get; set; }
        
        [Required(ErrorMessage = "O campo Salário é obrigatório")]
        [Display(Name="Salário")]
        [Range(1 , double.MaxValue , ErrorMessage ="Valor inválido")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}