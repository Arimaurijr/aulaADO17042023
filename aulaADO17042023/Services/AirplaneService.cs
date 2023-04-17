using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aulaADO17042023.Model;
using aulaADO17042023.Models;

namespace aulaADO17042023.Services
{
    public class AirplaneService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\DOCUMENTS\FLY.MDF";
        readonly SqlConnection conn;

        public AirplaneService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public bool Insert(Aviao airplane)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Airplane(Name,NumberOfPassagers,Description,idEngine)" +
                "values (@Name,@NumberOfPassagers,@Description,@IdEngine)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", airplane.Name));
                commandInsert.Parameters.Add(new SqlParameter("@NumberOfPassagers", airplane.NumberOfPassagers));
                commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Description));
                commandInsert.Parameters.Add(new SqlParameter("@IdEngine", InsertEngine(airplane)));
                
                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch(Exception e) 
            {
                status = false;
                throw;
            }
            finally
            { 
                conn.Close(); 
            }   

            return status;
        }

        private int InsertEngine(Aviao airplane)
        {
            string strInsert = "insert into Engine(Description) values (@Description); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Engine.Description));

            return (int) commandInsert.ExecuteScalar();
        }
        public List<Aviao> FindAll()
        {
            List<Aviao> airplanes = new();
            StringBuilder sb = new StringBuilder();
            sb.Append("select a.Id, a.Name, a.Description, a.NumberOfPassagers, e.Description Engine from Airplane a, Engine e where a.IdEngine = e.id");
            /*
             * sb.Append("select a.Id,");
             * sb.Append("      a.Name,);
             * sb.Append("      a.Description, );
             * sb.Append("      a.NumberOfPassagers, );
             * sb.Append("      e.Description Engine");
             * sb.Append("      from Airplane a, ");
             * sb.Append("      Engine e");
             * sb.Append("   where a.IdEngine = e.Id);
             * 
             */
        

            SqlCommand commandSelect = new(sb.ToString(), conn);
            /*tabela*/SqlDataReader dr = commandSelect.ExecuteReader();

            while(dr.Read())
            {
                Aviao airplane = new();

                airplane.Id = (int)dr["Id"];
                airplane.Name = (string)dr["Name"]; 
                airplane.NumberOfPassagers = (int)dr["NumberOfPassagers"];
                airplane.Description = (string)dr["Description"];
                airplane.Engine = new Engine() { Description = (string)dr["Engine"] };

                airplanes.Add(airplane);
            }

            return airplanes;
        }
    }
}
