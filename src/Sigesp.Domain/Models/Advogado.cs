namespace Sigesp.Domain.Models
{
    public class Advogado : EntityAudit
    {
        public Advogado(string nome, string email,
                        string oab, bool isDefensorPublico)
        {
            Nome = nome;
            Email = email;
            Oab = oab;
            IsDefensorPublico = isDefensorPublico;
        }

        // Contructor empty to EFCore
        public Advogado() {}

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Oab { get; set; }
        public bool IsDefensorPublico { get; set; }
    } 
}