using Cadastro_series.Enum;

namespace Cadastro_series.Classes
{
    public class Serie : EntidadeBase
    {
        public Genero Genero { get; protected set; }
        public string Titulo { get; protected set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }
        public bool Excluido { get; set; }

        public double Nota { get; set; }


        public Serie(int id, Genero genero, string titulo, string descricao, int ano, int nota)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
            this.Nota = nota;
        }


        public override string ToString()
        {
            string retorno = "";
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Nota: " + this.Nota + Environment.NewLine;
            return retorno;
        }



    }
}