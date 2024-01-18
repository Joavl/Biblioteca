using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int IdUsuario { get; set; }
        public List<Livro> LivrosReservados { get; set; } = new List<Livro>();

        public static List<Usuario> ListaUsuarios { get; set; } = new List<Usuario>();

        public void CadastrarUsuario()
        {
            Console.WriteLine("==== CADASTRO DE USUÁRIOS ====\n");

            Console.Write("DIGITE O ID DO USUÁRIO: ");
            IdUsuario = Convert.ToInt32(Console.ReadLine());

            Console.Write("DIGITE O NOME DO USUÁRIO: ");
            Nome = Console.ReadLine();

            Console.Write("DIGITE O CPF DO USUÁRIO: ");
            CPF = Console.ReadLine();

            Console.Write("DIGITE O TELEFONE DO USUÁRIO: ");
            Telefone = Console.ReadLine();

            ListaUsuarios.Add(this);

            Console.WriteLine("\nUSUÁRIO CADASTRADO COM SUCESSO!!!\n");
        }

        public void ListarUsuarios()
        {
            Console.WriteLine("==== LISTA DE USUÁRIOS ====\n");

            foreach (var usuario in ListaUsuarios)
            {
                ExibirDetalhesUsuario(usuario);
                Console.WriteLine("=======================\n");
            }

            if (ListaUsuarios.Count == 0)
            {
                Console.WriteLine("\nNENHUM USUÁRIO ENCONTRADO!!!\n");
            }
        }

        public void DeletarUsuario()
        {
            Console.WriteLine("DIGITE O ID DO USUÁRIO:\n");
            int idUsuario = Convert.ToInt32(Console.ReadLine());

            var usuarioDeletado = ListaUsuarios.RemoveAll(u => u.IdUsuario == idUsuario);

            if (usuarioDeletado != 0)
            {
                Console.WriteLine("\nUSUÁRIO DELETADO COM SUCESSO!!!\n");
            }
            else
            {
                Console.WriteLine("\nUSUÁRIO NÃO ENCONTRADO!!!\n");
            }
        }

        private static void ExibirDetalhesUsuario(Usuario usuario)
        {
            Console.Write($"ID : {usuario.IdUsuario}\n");
            Console.Write($"NOME : {usuario.Nome}\n");
            Console.Write($"CPF : {usuario.CPF}\n");
            Console.Write($"TELEFONE : {usuario.Telefone}\n");
        }
    }
}
