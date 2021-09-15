using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RepositoryWithDapperAnd.NetCore.Services
{
    public class EntityStructure<T> where T : class
    {
        public static string ReturnTableOrAttributeName()
        {
            return System.Attribute.GetCustomAttributes(typeof(T)).Count() > 0 ?
                 ((TableAttribute)System.Attribute.GetCustomAttributes(typeof(T)).FirstOrDefault()).Name :
                 typeof(T).Name;
        }
        public static string[] ReturnEntityMembersList()
        {
            var members = typeof(T).GetProperties();
            var returnArray = new List<string>();
            foreach (var item in members)
            {
                returnArray.Add(item.Name);
            }
            return returnArray.ToArray();
        }
    }
}
