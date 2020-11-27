using GAMING_API.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GAMING_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] //doing so the api controller can beused by Corsplatforms
    public class GamingController : ApiController
    {
        // GET api/<controller>
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;

        public IEnumerable<Game> Get()
        {
            _conn = new SqlConnection("data source=DESKTOP-M8A87VO;Initial catalog=Gaming; user id= gamingapi; password=frederik0608;"); //adding a SqlConnection to the database
            DataTable _dt = new DataTable();
           /*when the metoed is call this is call to get alle the data from the database*/
            var query = "SELECT game_id,game_name,game_publisher_name,PEGI_rating,game_developername,devices_name,genre_name,release_date FROM Games Left JOIN game__publisher ON game_publisher = game__publisher.game_publisher_id left JOIN PEGI ON PEGI = PEGI_id left JOIN game_developer ON game_developer = game_developer.game_developerid left JOIN devices ON devices = devices.devices_id left JOIN genre ON genre = genre.genre_id Order by game_publisher_name,PEGI_rating,game_developername,devices_name,genre_name"; 
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            //SelectCommand holder nu både query og vores SqlConnection til databasen
            _adapter.Fill(_dt);
            List<Game> games = new List<Models.Game>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach(DataRow gam in _dt.Rows)
                {
                    games.Add(new Readgame(gam));
                }
            }
            // her henter den alle ting, som den kan finde i den database samt tjekker alle rows og henter dens data
            return games;
        }

        // GET api/<controller>/5
        public IEnumerable<Game> Get(int id)
        {
            _conn = new SqlConnection("data source=DESKTOP-M8A87VO;Initial catalog=Gaming; user id=gamingapi; password=frederik0608;");
            DataTable _dt = new DataTable();
            var query = "SELECT game_id,game_name,game_publisher_name,PEGI_rating,game_developername,devices_name,genre_name,release_date from Games Left JOIN game__publisher ON game_publisher = game__publisher.game_publisher_id left JOIN PEGI ON PEGI = PEGI_id left JOIN game_developer ON game_developer = game_developer.game_developerid left JOIN devices ON devices = devices.devices_id left JOIN genre ON genre = genre.genre_id  where game_id=" +
                id+" Order by game_publisher_name,PEGI_rating,game_developername,devices_name,genre_name";
           //her henter den kun det enklede værdig fra data basen, som er lige med den værdig, som du har givet den
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Game> games = new List<Models.Game>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow gam in _dt.Rows)
                {
                    games.Add(new Readgame(gam));
                }
            }
            return games;
        }

        // POST api/<controller>
        public string Post([FromBody] createGame value)
        {
            _conn = new SqlConnection("data source=DESKTOP-M8A87VO;Initial catalog=Gaming; user id= gamingapi; password=frederik0608;");

            var query = "insert into Games (game_name,game_publisher,PEGI,game_developer,devices,genre,release_date) values(@game_name,@game_publisher,@PEGI,@game_developer,@devices,@genre,@release_date)";
            SqlCommand insertcommand = new SqlCommand(query, _conn);
            insertcommand.Parameters.AddWithValue("@game_name", value.game_name);
            insertcommand.Parameters.AddWithValue("@game_publisher", value.game_publisher);
            insertcommand.Parameters.AddWithValue("@PEGI", value.PEGI);
            insertcommand.Parameters.AddWithValue("@game_developer", value.game_developer);
            insertcommand.Parameters.AddWithValue("@devices", value.devices);
            insertcommand.Parameters.AddWithValue("@genre", value.genre);
            insertcommand.Parameters.AddWithValue("@release_date", value.release_date);
            _conn.Open();
            //her tager den i modnogle elementer, ude fra og indsætter dem på de plader i databasen, som stemmer over ens med det den har fået af vide de er 
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] createGame value)
        {
            _conn = new SqlConnection("data source=DESKTOP-M8A87VO;Initial catalog=Gaming; user id= gamingapi; password=frederik0608;");

            var query = "update Games set game_name=@game_name,game_publisher=@game_publisher,PEGI=@PEGI,game_developer=@game_developer,genre=@genre,release_date=@release_date where game_id=" + id;
            SqlCommand insertcommand = new SqlCommand(query, _conn);
            insertcommand.Parameters.AddWithValue("@game_name", value.game_name);
            insertcommand.Parameters.AddWithValue("@game_publisher", value.game_publisher);
            insertcommand.Parameters.AddWithValue("@PEGI", value.PEGI);
            insertcommand.Parameters.AddWithValue("@game_developer", value.game_developer);
            insertcommand.Parameters.AddWithValue("@genre", value.genre);
            insertcommand.Parameters.AddWithValue("@release_date", value.release_date);
            //dette er næsten det samme med at den modtager værdiger ude fra usern og der med kan putte det ind på et allrede Extiterne table i databasen
            _conn.Open();
             int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            _conn = new SqlConnection("data source=DESKTOP-M8A87VO;Initial catalog=Gaming; user id= gamingapi; password=frederik0608;");
            //sletter det Element, som du gerne ville havde slettet ved hjælp af dens id
            var query = " delete from Games where game_id=" + id;
            SqlCommand insertcommand = new SqlCommand(query, _conn);
            _conn.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}