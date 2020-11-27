using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GAMING_API.Models
{
    public class Game
    {
        /// <summary>
        /// disse get og set er med til at hente og aflever det tage, som kommer fra databasen
        /// </summary>
        public int game_id { get; set; }
        public string game_name { get; set; }
        public string game_publisher { get; set; }
        public int PEGI { get; set; }
        public string game_developer { get; set; }
        public string devices { get; set; }
        public string genre { get; set; }
        public string release_date { get; set; }
    }
    public class createGame : Game
    {

    }

    public class Readgame : Game
    {
        public Readgame(DataRow row)
        {
            /// <summary>
            /// laver det om til værdiger, som skal bruges for at omforme det data, som apiet modtager fra en user og lave det om til noget, som databasen kan bruge til at putte ind på en ny eller allrede exiterne colum 
            /// </summary>
            game_id = Convert.ToInt32(row["game_id"]);
            game_name = row["game_name"].ToString();
            game_publisher = row["game_publisher_name"].ToString();
            PEGI = Convert.ToInt32(row["PEGI_rating"]);
            game_developer = row["game_developername"].ToString();
            devices = row["devices_name"].ToString();
            genre = row["genre_name"].ToString();
            release_date = row["release_date"].ToString();
        }
    }
}