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
    public class UsersRepo
    {
        private string ConnectionString;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public UsersRepo(IConfiguration configuration)
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

        public List<Users> ListUsers()
        {
            List<Users> list = new List<Users>();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<Users>().AsList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return list;
        }

        public Users GetUser(int UserId)
        {
            Users result = new Users();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    result = conn.Get<Users>(UserId);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return result;
        }

        public Users GetUserByUsername(string username)
        {
            Users result = new Users();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    result = conn.GetList<Users>(new { Username = username }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return result;
        }

        public AddRecordResponse AddUser(Users user)
        {
            AddRecordResponse response = new AddRecordResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var id = conn.Insert<Users>(user);
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

        public Response UpdateUser(Users user)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Update<Users>(user);
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

        public Response DeleteUser(int userId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Users>(userId);
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
