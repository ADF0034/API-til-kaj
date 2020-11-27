using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GAMING_API.Models
{
    public class Pegi
    {
        /// <summary>
        /// disse get og set er med til at hente og aflever det tage, som kommer fra databasen
        /// </summary>
        public int PEGI_id { get; set; }
        public string PEGI_rating { get; set; }
    }
    public class ReadPegi : Pegi
    {
        /// <summary>
        /// laver det om til værdiger, som skal bruges for at omforme det data, som apiet modtager fra en user og lave det om til noget, som databasen kan bruge til at putte ind på en ny eller allrede exiterne colum 
        /// </summary>
        public ReadPegi(DataRow row)
        {
            PEGI_id = Convert.ToInt32(row["PEGI_id"]);
            PEGI_rating = row["PEGI_rating"].ToString();
        }
    }
}