using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GAMING_API.Models
{
    public class gamepublisher
    {
        /// <summary>
        /// disse get og set er med til at hente og aflever det tage, som kommer fra databasen
        /// </summary>
        public int game_publisher_id { get; set; }
        public string game_publisher_name { get; set; }

    }
    public class Readgamepublisher : gamepublisher
    {
        /// <summary>
        /// laver det om til værdiger, som skal bruges for at omforme det data, som apiet modtager fra en user og lave det om til noget, som databasen kan bruge til at putte ind på en ny eller allrede exiterne colum 
        /// </summary>
        public Readgamepublisher(DataRow row)
        {
            game_publisher_id = Convert.ToInt32(row["game_publisher_id"]);
            game_publisher_name = row["game_publisher_name"].ToString();
        }
    }
}