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
    public class platformsController : ApiController
    {
        // GET api/<controller>
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;

        public IEnumerable<Platforms> Get()
        {
            _conn = new SqlConnection("data source=DESKTOP-M8A87VO;Initial catalog=Gaming; user id= gamingapi; password=frederik0608;");
            DataTable _dt = new DataTable();
            var query = "SELECT * from Platforms";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(_dt);
            List<Platforms> platfrom = new List<Models.Platforms>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow platf in _dt.Rows)
                {
                    platfrom.Add(new Readplatforms(platf));
                }
            }
            return platfrom;
        }

    }
}