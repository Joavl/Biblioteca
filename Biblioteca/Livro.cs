using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Livro
    {
        public int IdLivro { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string AnoPublicacao { get; set; }
        public bool Disponibilidade { get; set; } = true;
        public Usuario UsuarioLocador { get; set; }

        public static List<Livro> ListaLivros { get; set; } = new List<Livro>();

        public void CadastrarLivro()
        {
            Console.WriteLine("==== CADASTRO DE LIVROS ====\n");

            Console.Write("DIGITE O ID DO LIVRO: ");
            IdLivro = Convert.ToInt32(Console.ReadLine());

            Console.Write("DIGITE O NOME DO AUTOR: ");
            Autor = Console.ReadLine();

            Console.Write("DIGITE O TÍTULO DO LIVRO: ");
            Titulo = Console.ReadLine();

            Console.Write("DIGITE O ANO DE PUBLICAÇÃO: ");
            AnoPublicacao = Console.ReadLine();

            ListaLivros.Add(this);

            Console.WriteLine("\nLIVRO CADASTRADO COM SUCESSO!!!\n");
        }

        public void ListarLivros()
        {
            Console.WriteLine("==== LISTA DE LIVROS ====\n");

            foreach (var livro in ListaLivros)
            {
                ExibirDetalhesLivro(livro);
                Console.WriteLine("=======================\n");
            }

            if (ListaLivros.Count == 0)
            {
                Console.WriteLine("\nNENHUM LIVRO ENCONTRADO!!!\n");
            }
        }

        public void PesquisarLivro()
        {
            Console.WriteLine("==== PESQUISAR LIVRO POR ID ====\n");

            Console.Write("DIGITE O ID DO LIVRO: ");
            int idLivro = Convert.ToInt32(Console.ReadLine());

            Livro livroEncontrado = ListaLivros.FirstOrDefault(l => l.IdLivro == idLivro);

            if (livroEncontrado != null)
            {
                ExibirDetalhesLivro(livroEncontrado);
            }
            else
            {
                Console.WriteLine("\nLIVRO NÃO ENCONTRADO!!!\n");
            }
        }

        private void ExibirDetalhesLivro(Livro livro)
        {
            Console.Write($"ID: {livro.IdLivro}\n");
            Console.Write($"AUTOR: {livro.Autor}\n");
            Console.Write($"TÍTULO: {livro.Titulo}\n");
            Console.Write($"ANO DE PUBLICAÇÃO: {livro.AnoPublicacao}\n");
            Console.Write($"STATUS: {(livro.Disponibilidade ? "DISPONÍVEL" : "INDISPONÍVEL")}\n");
        }

        public void EmprestarLivro()
        {
            Console.WriteLine("==== EMPRÉSTIMO DE LIVRO ====\n");

            Console.Write("DIGITE O ID DO USUÁRIO: ");
            int idUsuario = Convert.ToInt32(Console.ReadLine());

            Console.Write("DIGITE O ID DO LIVRO: ");
            int idLivro = Convert.ToInt32(Console.ReadLine());

            Usuario usuarioLocador = Usuario.ListaUsuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            Livro livroEmprestado = ListaLivros.FirstOrDefault(l => l.IdLivro == idLivro);

            if (usuarioLocador == null || livroEmprestado == null)
            {
                Console.WriteLine("\nUSUÁRIO OU LIVRO NÃO ENCONTRADO!!!\n");
                return;
            }

            if (livroEmprestado.Disponibilidade)
            {
                livroEmprestado.Disponibilidade = false;
                livroEmprestado.UsuarioLocador = usuarioLocador;
                usuarioLocador.LivrosReservados.Add(livroEmprestado);
                Console.WriteLine("\nLIVRO EMPRESTADO COM SUCESSO!!!\n");
            }
            else
            {
                Console.WriteLine("\nLIVRO INDISPONÍVEL PARA EMPRÉSTIMO!!!\n");
            }
        }

        public void DevolverLivro()
        {
            Console.WriteLine("==== DEVOLUÇÃO DE LIVRO ====\n");

            Console.Write("DIGITE O ID DO LIVRO: ");
            int idLivro = Convert.ToInt32(Console.ReadLine());

            Livro livroDevolvido = ListaLivros.FirstOrDefault(l => l.IdLivro == idLivro);

            if (livroDevolvido != null && !livroDevolvido.Disponibilidade)
            {
                livroDevolvido.Disponibilidade = true;
                Usuario usuarioLocador = livroDevolvido.UsuarioLocador;

                if (usuarioLocador != null)
                {
                    usuarioLocador.LivrosReservados.Remove(livroDevolvido);
                    Console.WriteLine($"\nLIVRO DEVOLVIDO COM SUCESSO POR {usuarioLocador.Nome}!!!\n");
                }
            }
            else
            {
                Console.WriteLine("\nLIVRO NÃO ENCONTRADO OU NÃO ESTÁ EMPRESTADO!!!\n");
            }
        }


        public void DeletarLivro()
        {
            Console.WriteLine("==== EXCLUSÃO DE LIVRO ====\n");

            Console.Write("DIGITE O ID DO LIVRO: ");
            int idLivro = Convert.ToInt32(Console.ReadLine());

            Livro livroDeletado = ListaLivros.FirstOrDefault(l => l.IdLivro == idLivro);

            if (livroDeletado != null)
            {
                ListaLivros.Remove(livroDeletado);
                Console.WriteLine("\nLIVRO DELETADO COM SUCESSO!!!\n");
            }
            else
            {
                Console.WriteLine("\nLIVRO NÃO ENCONTRADO!!!\n");
            }
        }
    }
}
