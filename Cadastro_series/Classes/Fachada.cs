using Cadastro_series.Enum;

namespace Cadastro_series.Classes
{
#pragma warning disable CS8600
#pragma warning disable CS8604
    public class Fachada
    {

        SeriesRepositorio rep;
        public Fachada(SeriesRepositorio repositorio)
        {
            this.rep = repositorio;
        }


        public void Listar()
        {
            var lista = this.rep.Rep().Where(x => x.Excluido == false);

            if (lista.Count() > 0)
            {
                System.Console.WriteLine("Séries Listadas: ");
                foreach (Serie item in lista)
                {
                    System.Console.WriteLine("Id: " + item.Id + " - Título: " + item.Titulo);
                }
            }
            else
            {
                System.Console.WriteLine("lista vazia !");
            }
        }

        public void Inserir()
        {
            try
            {
                string titulo = "", descricao = "";
                int ano;

                var myEnumMemberCount = Enum.Genero.GetNames(typeof(Genero)).Length;

                System.Console.WriteLine("digite o Título da série:");

                titulo = System.Console.ReadLine();


                System.Console.WriteLine("Escolha o valor correspondente ao gênero da série: ");

                for (int i = 1; i < myEnumMemberCount; i++)
                {
                    System.Console.WriteLine($"{i} - {(Genero)i}");
                }

                int genero = int.Parse(System.Console.ReadLine());

                while (descricao == string.Empty)
                {
                    System.Console.WriteLine("coloque a descricao da série:");

                    descricao = System.Console.ReadLine();

                }

                System.Console.WriteLine("insira o ano da série:");
                ano = int.Parse(System.Console.ReadLine());
                int nota = -1;
                while (nota < 0 || nota > 10)
                {
                    System.Console.WriteLine("Avalie a série com uma nota entre 0~10");
                    nota = int.Parse(System.Console.ReadLine());
                }

                Serie serie = new Serie(this.rep.ProximoId(), (Genero)genero, titulo, descricao, ano, nota);

                this.rep.Insere(serie);
                System.Console.WriteLine("Série inserida !");
            }
            catch (Exception e)
            {
                var msg = e.Message;
                System.Console.WriteLine("Erro ao inserir novo cadastro de série");
            }
        }


        public void Excluir()
        {
            try
            {
                int id;
                System.Console.WriteLine("digite o Id da série que deseja excluir:");
                id = int.Parse(System.Console.ReadLine());


                this.rep.Exclui(id);
                System.Console.WriteLine("Série Excluída!");
            }
            catch (Exception e)
            {
                var msg = e.Message;
                System.Console.WriteLine("Erro na exclusão !!");
            }

        }

        public void ExibirSerie()
        {
            try
            {
                int id;
                System.Console.WriteLine("digite o valor de Id da série que deseja exibir:");
                id = int.Parse(System.Console.ReadLine());


                if (this.rep.RetornaPorId(id).Excluido == false || id < this.rep.Rep().Count)
                {
                    string serie = this.rep.RetornaPorId(id).ToString();
                    System.Console.WriteLine(serie);
                }
                else
                {
                    System.Console.WriteLine("Id inválido !!");
                }
            }
            catch (Exception e)
            {
                var msg = e.Message;
                System.Console.WriteLine("Erro ao exibir série!!!");
            }


        }

        public void Atualizar()
        {
            try
            {
                string titulo = "", descricao = "";
                int ano, id;
                var myEnumMemberCount = Enum.Genero.GetNames(typeof(Genero)).Length;


                System.Console.WriteLine("digite o Título da série:");

                titulo = System.Console.ReadLine();

                for (int i = 1; i < myEnumMemberCount; i++)
                {
                    System.Console.WriteLine($"{i} - {(Genero)i}");
                }

                int genero = int.Parse(System.Console.ReadLine());


                while (descricao == string.Empty)
                {
                    System.Console.WriteLine("coloque a descricao da série:");
                    descricao = System.Console.ReadLine();
                }

                System.Console.WriteLine("insira o ano da série:");
                ano = int.Parse(System.Console.ReadLine());

                int nota = -1;
                while (nota < 0 || nota > 10)
                {
                    System.Console.WriteLine("Avalie a série com uma nota entre 0~10");
                    nota = int.Parse(System.Console.ReadLine());
                }

                Serie serie = new Serie(this.rep.ProximoId(), (Genero)genero, titulo, descricao, ano, nota);

                System.Console.WriteLine("insira o valor do Id da série a ser atualizada");
                id = int.Parse(System.Console.ReadLine());


                this.rep.Atualiza(id, serie);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                System.Console.WriteLine("Erro na Atualização");
            }
        }

        public void ExibirPorNota()
        {
            try
            {
                if (this.rep.Rep().Count > 0)
                {
                    System.Console.WriteLine("1 - Exibir as séries melhor Avaliadas");
                    System.Console.WriteLine("2 - Exibir as séries pior avaliadas");

                    int opcao = int.Parse(System.Console.ReadLine());


                    switch (opcao)
                    {
                        case 1:
                            var lista = this.rep.Rep().Where(x => x.Nota > 7);

                            foreach (Serie item in lista)
                            {
                                System.Console.WriteLine($"Id: {item.Id} - Título: {item.Titulo} - Nota: {item.Nota}");
                            }
                            break;

                        case 2:
                            var lista2 = this.rep.Rep().Where(x => x.Nota < 3);

                            foreach (Serie item in lista2)
                            {
                                System.Console.WriteLine($"Id: {item.Id} - Título: {item.Titulo} - Nota: {item.Nota}");
                            }
                            break;

                        default:
                            System.Console.WriteLine("opção inválida");
                            break;
                    }
                }
                else
                {
                    System.Console.WriteLine("Lista vazia!!");
                }

            }
            catch (Exception e)
            {
                var msg = e.Message;
                System.Console.WriteLine("Erro ao exibir!!");
            }

        }




        public void ExibirPorGenero()
        {
            try
            {
                if (this.rep.Rep().Count() > 0)
                {
                    var myEnumMemberCount = Enum.Genero.GetNames(typeof(Genero)).Length;
                    int opcao = 0;

                    System.Console.WriteLine("Escolha entre os Gêneros disponíveis:");
                    for (int i = 1; i < myEnumMemberCount; i++)
                    {
                        System.Console.WriteLine($"{i} - {(Genero)i}");
                    }

                    while (opcao == 0 || opcao > myEnumMemberCount || opcao < 1)
                    {
                        System.Console.WriteLine("digite uma opção válida:");
                        opcao = int.Parse(Console.ReadLine());
                    }

                    var lista = this.rep.Rep().Where(x => x.Excluido == false || x.Genero == (Genero)opcao);

                    if (lista.Count() > 0)
                    {
                        foreach (Serie item in lista)
                        {
                            System.Console.WriteLine($"Id: {item.Titulo} - Título: {item.Titulo}");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Não existem séries desse gênero!!");
                    }

                }
                else
                {
                    System.Console.WriteLine("lista de séries vazia !!");
                }

            }
            catch (Exception e)
            {
                var msg = e.Message;
                System.Console.WriteLine("Erro ao listar as séries!!");
            }

        }




    }
}