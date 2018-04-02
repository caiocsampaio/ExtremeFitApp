using System.ComponentModel.DataAnnotations;

namespace ExtremeFit.Repository.DTOs
{
    public class UsuarioDto
    {
        [Required(ErrorMessage="O nome de usuário (email) deve ser fornecido")]
        public string Email { get; set; }

        [Required(ErrorMessage="A senha deve ser fornecida")]
        public string Senha { get; set; }
        public string Rfid { get; set; }
        public string Digital { get; set; }
    }
}