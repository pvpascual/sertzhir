using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SertzHir.Core.Interfaces;

namespace SertzHir.Common
{
    public class Utilities:IUtility
    {
        /// <summary>
        /// Determine if a SQL parameter is a potential SQL injection attack
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool IsClearFromSqlInjection(string param)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            Match match = regex.Match(param);
            if (match.Success)
            {
                return false;
            }

            return true;
        }
    }
}
