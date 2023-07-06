// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="BinaryHelper.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BusinessObject
{
    internal static class BinaryHelper
    {
        internal static void SerializeBinaryData<T>(this T data, out byte[] result)
        {
            result = null;
            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, data);
                result = stream.ToArray();
            }
        }

        internal static void DeserializeBinaryData<T>(this byte[] data, out T result)
        {
#pragma warning disable IDE0034 // Simplify 'default' expression
            result = default(T);
#pragma warning restore IDE0034 // Simplify 'default' expression
            using (MemoryStream stream = new MemoryStream(data))
            {
                result = (T)new BinaryFormatter().Deserialize(stream);
            }
        }

    }
}
