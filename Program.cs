using System;

namespace Projeto_Cadastro
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio(); 
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write(" Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorio.RetornaPorId(indiceSerie).ToString());
        }
        private static void ExcluirSerie()
        {
            Console.Write(" Digite o ID da série a ser excluida: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        private static void AtualizarSerie()
        {
            Console.Write(" Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o Gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(indiceSerie,(Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Atualiza(indiceSerie, atualizarSerie);
        }
        private static void InserirSerie()
        {
            Console.WriteLine("== Inserir nova série == ");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o Gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(),(Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Insere(novaSerie); 

        }
        private static void ListarSeries()
        {
            Console.WriteLine("== Listar Séries ==");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine(" Nenhuma série cadastrada. ");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(excluido)
                {
                   Console.WriteLine("#ID {0} EXCLUIDA: - {1}", serie.retornaId(), serie.retornaTitulo()); 
                }
                else
                {
                    Console.WriteLine("#ID {0} : - {1}", serie.retornaId(), serie.retornaTitulo()); 
                }
                
            }
            return;
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" ===== Banco de Séries =====");
            Console.WriteLine();
            Console.WriteLine(" 1 - Lista séries");
            Console.WriteLine(" 2 - Inserir nova série");
            Console.WriteLine(" 3 - Atualizar série");
            Console.WriteLine(" 4 - Excluir série");
            Console.WriteLine(" 5 - Visualizar série");
            Console.WriteLine(" C - Limpar tela");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;    
        }
    }
}
