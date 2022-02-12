using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication4
{
    public class PLylist
    {
        public string PlaylistName { get;set; }

        public string AvatarImages { get;set; }  

        public string ReleaseDate { get; set; }

        //жанр
        public string GenrePlylist { get; set; }
        public List<Music> Music { get; set; }


    }
    public class Music
    {

        public string RecordLabel { get; set; }

        public string NameMusic { get; set; }

        public string NameArtist { get; set; }

        public string NameAlbom { get; set; }

        public string Time { get; set; }

        public string Img { get; set; }

        public string? Genre { get; set; }
    }
}
