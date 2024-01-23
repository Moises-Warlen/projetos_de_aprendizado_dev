using System.ComponentModel.DataAnnotations;

namespace EmprestimosSMN.Models
{
    public class EmprestimoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do funcionario")]
        public string NomeFuncionario { get; set; }


        [Required(ErrorMessage = "Digite o nome do fornecedor")]
        public string Fornecedor { get; set; }


        [Required(ErrorMessage = "Digite o nome do Material")]
        public string MaterialEmprestado { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;


    }
}
