using System;
using System.Data;

namespace CandidateEval.Models
{
    public static class IDataReaderExtensions
    {
        public static T GetValue<T>(this IDataReader dataReader, string name)
        {
            object value = dataReader[name];

            if (value == DBNull.Value)
            {
                if (Nullable.GetUnderlyingType(typeof(T)) == null && typeof(T).IsValueType)
                {
                    throw new InvalidCastException();
                }

                return default(T);
            }

            return (T)value;
        }
    }
}