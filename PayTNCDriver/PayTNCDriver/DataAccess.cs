using CARS.Data.DataAccess;
using CARS.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PayTNCDriver
{
    public class DataAccess : DbRepository
    {
        public static List<Model.DriverInfo> GetTNCDrivers()
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("GetTNCDrivers", cn) { CommandType = CommandType.StoredProcedure };


            List<Model.DriverInfo> ctList = new List<Model.DriverInfo>();

            try
            {

                Command.Connection.Open();
                using (SqlDataReader dr = Command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model.DriverInfo ct = new Model.DriverInfo();
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

        public static List<Model.DriverInfo> GetPayPalDrivers()
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("GetPayPalDrivers", cn) { CommandType = CommandType.StoredProcedure };


            List<Model.DriverInfo> ctList = new List<Model.DriverInfo>();

            try
            {

                Command.Connection.Open();
                using (SqlDataReader dr = Command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model.DriverInfo ct = new Model.DriverInfo();
                        ct.DriverID = Convert.ToInt32(dr["DriverID"]);
                        ct.DriverNumber = Convert.ToInt32(dr["DriverNumber"]);
                        ct.EmailAddress = Convert.ToString(dr["CommAddress"]);
                        ct.CardProxyNumber = "";
                        ct.CardBalance = Convert.ToDecimal(dr["CardBalance"]);
                        ct.LocationID = Convert.ToInt32(dr["BaseLocationID"]);
                        ct.ReadyToProcess = 0;
                        ct.CommType = Convert.ToInt32(dr["CommType"]);
                        ct.PhoneNumber = dr["CommAddress"].ToString();
                        ct.ContactID = Convert.ToInt32(dr["ContactID"]);
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

        public static List<Model.DriverInfo> GetACHDrivers()
		{
			SqlConnection cn = new SqlConnection(ConnectionString());
			SqlCommand Command = new SqlCommand("GetACHDrivers", cn) { CommandType = CommandType.StoredProcedure };


			List<Model.DriverInfo> ctList = new List<Model.DriverInfo>();

			try
			{

				Command.Connection.Open();
				using (SqlDataReader dr = Command.ExecuteReader())
				{
					while (dr.Read())
					{
						Model.DriverInfo ct = new Model.DriverInfo();
						ct.DriverID = Convert.ToInt32(dr["DriverID"]);
						ct.DriverNumber = Convert.ToInt32(dr["DriverNumber"]);
						ct.EmailAddress = Convert.ToString(dr["CommAddress"]);
						ct.CardProxyNumber = "";
						ct.CardBalance = Convert.ToDecimal(dr["CardBalance"]);
						ct.LocationID = Convert.ToInt32(dr["BaseLocationID"]);
						ct.ReadyToProcess = 0;
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

		public static int GetHPPProfileID(int DriverID)
		{
			SqlConnection cn = new SqlConnection(ConnectionString());
			SqlCommand Command = new SqlCommand("GetHPPProfileID", cn) { CommandType = CommandType.StoredProcedure };


			int HPPProfileID = 0;

			try
			{

				Command.Connection.Open();
				Command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
				using (SqlDataReader dr = Command.ExecuteReader())
				{
					while (dr.Read())
					{
						HPPProfileID = Convert.ToInt32(dr["HPPProfileId"]);
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

			return HPPProfileID;

		}

        public static void RemoveDriverQualification(int DriverID, int QualificationID)
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("RemoveDriverQualification", cn) { CommandType = CommandType.StoredProcedure };
            Command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
            Command.Parameters.Add("@QualificationID", SqlDbType.Int).Value = QualificationID;

            try
            {

                Command.Connection.Open();
                Command.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                // Handle data access exception condition
                // Log specific exception details
                throw (sqlex);
                // Wrap the current exception in a more relevant
                // outer exception and re-throw the new exception
                //throw new DALException("Error Saving Name List", sqlex );
            }
            finally
            {
                Command.Connection.Close();
                Command.Dispose();
                cn.Dispose();
            }

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

		public static void LogError(int DriverID, string ErrorLabel, string ErrorText)
		{
			SqlConnection cn = new SqlConnection(ConnectionString());
			SqlCommand Command = new SqlCommand("Log_ACHError", cn) { CommandType = CommandType.StoredProcedure };


			List<Model.DriverFares> dfList = new List<Model.DriverFares>();

			try
			{

				Command.Connection.Open();
				Command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
				Command.Parameters.Add("@ErrorLabel", SqlDbType.VarChar).Value = ErrorLabel;
				Command.Parameters.Add("@ErrorText", SqlDbType.VarChar).Value = ErrorText;
				Command.ExecuteNonQuery();
			}
			catch (SqlException sqlex)
			{

			}
			finally
			{

				Command.Dispose();
				cn.Dispose();
			}
		}

        /// <summary>
        /// AddPayPalTransaction method adds an new paypal transaction.
        /// </summary>
        public static void AddACHTransaction(string accountNumber, string routingNumber, decimal amount, int driverID, bool processed, int type, string createdBy)
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("AddACHTransaction", cn) { CommandType = CommandType.StoredProcedure };

            //Add the parameters
            Command.Parameters.Add("@AccountNumber", SqlDbType.VarChar, 50).Value = accountNumber;
            Command.Parameters.Add("@RoutingNumber", SqlDbType.VarChar, 50).Value = routingNumber;
            Command.Parameters.Add("@Amount", SqlDbType.Money).Value = amount;
            Command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
            Command.Parameters.Add("@Processed", SqlDbType.Bit).Value = processed;
            Command.Parameters.Add("@Type", SqlDbType.Int).Value = type;
            Command.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = createdBy;

            try
            {
                Command.Connection.Open();
                Command.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                throw (sqlex);
            }
            finally
            {
                Command.Connection.Close();
                Command.Dispose();
                cn.Dispose();
            }
        }

        /// <summary>
        /// AddPayPalTransaction method adds an new paypal transaction.
        /// </summary>
        public static void AddPayPalTransaction(int driverId, decimal balance, int transactionTypeID, string response,
                                                string referenceBatchId, string referenceItemId, string recipientType,
                                                string senderBatchId, string errors, int locationId, string createdBy)
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("AddPayPalTransaction", cn) { CommandType = CommandType.StoredProcedure };

            //Add the parameters
            Command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverId;
            Command.Parameters.Add("@Balance", SqlDbType.Money).Value = balance;
            Command.Parameters.Add("@TransactionTypeID", SqlDbType.Int).Value = transactionTypeID;
            Command.Parameters.Add("@Response", SqlDbType.VarChar, -1).Value = response;
            Command.Parameters.Add("@ReferenceBatchID", SqlDbType.VarChar, 50).Value = referenceBatchId;
            Command.Parameters.Add("@ReferenceItemID", SqlDbType.VarChar, 50).Value = referenceItemId;
            Command.Parameters.Add("@RecipientType", SqlDbType.VarChar, 50).Value = recipientType;
            Command.Parameters.Add("@SenderBatchID", SqlDbType.VarChar, 50).Value = senderBatchId;
            Command.Parameters.Add("@Errors", SqlDbType.VarChar, -1).Value = errors;
            Command.Parameters.Add("@LocationID", SqlDbType.Int).Value = locationId;
            Command.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = createdBy;

            try
            {
                Command.Connection.Open();
                Command.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                throw (sqlex);
            }
            finally
            {
                Command.Connection.Close();
                Command.Dispose();
                cn.Dispose();
            }
        }

        /// <summary>
        /// The GetPayPalTransaction method gets Pending PayPalTransactions by driverID
        /// </summary>
        public static Model.PayPalTransaction GetPayPalPendingPayoutTransaction(int driverID)
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("GetPayPalPendingPayoutTransaction", cn) { CommandType = CommandType.StoredProcedure };
            Command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

            Model.PayPalTransaction ppt = new Model.PayPalTransaction();

            try
            {
                Command.Connection.Open();
                using (SqlDataReader dr = Command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ppt.TransactionID = Convert.ToInt32(dr["TransactionID"]);
                        ppt.DriverID = Convert.ToInt32(dr["DriverID"]);
                        ppt.Balance = Convert.ToDecimal(dr["Balance"]);
                        ppt.TransactionTypeID = Convert.ToInt32(dr["TransactionTypeID"]);
                        ppt.Response = dr["Response"].ToString();
                        ppt.ReferenceBatchID = dr["ReferenceBatchID"].ToString();
                        ppt.ReferenceItemID = dr["ReferenceItemID"].ToString();
                        ppt.RecipientType = dr["RecipientType"].ToString();
                        ppt.SenderBatchID = dr["SenderBatchID"].ToString();
                        ppt.Errors = dr["Errors"].ToString();
                        ppt.LocationID = Convert.ToInt32(dr["LocationID"]);
                        ppt.CreatedBy = dr["CreatedBy"].ToString();
                        ppt.PartialPaidAmount = Convert.ToDecimal(dr["PartialPaidAmount"]);
                    }
                    dr.Close();
                }

            }
            catch (SqlException sqlex)
            {
                // Handle data access exception condition
                // Log specific exception details
                throw (sqlex);
                // Wrap the current exception in a more relevant
                // outer exception and re-throw the new exception
                //throw new DALException("Error Saving Name List", sqlex );
            }
            finally
            {

                Command.Dispose();
                cn.Dispose();
            }

            return ppt;
        }

        /// <summary>
        /// The GetPayPalTransaction method gets Pending PayPalTransactions by driverID
        /// </summary>
        public static List<Model.PayPalTransaction> GetPayPalPartialPaidTransaction(int driverID)
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("GetPayPalPartialPaidTransaction", cn) { CommandType = CommandType.StoredProcedure };
            Command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

            List<Model.PayPalTransaction> list = new List<Model.PayPalTransaction>();

            try
            {
                Command.Connection.Open();
                using (SqlDataReader dr = Command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model.PayPalTransaction ppt = new Model.PayPalTransaction();
                        ppt.TransactionID = Convert.ToInt32(dr["TransactionID"]);
                        ppt.DriverID = Convert.ToInt32(dr["DriverID"]);
                        ppt.Balance = Convert.ToDecimal(dr["Balance"]);
                        ppt.TransactionTypeID = Convert.ToInt32(dr["TransactionTypeID"]);
                        ppt.Response = dr["Response"].ToString();
                        ppt.ReferenceBatchID = dr["ReferenceBatchID"].ToString();
                        ppt.ReferenceItemID = dr["ReferenceItemID"].ToString();
                        ppt.RecipientType = dr["RecipientType"].ToString();
                        ppt.SenderBatchID = dr["SenderBatchID"].ToString();
                        ppt.Errors = dr["Errors"].ToString();
                        ppt.LocationID = Convert.ToInt32(dr["LocationID"]);
                        ppt.CreatedBy = dr["CreatedBy"].ToString();
                        ppt.PartialPaidAmount = Convert.ToDecimal(dr["PartialPaidAmount"]);
                        list.Add(ppt);
                    }
                    dr.Close();
                }

            }
            catch (SqlException sqlex)
            {
                // Handle data access exception condition
                // Log specific exception details
                throw (sqlex);
                // Wrap the current exception in a more relevant
                // outer exception and re-throw the new exception
                //throw new DALException("Error Saving Name List", sqlex );
            }
            finally
            {

                Command.Dispose();
                cn.Dispose();
            }

            return list;
        }

        /// <summary>
        /// The GetPayPalTransaction method gets Pending PayPalTransactions by driverID
        /// </summary>
        public static List<Model.PayPalTransaction> GetPayPalPendingInvoiceTransaction(int driverID)
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("GetPayPalPendingInvoiceTransaction", cn) { CommandType = CommandType.StoredProcedure };
            Command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

            List< Model.PayPalTransaction> list = new List<Model.PayPalTransaction>();

            try
            {
                Command.Connection.Open();
                using (SqlDataReader dr = Command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model.PayPalTransaction ppt = new Model.PayPalTransaction();
                        ppt.TransactionID = Convert.ToInt32(dr["TransactionID"]);
                        ppt.DriverID = Convert.ToInt32(dr["DriverID"]);
                        ppt.Balance = Convert.ToDecimal(dr["Balance"]);
                        ppt.TransactionTypeID = Convert.ToInt32(dr["TransactionTypeID"]);
                        ppt.Response = dr["Response"].ToString();
                        ppt.ReferenceBatchID = dr["ReferenceBatchID"].ToString();
                        ppt.ReferenceItemID = dr["ReferenceItemID"].ToString();
                        ppt.RecipientType = dr["RecipientType"].ToString();
                        ppt.SenderBatchID = dr["SenderBatchID"].ToString();
                        ppt.Errors = dr["Errors"].ToString();
                        ppt.LocationID = Convert.ToInt32(dr["LocationID"]);
                        ppt.CreatedBy = dr["CreatedBy"].ToString();
                        ppt.PartialPaidAmount = Convert.ToDecimal(dr["PartialPaidAmount"]);
                        list.Add(ppt);
                    }
                    dr.Close();
                }

            }
            catch (SqlException sqlex)
            {
                // Handle data access exception condition
                // Log specific exception details
                throw (sqlex);
                // Wrap the current exception in a more relevant
                // outer exception and re-throw the new exception
                //throw new DALException("Error Saving Name List", sqlex );
            }
            finally
            {

                Command.Dispose();
                cn.Dispose();
            }

            return list;
        }

        public static void UpdatePayPalTransaction(int driverId, decimal balance, string response, string referenceBatchId,
                                                  string referenceItemId, string errors, decimal partialPaidAmount)
        {
            SqlConnection cn = new SqlConnection(ConnectionString());
            SqlCommand Command = new SqlCommand("UpdatePayPalTransaction", cn) { CommandType = CommandType.StoredProcedure };

            //Add the parameters
            Command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverId;
            Command.Parameters.Add("@Balance", SqlDbType.Money).Value = balance;
            Command.Parameters.Add("@Response", SqlDbType.VarChar, -1).Value = response;
            Command.Parameters.Add("@ReferenceBatchID", SqlDbType.VarChar, 50).Value = referenceBatchId;
            Command.Parameters.Add("@ReferenceItemID", SqlDbType.VarChar, 50).Value = referenceItemId;
            Command.Parameters.Add("@Errors", SqlDbType.VarChar, -1).Value = errors;
            Command.Parameters.Add("@PartialPaidAmount", SqlDbType.Money).Value = partialPaidAmount;

            try
            {
                Command.Connection.Open();
                Command.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                throw (sqlex);
            }
            finally
            {
                Command.Connection.Close();
                Command.Dispose();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Retrieves a list of the driver addresses available for the selected driver, and uses them to populate
        /// a grid. The drivers current address will be indicated
        /// </summary>
        public static AddressListItem GetAddressListItemForContactID(int contactID)
        {
            AddressList al = new AddressList();
            State sl = new State();

            AddressListItem addressListItem = new AddressListItem();

            DataSet ds = al.GetAddressesForContact(contactID);

            using (DataSet ds2 = sl.GetStates())
            {
                DataTable dt = ds2.Tables[0];
                dt.TableName = "States";
                ds2.Tables.Remove(ds2.Tables[0]);
                ds.Tables.Add(dt);
            }
            ds.Relations.Add(ds.Tables[1].Columns["StateID"], ds.Tables[0].Columns["StateID"]);


            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                int addressID = int.Parse(dataRow["AddressID"].ToString());
                addressListItem = al.GetAddressListItem(addressID);
            }
            return addressListItem;

        }

    }
}
