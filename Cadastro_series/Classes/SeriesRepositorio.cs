using Cadastro_series.Interfaces;

namespace Cadastro_series.Classes
{
    public class SeriesRepositorio : IRepositorio<Serie>
    {
        private List<Serie> RepSeries = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            RepSeries[id] = entidade;
        }

        public void Exclui(int id)
        {
            RepSeries[id].Excluido = true;
        }

        public void Insere(Serie entidade)
        {
            RepSeries.Add(entidade);
        }

        public int ProximoId()
        {
            return this.RepSeries.Count;
        }

        public List<Serie> Rep()
        {
            return this.RepSeries;
        }


        public Serie RetornaPorId(int id)
        {
            return RepSeries[id];
        }
    }
}