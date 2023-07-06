using System;

namespace MultiDataConnection
{
    [Serializable]
    public class ReturnValue<T> : IReturnValue<T>
    {
        private string _message = string.Empty;
        private T _data = default(T);
        private bool _error;

        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;
            }
        }

        public bool Error
        {
            get
            {
                return this._error;
            }
            set
            {
                this._error = value;
            }
        }

        public T Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }
    }
}
