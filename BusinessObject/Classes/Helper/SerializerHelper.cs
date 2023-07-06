// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="SerializerHelper.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BusinessObject
{
    public static class SerializerHelper
    {
        public static string _stringEmpty = string.Empty;

        public static void SerializeListTo<T>(this List<T> list, out DataTable data, string tableName) where T : class
        {
            data = new DataTable(tableName);
            try
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    data.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                object[] values = new object[props.Count];
                foreach (T item in list)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item) ?? DBNull.Value;
                    }
                    data.Rows.Add(values);
                }
            }
            catch(NoNullAllowedException)
            {
                data = null;
            }
        }

        public static void SerializeArrayObjectTo(this object[] list, out string jsonData)
        {
            try { jsonData = JsonConvert.SerializeObject(list); }
            catch(JsonSerializationException) { jsonData = _stringEmpty; }
        }

        public static void SerializeObjectTo(this object item, out string jsonData)
        {
            try { jsonData = JsonConvert.SerializeObject(item); }
            catch(JsonSerializationException) { jsonData = _stringEmpty; }
        }

        public static void SerializeArrayGenericTo<T>(this T[] list, out string jsonData)
        {
            try { jsonData = JsonConvert.SerializeObject(list); }
            catch(JsonSerializationException) { jsonData = _stringEmpty; }
        }

        public static void SerializeGenericTo<T>(this T item, out string jsonData) where T : class
        {
            try { jsonData = JsonConvert.SerializeObject(item); }
            catch(JsonSerializationException) { jsonData = _stringEmpty; }
        }

        public static void SerializeListTo<T>(this List<T> list, out string jsonData) where T : class
        {
            try { jsonData = JsonConvert.SerializeObject(list); }
            catch(JsonSerializationException) { jsonData = _stringEmpty; }
        }

        public static void SerializeListTo<T>(this List<T> value, out MemoryStream xmlData) where T : class
        {
            xmlData = null;
            if (value == null)
            {
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T[]));
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Encoding = new UnicodeEncoding(false, false),
                    Indent = false,
                    OmitXmlDeclaration = false
                };
                xmlData = new MemoryStream();
                using (StreamWriter streamWriter = new StreamWriter(xmlData))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, value.ToArray());
                    }
                }
            }
            catch (XmlException)
            {
                xmlData = null;
            }
        }

        public static void DeserializeJsonTo<T>(this Stream stream, out List<T> value) where T : class
        {
            value = null;
            if (stream == null)
            {
                return;
            }

            try
            {
                using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    value = new List<T>((T[])JsonConvert.DeserializeObject<T[]>(streamReader.ReadToEnd()));
                }
            }
            catch(IOException)
            {
                value = null;
            }

        }

        public static void DeserializeXmlTo<T>(this Stream stream, out List<T> value) where T : class
        {
            value = null;
            if (stream == null)
            {
                return;
            }

            try
            {
                value = new List<T>();
                XmlSerializer serializer = new XmlSerializer(typeof(T[]));
                using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    value.AddRange((T[])serializer.Deserialize(streamReader));
                }
            }
            catch(XmlException)
            {
                value = null;
            }

        }

    }
}
