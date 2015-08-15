

namespace Tier.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Linq.Mapping;
    using System.Globalization;
    using System.Reflection;


    public static class CastObjetos
    {

        /// <summary>
        /// Current Type.
        /// </summary>
        private static Type currentType;

        /// <summary>
        /// Properties to columns names.
        /// </summary>
        private static Dictionary<MemberInfo, string> propertiesToColumnsNames;

        /// <summary>
        /// Gets or sets a value indicating whether of Work With Inhered Members.
        /// </summary>
        public static bool WorkWithInheredMembers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Tipo generico de dato</typeparam>
        /// <param name="reader">Reader que se ha de mapear</param>
        /// <returns>Retorna la lista mapeada del datatable</returns>
        public static IEnumerable<T> IDataReaderToList<T>(IDataReader data)
        {
            using (DataTable tabla = new DataTable())
            {
                tabla.Load(data);
                return MappingFromDataTable<T>(tabla);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Tipo generico de dato</typeparam>
        /// <param name="data">Reader que se ha de mapear</param>
        /// <returns>Retorna la lista del tipo T mapeada del datatable</returns>
        public static IEnumerable<T> DataTableToList<T>(DataTable data)
        {
            return MappingFromDataTable<T>(data);
        }

        /// <summary>
        /// Metodo que permite el mapeo de un datatable a un list
        /// </summary>
        /// <typeparam name="T">Tipo generico de dato</typeparam>
        /// <param name="data">Datatable que se ha de mapear</param>
        /// <returns>Retorna la lista mapeada del datatable</returns>
        private static IEnumerable<T> MappingFromDataTable<T>(DataTable data)
        {
            Type newType = typeof(T);

            if (currentType != newType)
            {
                currentType = newType;
                FindColumnNames(currentType);
            }

            List<T> returnList = new List<T>();

            foreach (DataRow dr in data.Rows)
            {
                T objTarget = Activator.CreateInstance<T>();

                foreach (MemberInfo member in propertiesToColumnsNames.Keys)
                {
                    string columnName = propertiesToColumnsNames[member];

                    if (data.Columns.Contains(columnName))
                    {
                        PropertyInfo infoMember = (PropertyInfo)member;
                        object value = ConvertValueToType(dr[columnName], infoMember.PropertyType);
                        infoMember.SetValue(objTarget, value, null);
                    }
                }

                returnList.Add(objTarget);
            }

            return returnList;
        }

        /// <summary>
        /// De un tipo de dato obtiene los miembros y los guarda en un diccionario
        /// </summary>
        /// <param name="type">Tipo de dato del que se obtendran los miembros</param>
        private static void FindColumnNames(Type type)
        {
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            if (!WorkWithInheredMembers)
            {
                bindingFlags = bindingFlags | BindingFlags.DeclaredOnly;
            }

            propertiesToColumnsNames = new Dictionary<MemberInfo, string>();
            type.FindMembers(MemberTypes.Property, bindingFlags, DelegateToSearchCriteria, null);
        }

        /// <summary>
        /// Recorre los miembros de un tipo y los agrega al diccionario
        /// </summary>
        /// <param name="objMemberInfo">Miembro del tipo de dato</param>
        /// <param name="objSearch">Parametro objSearch</param>
        /// <returns>Retorna verdadero o falso segun haya agregado un miembro al diccionario</returns>
        private static bool DelegateToSearchCriteria(MemberInfo objMemberInfo, object objSearch)
        {
            object[] attributes = objMemberInfo.GetCustomAttributes(typeof(ColumnAttribute), WorkWithInheredMembers);
            if (attributes.Length > 0)
            {
                ColumnAttribute itemInfo = (ColumnAttribute)attributes[0];

                if (!propertiesToColumnsNames.ContainsKey(objMemberInfo))
                {
                    propertiesToColumnsNames.Add(objMemberInfo, itemInfo.Name);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Implementa el metodo que convierte un valor a un tipo de dato
        /// </summary>
        /// <param name="value">Valor que se convertira</param>
        /// <param name="targetType">Tipo de dato destino</param>
        /// <returns>Retorna el valor ingresado formateado al tipo de dato indicado</returns>
        private static object ConvertValueToType(object value, Type targetType)
        {
            return ConvertValueToType(value, targetType, true);
        }

        /// <summary>
        /// Convierte un valor a un tipo de dato
        /// </summary>
        /// <param name="value">Valor que se convertira</param>
        /// <param name="targetType">Tipo de dato destino</param>
        /// <param name="useOracleCharBoolean">Booleano que identifica si se esta convirtiendo un char a un bool</param>
        /// <returns>Retorna el valor ingresado formateado al tipo de dato indicado</returns>
        private static object ConvertValueToType(object value, Type targetType, bool useOracleCharBoolean)
        {
            if (value == DBNull.Value || value == null)
            {
                return null;
            }

            Type valueType = value.GetType();

            if (targetType == valueType || targetType.IsAssignableFrom(valueType))
            {
                return value;
            }

            // First, evalue if the target type is a nullable type
            Type targetTypeTemp = targetType;

            if (targetTypeTemp.IsGenericType && targetTypeTemp.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                targetTypeTemp = Nullable.GetUnderlyingType(targetType);

                if (targetTypeTemp == valueType || targetTypeTemp.IsAssignableFrom(valueType))
                {
                    return value;
                }
            }

            if (targetTypeTemp == typeof(bool) && useOracleCharBoolean)
            {
                return TranslateBetweenOracleCharAndBoolean(value.ToString()[0]);
            }

            if (targetTypeTemp.IsEnum)
            {
                return Enum.Parse(targetTypeTemp, value.ToString(), true);
            }

            try
            {
                return Convert.ChangeType(value, targetTypeTemp);
            }
            catch
            {
                return Convert.ChangeType(value, targetTypeTemp, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Metodo para la conversion de un char a un booleano
        /// </summary>
        /// <param name="value">Char que se verifica. 1 true, de lo contrario false</param>
        /// <returns>Retorna el valor booleano correspondiente</returns>
        private static bool TranslateBetweenOracleCharAndBoolean(char value)
        {
            return value == '1';
        }
    }
}