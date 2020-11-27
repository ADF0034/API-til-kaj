using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GAMING_API.Models
{
    public class Platforms
    {
        /// <summary>
        /// disse get og set er med til at hente og aflever det tage, som kommer fra databasen
        /// </summary>
        public int platform_id { get; set; }
        public string platform_name { get; set; }
    }
    public class Readplatforms : Platforms
    {
        /// <summary>
        /// laver det om til værdiger, som skal bruges for at omforme det data, som apiet modtager fra en user og lave det om til noget, som databasen kan bruge til at putte ind på en ny eller allrede exiterne colum 
        /// </summary>
        public Readplatforms(DataRow row)
        {
            platform_id = Convert.ToInt32(row["platform_id"]);
            platform_name = row["platform_name"].ToString();
        }
    }
}