using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication4
{
    public class ParseMusic
    {
        public PLylist Model { get; set; }

        private string url;

        public HtmlDocument htmlDoc { get; set; }



        public ParseMusic(string url)
        {

            Model = new PLylist();
            this.url = url;

            htmlDoc = new HtmlDocument();

            this.htmlDoc.LoadHtml(TextHtml(url).Result);


            Initilizator();

        }

        private void Initilizator()
        {
            InitilizatorPlylist();
            InitilizatorPlylistImfo();
        }


        public void InitilizatorPlylistImfo()
        {
            var PLylistname = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='dj-name']//a").InnerText.ToString();

            var AvatarImages = htmlDoc.DocumentNode.SelectNodes("//div[@class='image']//img").ToList()[1].Attributes[0].ToString();


            var Date = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='image']//img").InnerText.
                ToString().Trim().ToCharArray().Skip(6).ToString();

            Model.PlaylistName = PLylistname;
            Model.AvatarImages = AvatarImages;
            Model.ReleaseDate = Date;



        }

        public void InitilizatorPlylist()
        {
            var Recordlebel = htmlDoc.DocumentNode.SelectNodes(".//span[@class='label']")
                .Select(x => x.InnerText.ToString()).ToList();




            var NameMusic = htmlDoc.DocumentNode.SelectNodes("//span[@class='release']")
                .Select(x => x.InnerText.ToString()).ToList();




            var NameAlbom = htmlDoc.DocumentNode.SelectNodes("//span[@class='song']")
                .Select(x => x.InnerText.ToString()).ToList();


            var name = htmlDoc.DocumentNode.SelectNodes("//span[@class='artist']")
                .Select(x => x.InnerText.ToString()).ToList();

            var Image = htmlDoc.DocumentNode.SelectNodes("//div[@class='spin-art-container']")
                .Select(x => x.InnerText.ToString()).ToList();



            var tinme = htmlDoc.DocumentNode.SelectNodes("//td[@class='spin-time']")
                .Select(x => x.InnerText.ToString()).ToList();

            for (int i = 0; i < NameMusic.Count(); i++)
            {
                Model.Music.Add(new Music()
                {
                    RecordLabel = Recordlebel[i],
                    NameArtist = name[i],
                    NameAlbom = NameAlbom[i],
                    Img = Image[i],
                    Time = tinme[i],
                    NameMusic = name[i]

                });
            }
        }


       







        public async Task<string> TextHtml(string url)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}
