using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class Videogame
    {
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int IdSoftwareHouse { get; set; }


        public Videogame(string name, string overview, DateTime releaseDate, int idSoftwareHouse)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            IdSoftwareHouse = idSoftwareHouse;
        }
    }
}
