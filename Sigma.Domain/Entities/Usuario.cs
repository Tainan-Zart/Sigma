namespace Sigma.Domain.Entities
{
    public class Usuario
    { 
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
         
        public List<Projeto> Projetos { get; set; }
    } 
}
