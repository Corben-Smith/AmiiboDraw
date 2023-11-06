using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest
{
    public class Amiibo
    {
        public string AmiiboSeries { get; set; }
        public string Character { get; set; }
        public string GameSeries { get; set; }
        public string Head { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Tail { get; set; }
        public string Type { get; set; }



        public override string ToString()
        {
            return $"Amiibo Series: {AmiiboSeries}\n" +
                   $"Character: {Character}\n" +
                   $"Game Series: {GameSeries}\n" +
                   $"Head: {Head}\n" +
                   $"Image: {Image}\n" +
                   $"Name: {Name}\n" +
                   $"Tail: {Tail}\n" +
                   $"Type: {Type}";
        }
    }
}
