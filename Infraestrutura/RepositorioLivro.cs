using Dominio;

namespace Infraestrutura
{
    public class RepositorioLivro : IRepositorioLivro
    {
        public RepositorioLivro(BancoDeDados bancoDeDados)
        {
            BancoDeDados = bancoDeDados;
        }

        public BancoDeDados BancoDeDados { get; }

        public void Salvar(Livro livro)
        {
            BancoDeDados.Livro.Add(livro);
            BancoDeDados.SaveChanges();
        }
    }
}
