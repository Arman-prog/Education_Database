using Education_Database.Attributes;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Education_Database
{
    public static class SqlDataReaderExtension
    {
        public static T SqlToModel<T>(this SqlDataReader dataReader) where T : new()
        {
            Type type = typeof(T);

            var members = type
                .GetProperties()
                .Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null)
                .ToList();

            var source = new T();
            if (dataReader.HasRows)
            {
                for (int i = 0; i < members.Count; i++)
                {
                    if (members[i].GetCustomAttribute<DateAttribute>() != null)
                    {
                        if (DateTime.TryParse(dataReader.GetValue(i).ToString(), out DateTime date))
                        {
                            members[i].SetValue(source, date);
                        }
                    }
                    else
                    {
                        if (!dataReader.IsDBNull(i))
                        {
                            members[i].SetValue(source, dataReader.GetValue(i));
                        }
                    }

                }
            }
            return source;
        }


    }
}
