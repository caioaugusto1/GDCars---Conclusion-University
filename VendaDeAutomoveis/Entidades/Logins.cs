using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaDeAutomoveis.Entidades
{
    public class Login
    {
        public Login()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [MaxLength(20, ErrorMessage = "Máximo permitido para o nome são 40 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        [MaxLength(20, ErrorMessage = "Máximo permitido para o nome são 20 caracteres.")]
        public string SobreNome { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        [MaxLength(30, ErrorMessage = "Máximo permitido para o e-mail são 30 caracteres.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O mínimo de {1} e o máximo de {0} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [NotMapped]
        [Display(Name = "Confirme a senha")]
        [Compare("Senha", ErrorMessage = "As senhas devem ser iguais.")]
        public string ConfirmarSenha { get; set; }

        [Required(ErrorMessage = "Informe qual é o perfil de acesso")]
        public NivelAcesso TipoAcesso { get; set; }

    }

    public enum NivelAcesso
    {
        [Display(Name = "Administrador")]
        Admin = 1,
        [Display(Name = "Ativo")]
        Usuario = 2,
        [Display(Name = "Bloqueado")]
        Bloqueado = 3
    }
}