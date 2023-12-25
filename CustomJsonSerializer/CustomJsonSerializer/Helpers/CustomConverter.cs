using CustomJsonSerializer.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace CustomJsonSerializer.Extensions
{
    public static class CustomConverter
    {
        /*<summary>
         T is generic
        </summary>*/
        public static T Deserialize<T>(string value) where T : class, new()
        {
            try
            {
                JObject jObject = JObject.Parse(value);
                T rootClass = new T();

                foreach (JProperty property in jObject.Properties())
                {
                    PropertyInfo targetProperty = rootClass.GetType().GetProperty(property.Name);

                    if (targetProperty != null)
                    {
                        targetProperty.SetValue(rootClass, property.Value.ToObject(targetProperty.PropertyType));
                    }
                }
                return rootClass;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static string Serializer<T>(T root) where T : class, new()
        {
            string newJson = "{\n";
            foreach (var item in root.GetType().GetProperties())
            {
                if (!item.PropertyType.IsGenericType && item.PropertyType == typeof(string))
                {
                    newJson += '"' + item.Name + '"' + ':' + '"' + item.GetValue(root) + '"' + ',' + "\n";
                }
                else if (item.PropertyType.IsGenericType)
                {
                    var genericValue = item.GetValue(root);
                    newJson += '"' + item.Name + '"' + ':' + "[";
                    foreach (var gv in genericValue as IEnumerable<object>)
                    {
                        newJson += '"' + gv.ToString() + '"' + ','+"\n";
                    }
                    if (newJson.Last() == ',')
                    {
                        newJson = newJson.Remove(newJson.Length - 1);
                    }
                    newJson += "]" + ',' + "\n";
                }
                else if (item.PropertyType != typeof(string) && !item.PropertyType.IsGenericType)
                {
                    var genericValue = item.GetValue(root);
                    newJson += '"' + item.Name + '"' + ':' + "{";
                    foreach (var gv in genericValue.GetType().GetProperties())
                    {
                        if (gv.GetValue(genericValue).GetType()==typeof(string))
                        {
                            newJson += '"' + gv.Name + '"' + ":" + '"' + gv.GetValue(genericValue) + '"' + ',';
                        }
                        else
                        {
                            Console.WriteLine("test1234");
                        }
                    }
                    if (newJson.Last() == ',')
                    {
                        newJson = newJson.Remove(newJson.Length - 1);
                    }
                    newJson += "}" + ',' + "\n";
                }
                else
                {
                    Console.WriteLine(item);
                }

            }
            newJson += "}";
            return newJson;
        }
    }
}
