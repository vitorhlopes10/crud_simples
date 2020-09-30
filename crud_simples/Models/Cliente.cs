
using System.ComponentModel.DataAnnotations;

namespace crud_simples.Models
{
    public class Cliente
    {

        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }
    }
}
