using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandle
{
    class StringHandle
    {
        public static int GetKeyWords(string[] Name, string keyword)
        {
            int IndexofKeyword = 0;
            for (int i = 0; i < Name.Length; i++)
            {
                if (Name[i].ToString().ToLower() == keyword)
                {
                    IndexofKeyword = i;
                    return IndexofKeyword;
                }
            }
            return IndexofKeyword;
        }

       
    }
}
