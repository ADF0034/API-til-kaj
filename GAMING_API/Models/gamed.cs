using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GAMING_API.Models
{
    public class gamed
    {
        /// <summary>
        /// disse get og set er med til at hente og aflever det tage, som kommer fra databasen
        /// </summary>
        public int game_developerid { get; set; }
        public string game_developername { get; set; }
    }
    public class Readgamedeveloper : gamed
    {
        /// <summary>
        /// laver det om til værdiger, som skal bruges for at omforme det data, som apiet modtager fra en user og lave det om til noget, som databasen kan bruge til at putte ind på en ny eller allrede exiterne colum 
        /// </summary>
        public Readgamedeveloper(DataRow row)
        {
            game_developerid = Convert.ToInt32(row["game_developerid"]);
            game_developername = row["game_developername"].ToString();
        }
    }
}