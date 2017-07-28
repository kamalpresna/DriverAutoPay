using CARS.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PayTNCDriver
{
    public class DataAccess : DbRepository
    {
        public static List<Model.Driver> GetTNCDrivers()
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("GetTNCDrivers", cn) { CommandType = CommandType.StoredProcedure };


            List<Model.Driver> ctList = new List<Model.Driver>();

            try
            {

                Command.Connection.Open();
                using (SqlDataReader dr = Command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model.Driver ct = new Model.Driver();
                        ct.DriverID = Convert.ToInt32(dr["DriverID"]);
                        ct.DriverNumber = Convert.ToInt32(dr["DriverNumber"]);
                        ct.EmailAddress = Convert.ToString(dr["CommAddress"]);
                        ct.CardProxyNumber = Convert.ToString(dr["CardProxyNumber"]);
                        if((dr["CardUserID"]) != DBNull.Value)
                            ct.CardUserID = Convert.ToInt32(dr["CardUserID"]);
                        ct.CardBalance = Convert.ToDecimal(dr["CardBalance"]);
                        ct.LocationID = Convert.ToInt32(dr["BaseLocationID"]);
                        ctList.Add(ct);
                    }
                }

            }
            catch (SqlException sqlex)
            {

            }
            finally
            {

                Command.Dispose();
                cn.Dispose();
            }

            return ctList;

        }

        /// <summary>
        /// The GetDriverTransactions method retrieves a list of a Drivers uncleared Transactions in DataSet format
        /// </summary>    

        public static List<Model.DriverFares> GetDriverFaresForAutoPay()
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("GetDriverFaresForAutoPay", cn) { CommandType = CommandType.StoredProcedure };


            List<Model.DriverFares> dfList = new List<Model.DriverFares>();

            try
            {

                Command.Connection.Open();
                using (SqlDataReader dr = Command.ExecuteReader())
                {                  
                    while (dr.Read())
                    {
                        Model.DriverFares df = new Model.DriverFares();                                               
                        df.DriverChargeID = Convert.ToInt32(dr["DriverChargeID"]);
                        df.LocationID = Convert.ToInt32(dr["BaseLocationID"]);
                        dfList.Add(df);
                    }
                }

            }
            catch (SqlException sqlex)
            {

            }
            finally
            {

                Command.Dispose();
                cn.Dispose();
            }

            return dfList;

        }
    }
}
