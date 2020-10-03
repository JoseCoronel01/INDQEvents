using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModeloClases 
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public eGender gender { get; set; }
        public enum eGender
        {
            male=0,female=1,nulo=2
        }
    }
}