using System;
using System.Collections.Generic;
using System.Data;
using ConnectTaxiAPI.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ConnectTaxiAPI.Repositories
{
    public class VehiclesRepo
    {
        private string ConnectionString;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public VehiclesRepo(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return new MySqlConnection(ConnectionString);
        }

        /*
         *  This section lists all the methods of Vehicles Management
         */

        public List<Vehicles> ListVehicles()
        {
            List<Vehicles> list = new List<Vehicles>();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<Vehicles>().AsList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return list;
        }

        public List<Vehicles> ListVehiclesByModel(int ModelId)
        {
            List<Vehicles> list = new List<Vehicles>();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<Vehicles>(new { VehicleModelId = ModelId }).AsList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return list;
        }

        public List<Vehicles> ListByManufacturers(int Id)
        {
            List<Vehicles> list = new List<Vehicles>();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<Vehicles>(new { VehicleManufacturerId = Id }).AsList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return list;
        }

        public List<Vehicles> ListVehiclesByType(int TypeId)
        {
            List<Vehicles> list = new List<Vehicles>();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<Vehicles>(new { VehicleTypeId = TypeId }).AsList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return list;
        }

        public Vehicles GetVehicle(int VehicleId)
        {
            Vehicles result = new Vehicles();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    result = conn.Get<Vehicles>(VehicleId);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return result;
        }

        public AddRecordResponse AddVehicle(Vehicles vehicle)
        {
            AddRecordResponse response = new AddRecordResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var id = conn.Insert<Vehicles>(vehicle);
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

        public Response UpdateVehicle(Vehicles vehicle)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Update<Vehicles>(vehicle);
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

        public Response DeleteVehicle(int vehicleId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<Vehicles>(vehicleId);
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

        /*
         *  This section lists all the methods of Vehicles Model Management
         */

        public List<VehicleModels> ListVehicleModels()
        {
            List<VehicleModels> list = new List<VehicleModels>();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<VehicleModels>().AsList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return list;
        }

        public VehicleModels GetVehicleModel(int VehicleModelId)
        {
            VehicleModels result = new VehicleModels();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    result = conn.Get<VehicleModels>(VehicleModelId);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return result;
        }

        public AddRecordResponse AddVehicleModel(string VehicleModel)
        {
            AddRecordResponse response = new AddRecordResponse();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    var id = conn.Insert<VehicleModels>(new VehicleModels() { VehicleModel = VehicleModel });
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

        public Response UpdateVehicleModel(VehicleModels vehicleModel)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Update<VehicleModels>(vehicleModel);
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

        public Response DeleteVehicleModel(int vehicleModelId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<VehicleModels>(vehicleModelId);
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


        /*
         *  This section lists all the methods of Vehicles Types Management
         */

        public List<VehicleTypes> ListVehicleTypes()
        {
            List<VehicleTypes> list = new List<VehicleTypes>();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<VehicleTypes>().AsList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return list;
        }

        public VehicleTypes GetVehicleType(int VehicleTypeId)
        {
            VehicleTypes result = new VehicleTypes();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    result = conn.Get<VehicleTypes>(VehicleTypeId);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return result;
        }

        public AddRecordResponse AddVehicleType(string VehicleType)
        {
            AddRecordResponse response = new AddRecordResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    var id = conn.Insert<VehicleTypes>(new VehicleTypes() { VehicleType = VehicleType });
                    if(id > 0)
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

        public Response UpdateVehicleType(VehicleTypes vehicleTypes)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Update<VehicleTypes>(vehicleTypes);
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

        public Response DeleteVehicleType(int vehicleTypeId)
        {
            Response response = new Response();
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    conn.Delete<VehicleTypes>(vehicleTypeId);
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

        public List<VehicleManufacturers> ListVehicleManufacturers()
        {
            List<VehicleManufacturers> list = new List<VehicleManufacturers>();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    list = conn.GetList<VehicleManufacturers>().AsList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return list;
        }

        public VehicleManufacturers GetVehicleManufacturers(int id)
        {
            VehicleManufacturers manufacturers = new VehicleManufacturers();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    manufacturers = conn.Get<VehicleManufacturers>(id);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return manufacturers;
        }

        public AddRecordResponse AddVehicleManufacturers(VehicleManufacturers manufacturers)
        {
            AddRecordResponse response = new AddRecordResponse();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Insert<VehicleManufacturers>(manufacturers);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return response;
        }

        public Response UpdateVehicleManufacturers(VehicleManufacturers manufacturers)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Update<VehicleManufacturers>(manufacturers);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return response;
        }

        public Response DeleteVehicleManufacturers(int id)
        {
            Response response = new Response();
            try
            {
                using(IDbConnection conn = GetConnection())
                {
                    conn.Delete<VehicleManufacturers>(id);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return response;
        }
    }
}
