using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaPrincipal
{
    internal class Program
    {
        // Lista para armazenar os produtos
        private static List<Produto> listaDeProdutos = new List<Produto>();

        static void Main(string[] args)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("*  Bem-vindo ao Estoque!  *");
            Console.WriteLine("***************************");

            while (true)
            {
                //Menu
                Console.WriteLine(@"
1. Adicionar Produto
2. Listar Produtos
3. Remover Produto
4. Sair");

                Console.WriteLine(); //Pular linha
                Console.Write("--> ");
                string escolhaUserInput = Console.ReadLine();
                int escolhaUser;

                // Verificar se a entrada do usuário é um número entre 1 e 4
                if (int.TryParse(escolhaUserInput, out escolhaUser) && escolhaUser < 5 && escolhaUser > 0)
                {
                    if (escolhaUser == 1)
                    {
                        AdicionarProduto();
                    }
                    else if (escolhaUser == 2)
                    {
                        ListarProdutos();
                    }
                    else if (escolhaUser == 3)
                    {
                        RemoverProduto();
                    }
                    else if (escolhaUser == 4)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número de 1 a 4.");
                }
            }
        }

        //Criando os Metodos
        // Adicionar um novo produto à lista
        private static void AdicionarProduto()
        {
            Console.WriteLine(); //Pular linha
            Console.WriteLine("Nome do novo produto: ");
            Console.Write("--> ");
            string nomeProdutoNovo = Console.ReadLine();

            Console.WriteLine(); //Pular linha
            Console.WriteLine("Quantidade do novo produto: ");
            Console.Write("--> ");
            string quantidadeProdutoNovo = Console.ReadLine();

            Console.WriteLine(); //Pular linha
            Console.WriteLine("Preço do novo produto: ");
            Console.Write("--> ");
            string precoProdutoNovo = Console.ReadLine();

            Produto novoProduto = new Produto
            {
                Nome = nomeProdutoNovo,
                Quantidade = quantidadeProdutoNovo,
                Preco = precoProdutoNovo
            };

            listaDeProdutos.Add(novoProduto);
        }

        // Listar todos os produtos na lista
        private static void ListarProdutos()
        {
            if (listaDeProdutos.Count == 0)
            {
                Console.WriteLine("O estoque não tem produtos ainda.");
            }
            else
            {
                Console.WriteLine("Quantidade de produtos: " + listaDeProdutos.Count);
                Console.WriteLine();
                foreach (var produto in listaDeProdutos)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Nome do Produto: " + produto.Nome);
                    Console.WriteLine("Quantidade do Produto: " + produto.Quantidade);
                    Console.WriteLine("Preço do Produto: R$" + produto.Preco);
                }
            }
        }

        // Remover um produto da lista
        private static void RemoverProduto()
        {
            if (!listaDeProdutos.Any())
            {
                Console.WriteLine("Não existe produtos para serem removidos.");
            }
            else
            {
                Console.WriteLine("Qual produto você deseja remover: ");
                Console.WriteLine(); //Pular linha
                for (int i = 0; i < listaDeProdutos.Count; i++)
                {
                    Console.WriteLine(i + ". " + listaDeProdutos[i].Nome);
                }
                Console.WriteLine("Ou presione ENTER para voltar.");
                Console.WriteLine(); //Pular linha
                Console.Write("--> ");
                string escolhaUserInput = Console.ReadLine();
                int escolhaUser;

                if (int.TryParse(escolhaUserInput, out escolhaUser))
                {
                    listaDeProdutos.Remove(listaDeProdutos[escolhaUser]);
                }
            }


        }
    }

    // Classe Produto <-- Precisei de ajuda para fazer essa parte
    internal class Produto
    {
        public string Nome { get; set; }
        public string Quantidade { get; set; }
        public string Preco { get; set; }
    }
}
