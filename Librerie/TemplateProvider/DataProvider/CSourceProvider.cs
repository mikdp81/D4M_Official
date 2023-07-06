using System.Collections.Generic;

namespace Provider.Data
{
    public abstract class SourceProvider<T, Z> : DataProvider, ISourceProvider<T, Z>
    {
        public abstract List<T> Select();

        public abstract int SelectCount();

        public abstract List<T> SelectPaged(string sortColumns, int maximumRows, int startRowIndex);

        public abstract int SelectPagedCount(string filterParams);

        public abstract List<T> SelectPaged(string filterParams, string sortColumns, int maximumRows, int startRowIndex);

        public abstract int SelectPagedCount();

        public abstract T Detail(T value);

        public abstract T Detail(Z id);

        public abstract int Insert(T value);

        public abstract int Update(T value);

        public abstract int Update(T value, T old_value);

        public abstract int Delete(T value);

        public abstract int Delete(Z id);
    }
}
