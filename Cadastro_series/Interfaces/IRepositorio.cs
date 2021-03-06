using System.Collections.Generic;

namespace Cadastro_series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Rep();
        T RetornaPorId(int id);

        void Insere(T entidade);

        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}