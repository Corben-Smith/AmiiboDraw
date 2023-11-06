using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest
{
    public class Release
    {
        public string au { get; set; }
        public string eu { get; set; }
        public string jp { get; set; }
        public string na { get; set; }


        public override string ToString()
        {
            return $"AU: {au}\n" +
                   $"EU: {eu}\n" +
                   $"JP: {jp}\n" +
                   $"NA: {na}";
        }
    }
}
