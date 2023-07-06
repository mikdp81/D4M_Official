using System.Collections.Generic;

namespace Provider.Data
{
    public interface ISourceProvider<T, Z>
    {
        List<T> Select();

        int SelectCount();

        List<T> SelectPaged(string sortColumns, int maximumRows, int startRowIndex);

        int SelectPagedCount();

        List<T> SelectPaged(string filterParams, string sortColumns, int maximumRows, int startRowIndex);

        int SelectPagedCount(string filterParams);

        T Detail(T value);

        T Detail(Z id);

        int Insert(T value);

        int Update(T value);

        int Update(T value, T old_value);

        int Delete(T value);

        int Delete(Z id);
    }
}