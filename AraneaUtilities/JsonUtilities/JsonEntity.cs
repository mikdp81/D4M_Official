using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AraneaUtilities.JsonUtilities
{
    /// <summary>
    /// Classe astratta base per le entity che si inizializzano con un file JSON.
    /// </summary>
    /// <typeparam name="T">Tipo della classe derivata.</typeparam>
    public abstract class JsonEntity<T> where T : JsonEntity<T>
    {

        private static T _tInstance = null;

        /// <summary>
        /// Crea un'istanza VUOTA della classe derivata.
        /// </summary>
        public JsonEntity() : base() { }

        /// <summary>
        /// Crea un'istanza della classe usando un'entità JSON.
        /// </summary>
        /// <param name="json">L'entità JSON da deserializzare.</param>
        public JsonEntity(string json)
        {
            try
            {
                JsonConvert.PopulateObject(json, (T)this);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Si è verificata un'eccezione durante la deserializzazione dell'entità nella classe: " + typeof(T).Name);
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            Initialize();
        }

        /// <summary>
        /// Crea un'istanza della classe derivata VUOTA.
        /// </summary>
        /// <returns>Un'istanza della classe derivata.</returns>
        public static T CreateInstance()
        {
            _tInstance = (T)Activator.CreateInstance(typeof(T), nonPublic: true);

            // aggiungo settaggi extra della classe derivata
            _tInstance.Initialize();

            return _tInstance;
        }


        /// <summary>
        /// Crea un'istanza della classe derivata usando un'entità JSON.
        /// </summary>
        /// <param name="json">L'entità JSON da deserializzare.</param>
        /// <returns>Un'istanza della classe derivata.</returns>
        public static T CreateInstance(string json)
        {
            try
            {
                _tInstance = JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonException ex)
            {
                // Gestione dell'eccezione
                Console.WriteLine("Si è verificata un'eccezione durante la deserializzazione dell'entità nella classe: " + typeof(T).Name);
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            
            // aggiungo settaggi extra della classe derivata
            _tInstance.Initialize();

            return _tInstance;
        }


        /// <summary>
        /// Restituisce l'istanza già presente.
        /// </summary>
        /// <returns>Un'istanza della classe derivata.</returns>
        public static T GetInstance()
        {
            // Se non c'è già un'istanza
            if (_tInstance == null)
                _tInstance = CreateInstance();

            return _tInstance;
        }


        /// <summary>
        /// Crea un'istanza della classe derivata usando un'entità JSON.
        /// </summary>
        /// <param name="jsonEntity">L'entità JSON da deserializzare.</param>
        /// <returns>Un'istanza della classe derivata.</returns>
        public static T GetInstance(string json)
        {
            if (_tInstance == null)
                _tInstance = CreateInstance(json);

            return _tInstance;
        }


        /// <summary>
        /// Metodo astratto che deve essere implementato nella classe derivata per l'inizializzazione.
        /// </summary>
        protected abstract void Initialize();
    }
}
