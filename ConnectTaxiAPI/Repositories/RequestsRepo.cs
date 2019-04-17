using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ConnectTaxiAPI.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ConnectTaxiAPI.Repositories
{
    public class RequestsRepo
    {
        private string ConnectionString;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public RequestsRepo(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        /* 
         * Read all uses
         */

        public List<Requests> ListRequests()
        {
            List<Requests> list = new List<Requests>();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<Requests>().AsList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return list;
        }

        public Requests GetRequest(int Id)
        {
            Requests result = new Requests();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    result = conn.Get<Requests>(Id);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return result;
        }


        public AddRecordResponse AddRequest(Requests request)
        {
            AddRecordResponse response = new AddRecordResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var id = conn.Insert<Requests>(request);
                    if (id > 0)
                    {
                        response.Description = "Record successfully saved";
                        response.Status = true;
                        response.Id = (int)id;
                    }
                    else
                    {
                        response.Description = "Error saving record";
                        response.Status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Description = "System malfunction";
                response.Status = false;
                logger.Error(ex);
            }
            return response;
        }

        public Response UpdateRequest(Requests request)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Update<Requests>(request);
                    response.Description = "Record successfully updated";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Description = "System malfunction";
                response.Status = false;
                logger.Error(ex);
            }
            return response;
        }

        public Response DeleteRequest(int Id)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Requests>(Id);
                    response.Description = "Record successfully deleted";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Description = "System malfunction";
                response.Status = false;
                logger.Error(ex);
            }
            return response;
        }
    }
}
