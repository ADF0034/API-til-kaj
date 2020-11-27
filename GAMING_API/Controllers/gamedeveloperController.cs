using GAMING_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GAMING_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class gamedeveloperController : ApiController
    {
 
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        // GET api/<controller>
        public IEnumerable<gamed> Get()
        {
            _conn = new SqlConnection("data source=DESKTOP-M8A87VO;Initial catalog=Gaming; user id= gamingapi; password=frederik0608;");
            DataTable _dt = new DataTable();
            //var query = "SELECT game_id,game_name,game_publisher_name,PEGI_rating,game_developername,devices_name,genre_name,platform_name,release_date,kommentar FROM  Games Left JOIN game__publisher ON game_publisher = game__publisher.game_publisher_id left JOIN PEGI ON PEGI = PEGI_id left JOIN game_developer ON game_developer = game_developer.game_developerid left JOIN devices ON devices = devices.devices_id left JOIN genre ON genre = genre.genre_id left JOIN Platforms ON platforms = platform_id Order by game_publisher_name,PEGI_rating,game_developername,devices_name,genre_name,platform_name";
            var query = "SELECT * from game_developer";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<gamed> Gamed = new List<Models.gamed>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow gd in _dt.Rows)
                {
                    Gamed.Add(new Readgamedeveloper(gd));
                }
            }
            return Gamed;
        }
    }
}