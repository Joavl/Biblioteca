using Biblioteca;
namespace SistemaBiblioteca
{
    class Program
    {
        static void Main()
        {
            Livro livro = new Livro();
            Usuario usuario = new Usuario();
            int opcao = 0;

            while (true)
            {
                Console.WriteLine("==== SISTEMA DE BIBLIOTECA ====\n");
                Console.WriteLine("DIGITE A OPÇÃO DESEJADA:\n");
                Console.WriteLine("[1]-ADICIONAR LIVRO");
                Console.WriteLine("[2]-PESQUISAR LIVROS");
                Console.WriteLine("[3]-LISTAR LIVROS");
                Console.WriteLine("[4]-DELETAR LIVRO");
                Console.WriteLine("[5]-CADASTRAR USUÁRIO");
                Console.WriteLine("[6]-LISTAR USUÁRIOS");
                Console.WriteLine("[7]-DELETAR USUÁRIO");
                Console.WriteLine("[8]-EMPRESTAR LIVRO");
                Console.WriteLine("[9]-DEVOLVER LIVRO");
                Console.WriteLine("[0]-SAIR\n");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\nOPÇÃO INVÁLIDA. TENTE NOVAMENTE.\n");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        livro.CadastrarLivro();
                        break;

                    case 2:
                        livro.PesquisarLivro();
                        break;

                    case 3:
                        livro.ListarLivros();
                        break;

                    case 4:
                        livro.DeletarLivro();
                        break;

                    case 5:
                        usuario.CadastrarUsuario();
                        break;

                    case 6:
                        usuario.ListarUsuarios();
                        break;

                    case 7:
                        usuario.DeletarUsuario();
                        break;

                    case 8:
                        livro.EmprestarLivro();
                        break;

                    case 9:
                        livro.DevolverLivro();
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA. TENTE NOVAMENTE.\n");
                        break;
                }
            }
        }
    }
}
