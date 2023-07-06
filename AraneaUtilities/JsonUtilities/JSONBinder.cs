using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AraneaUtilities.JsonUtilities
{

    /// <summary>
    /// Classe generica per la gestione della serializzazione e deserializzazione di oggetti JSON.
    /// </summary>
    /// <typeparam name="ConcreteClass">Tipo di classe concreta che estende il tipo di parente</typeparam>
    /// <typeparam name="ParentType">Tipo di classe padre o interfaccia</typeparam>
    public class JsonBinder<ConcreteClass, ParentType> : JsonConverter<ParentType> where ConcreteClass : ParentType
    {
        /// <summary>
        /// Ottiene un valore che indica se l'oggetto può essere letto come JSON.
        /// </summary>
        public override bool CanRead => true;

        /// <summary>
        /// Ottiene un valore che indica se l'oggetto può essere scritto come JSON.
        /// </summary>
        public override bool CanWrite => true;

        /// <summary>
        /// Legge l'oggetto JSON da un lettore JSON e lo deserializza nel tipo di oggetto concreto.
        /// </summary>
        /// <param name="reader">Lettore JSON</param>
        /// <param name="objectType">Tipo di oggetto</param>
        /// <param name="existingValue">Valore esistente</param>
        /// <param name="hasExistingValue">Indica se esiste un valore esistente</param>
        /// <param name="serializer">Serializer JSON</param>
        /// <returns>Un'istanza del tipo di classe concreta deserializzata dall'oggetto JSON</returns>
        public override ParentType ReadJson(JsonReader reader, Type objectType, ParentType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            // Esegui la deserializzazione dell'oggetto JSON nel tipo concreto
            ConcreteClass instance = Activator.CreateInstance<ConcreteClass>();

            serializer.Populate(jsonObject.CreateReader(), instance);

            return instance;
        }

        /// <summary>
        /// Scrive l'oggetto specificato come JSON.
        /// </summary>
        /// <param name="writer">Scrittore JSON</param>
        /// <param name="value">Valore da scrivere</param>
        /// <param name="serializer">Serializer JSON</param>
        public override void WriteJson(JsonWriter writer, ParentType value, JsonSerializer serializer)
        {
            writer.Formatting = Formatting.None;
            writer.WriteStartObject();

            PropertyInfo[] properties = typeof(ParentType).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var propertyValue = property.GetValue(value);
                var propertyName = property.Name.ToLowerInvariant();

                writer.WritePropertyName(propertyName);
                serializer.Serialize(writer, propertyValue);
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Converte l'oggetto di input in un JObject.
        /// </summary>
        /// <typeparam name="Type">Tipo dell'oggetto da convertire</typeparam>
        /// <param name="objectToConvert">Oggetto da convertire</param>
        /// <returns>Oggetto JObject</returns>
        public JObject GetJObject<Type>(Type objectToConvert) where Type : ParentType
        {
            var stringWriter = new StringWriter();
            var jsonWriter = new JsonTextWriter(stringWriter)
            {
                Formatting = Formatting.Indented // Indenta il risultato nello stile JSON
            };

            this.WriteJson(jsonWriter, objectToConvert, new JsonSerializer());

            return JObject.Parse(stringWriter.ToString());
        }


        /// <summary>
        /// Converte una collezione di oggetti in una lista di JObject.
        /// </summary>
        /// <typeparam name="T">Il tipo degli oggetti da convertire. Deve essere una sottoclasse di ParentType.</typeparam>
        /// <param name="objectsToConvert">La collezione di oggetti da convertire.</param>
        /// <returns>Una lista di JObject corrispondenti agli oggetti convertiti.</returns>
        public List<JObject> GetJObjectList<T>(IEnumerable<T> objectsToConvert) where T : ParentType
        {
            List<JObject> jsonObjects = new List<JObject>();

            foreach (T obj in objectsToConvert)
            {
                JObject jsonObject = GetJObject(obj);
                jsonObjects.Add(jsonObject);
            }

            return jsonObjects;
        }
    }
}
