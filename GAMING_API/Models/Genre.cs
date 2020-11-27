using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GAMING_API.Models
{

    public class Genre
    {
        /// <summary>
        /// disse get og set er med til at hente og aflever det tage, som kommer fra databasen
        /// </summary>
        public int genre_id { get; set; }
        public string genre_name { get; set; }
    }
    public class Readgenre : Genre
    {
        /// <summary>
        /// laver det om til værdiger, som skal bruges for at omforme det data, som apiet modtager fra en user og lave det om til noget, som databasen kan bruge til at putte ind på en ny eller allrede exiterne colum 
        /// </summary>
        public Readgenre(DataRow row)
        {
            genre_id = Convert.ToInt32(row["genre_id"]);
            genre_name = row["genre_name"].ToString();
        }
    }
}