using System;
using System.ComponentModel;
using System.Globalization;

namespace MultiDataConnection
{
    public abstract class BaseDataHelper
    {
        public static T IfDBNull<T>(object value, T returnValue)
        {
            try
            {
                if (value == null)
#pragma warning disable IDE0034 // Simplify 'default' expression
                    return default(T);
#pragma warning restore IDE0034 // Simplify 'default' expression
                if (Convert.IsDBNull(value))
                    return returnValue;
                else
                    return (T)value;
            }
            catch (Exception ex)
            {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                string message = ex.Message;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
                return default(T);
            }
        }

        public static object EnsureType(object value, Type targetType)
        {
            if (value == null)
                return (object)null;
            if (targetType == null)
                return value;
            Type type = value.GetType();
            if (type == targetType)
                return value;
            TypeConverter converter = TypeDescriptor.GetConverter(targetType);
            if (converter.CanConvertFrom(type))
                return converter.ConvertFrom((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, value);
            if (converter.CanConvertFrom(typeof(string)))
            {
                string text = TypeDescriptor.GetConverter(value).ConvertToInvariantString(value);
                return converter.ConvertFromInvariantString(text);
            }
            else if (!targetType.IsAssignableFrom(type))
                throw new InvalidOperationException(string.Format("Cannot convert object of type '{0}' to type '{1}'", (object)value.GetType(), (object)targetType));
            else
                return value;
        }

        public static string GetPagedString(string TableOrViewName, int PageSize, int SelectedPage, int PagesCount, int RecordsCount, string OrderColumn, string OrderDirection, string WhereClause)
        {
            string str1 = OrderDirection.ToLower() == "asc" ? "DESC" : "ASC";
            string str2 = OrderColumn + " " + OrderDirection;
            string str3 = OrderColumn + " " + str1;
            if (SelectedPage >= PagesCount)
            {
                int num = RecordsCount % PageSize;
                if (num <= 0)
                    num = PageSize;
                return "SELECT * FROM (SELECT TOP " + num.ToString() + " * FROM (SELECT TOP " + (PageSize * SelectedPage).ToString() + " * FROM " + TableOrViewName + " AS T1 WHERE " + WhereClause + " ORDER BY " + str2 + ") AS T2 ORDER BY " + str3 + ") AS T3 ORDER BY " + str2;
            }
            else
                return "SELECT * FROM (SELECT TOP " + PageSize.ToString() + " * FROM (SELECT TOP " + (PageSize * SelectedPage).ToString() + " * FROM " + TableOrViewName + " AS T1 WHERE " + WhereClause + " ORDER BY " + str2 + ") AS T2 ORDER BY " + str3 + ") AS T3 ORDER BY " + str2;
        }

        public static string GetPagedString(string TableOrViewName, int PageSize, int SelectedPage, int PagesCount, int RecordsCount, string OrderColumn, string OrderDirection)
        {
            return BaseDataHelper.GetPagedString(TableOrViewName, PageSize, SelectedPage, PagesCount, RecordsCount, OrderColumn, OrderDirection, "1 = 1");
        }

        public static string GetPagedString(string TableOrViewName, int PageSize, int SelectedPage, int PagesCount, int RecordsCount, string OrderColumn)
        {
            return BaseDataHelper.GetPagedString(TableOrViewName, PageSize, SelectedPage, PagesCount, RecordsCount, OrderColumn, "ASC");
        }

        public static string GetPagedStringWithKey(string TableOrViewName, int PageSize, int SelectedPage, int PagesCount, int RecordsCount, string OrderColumn, string OrderDirection, string WhereClause, string Key)
        {
            string str1 = OrderDirection.ToLower() == "asc" ? "DESC" : "ASC";
            string str2 = OrderColumn + " " + OrderDirection;
            string str3 = OrderColumn + " " + str1;
            if (!string.IsNullOrEmpty(Key) && Key.ToLower() != OrderColumn.ToLower())
            {
                str2 = str2 + "," + Key + " " + OrderDirection;
                str3 = str3 + "," + Key + " " + str1;
            }
            if (SelectedPage >= PagesCount)
            {
                int num = RecordsCount % PageSize;
                if (num <= 0)
                    num = PageSize;
                return "SELECT * FROM (SELECT TOP " + num.ToString() + " * FROM (SELECT TOP " + (PageSize * SelectedPage).ToString() + " * FROM " + TableOrViewName + " AS T1 WHERE " + WhereClause + " ORDER BY " + str2 + ") AS T2 ORDER BY " + str3 + ") AS T3 ORDER BY " + str2;
            }
            else
                return "SELECT * FROM (SELECT TOP " + PageSize.ToString() + " * FROM (SELECT TOP " + (PageSize * SelectedPage).ToString() + " * FROM " + TableOrViewName + " AS T1 WHERE " + WhereClause + " ORDER BY " + str2 + ") AS T2 ORDER BY " + str3 + ") AS T3 ORDER BY " + str2;
        }

        public static string GetPagedStringWithKey(string TableOrViewName, int PageSize, int SelectedPage, int PagesCount, int RecordsCount, string OrderColumn, string OrderDirection, string Key)
        {
            return BaseDataHelper.GetPagedStringWithKey(TableOrViewName, PageSize, SelectedPage, PagesCount, RecordsCount, OrderColumn, OrderDirection, "1 = 1", Key);
        }

        public static string GetPagedStringWithKey(string TableOrViewName, int PageSize, int SelectedPage, int PagesCount, int RecordsCount, string OrderColumn, string Key)
        {
            return BaseDataHelper.GetPagedStringWithKey(TableOrViewName, PageSize, SelectedPage, PagesCount, RecordsCount, OrderColumn, "ASC", Key);
        }

        public static int GetNumberOfPages(int NumberOfRecords, int PageSize)
        {
            return NumberOfRecords / PageSize + (NumberOfRecords % PageSize > 0 ? 1 : 0);
        }

        public static int GetSelectedPage(int startRowIndex, int PageSize)
        {
            return startRowIndex / PageSize + 1;
        }
    }
}
