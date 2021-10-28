using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Gender
    {
        public string Name { get; }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустим или NULL");
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
