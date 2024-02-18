using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musiclibraryprog
{
    public class Music
    {
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public DateTime Release { get; set; }
        public string? Style { get; set; }

        internal static Music FromCsv(string line)
        {
            String[] splits = line.Split('|');
            Music music = new Music();
            music.Title = splits[0];
            music.Artist = splits[1];
            music.Style = splits[2];
            music.Release = DateTime.Parse(splits[3]);
            return music;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist} - {Release} - {Style}";
        }
    }
}
