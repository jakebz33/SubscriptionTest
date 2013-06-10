using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RKMC.Base.Data
{
    public class DataHelper
    {
        #region PUBLIC PROPERTIES

        public string ConnectionString { get; set; }
        public string StoredProcName { get; set; }

        //notes:    property determines what object properties you want to set when calling db and hydrating object
        public ObjectPropertyDictionary PropertyDictionary { get; set; }

        //notes:    set this collection property to determine what sql parameters to set when calling db and sql procedures
        public ParameterCollection ParameterCollection { get; set; }

        #endregion


        #region PRIVATE STATIC METHODS

        private static SqlCommand GetCommand(DataHelper DataProperties)
        {
            if (DataProperties.ConnectionString == null)
                throw new Exception("Connection String is invalid. Null value.");

            if (DataProperties.ConnectionString.Length == 0)
                throw new Exception("Connection String is invalid. Value is empty.");

            if (DataProperties.StoredProcName == null)
                throw new Exception("Stored Procedure Name is invalid. Null value.");

            if (DataProperties.StoredProcName.Length == 0)
                throw new Exception("Stored Procedure Name is invalid. Value is empty.");

            SqlConnection myConn = new SqlConnection();
            SqlCommand myCmd = new SqlCommand();

            myConn.ConnectionString = DataProperties.ConnectionString;
            myConn.Open();

            myCmd.CommandType = CommandType.StoredProcedure;
            myCmd.CommandTimeout = 0;
            myCmd.Connection = myConn;
            myCmd.CommandText = DataProperties.StoredProcName;

            if (DataProperties.ParameterCollection != null)
            {
                foreach (SqlParameter itemParameter in DataProperties.ParameterCollection)
                    myCmd.Parameters.Add(itemParameter);
            }

            return myCmd;
        }

        #endregion


        #region PUBLIC STATIC METHODS

        public static Object GetItem<T>(ParameterCollection ParameterCollection, ObjectPropertyDictionary PropertyValues, string StoredProcName, string ConnString)
        {
            DataHelper objData = new DataHelper
            {
                ConnectionString = ConnString,
                StoredProcName = StoredProcName,
                ParameterCollection = ParameterCollection,
                PropertyDictionary = PropertyValues
            };

            return DataHelper.GetObjectItem<T>(objData);
        }
        public static List<Object> GetList<T>(ParameterCollection ParameterCollection, ObjectPropertyDictionary PropertyValues, string StoredProcName, string ConnString)
        {
            DataHelper objData = new DataHelper
            {
                ConnectionString = ConnString,
                StoredProcName = StoredProcName,
                ParameterCollection = ParameterCollection,
                PropertyDictionary = PropertyValues
            };

            List<Object> objList = new List<object>();
            SqlDataReader objReader = null;
            try
            {
                objReader = DataHelper.GetDataReader(objData);
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                        objList.Add(DataHelper.HydrateObject<T>(objReader, PropertyValues));
                }
            }
            finally
            {
                objReader.Close();
                objReader.Dispose();
            }

            return objList;
        }
        public static List<Object> GetList<T>(DataTable DataTableObject, ObjectPropertyDictionary PropertyValues)
        {
            List<Object> objList = new List<object>();
            try
            {
                if (DataTableObject.Rows.Count > 0)
                {
                    foreach (DataRow itemDR in DataTableObject.Rows)
                        objList.Add(DataHelper.HydrateObject<T>(itemDR, PropertyValues));
                }
            }
            finally
            {
                DataTableObject.Dispose();
            }

            return objList;
        }

        public static SqlDataReader GetDataReader(DataHelper DataProperties)
        {
            SqlCommand cmd = DataHelper.GetCommand(DataProperties);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static Object GetObjectItem<T>(DataHelper DataProperties)
        {
            SqlCommand cmd = DataHelper.GetCommand(DataProperties);
            SqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                        return DataHelper.HydrateObject<T>(reader, DataProperties.PropertyDictionary);
                    else
                        return DataHelper.GetObjectRecordCount<T>(0);
                }
                else
                    return DataHelper.GetObjectRecordCount<T>(0);
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        public static DataSet GetDataSet(SqlCommand myCmd)
        {
            SqlDataAdapter myDA = new SqlDataAdapter(myCmd);
            DataSet myDS = new DataSet();

            myDA.Fill(myDS);
            myDA.Dispose();
            myCmd.Dispose();

            //notes:    set the datatable name if SQL query returns a column name = "DataTableName"
            foreach (DataTable myDT in myDS.Tables)
            {
                if (myDT.Rows.Count > 0)
                {
                    if (myDT.Rows[0].Table.Columns.Contains("DataTableName"))
                        myDT.TableName = myDT.Rows[0]["DataTableName"].ToString();
                }
            }

            return myDS;
        }
        public static DataSet GetDataSet(ParameterCollection ParameterCollection, string StoredProcName, string ConnString)
        {
            DataHelper objData = new DataHelper
            {
                ConnectionString = ConnString,
                StoredProcName = StoredProcName,
                ParameterCollection = ParameterCollection,
            };
            SqlCommand myCmd = DataHelper.GetCommand(objData);
            SqlDataAdapter myDA = new SqlDataAdapter(myCmd);
            DataSet myDS = new DataSet();

            myDA.Fill(myDS);
            myDA.Dispose();
            myCmd.Dispose();

            //notes:    set the datatable name if SQL query returns a column name = "DataTableName"
            foreach (DataTable myDT in myDS.Tables)
            {
                if (myDT.Rows.Count > 0)
                {
                    if (myDT.Rows[0].Table.Columns.Contains("DataTableName"))
                        myDT.TableName = myDT.Rows[0]["DataTableName"].ToString();
                }
            }

            return myDS;
        }

        public static void ExecuteDB(ParameterCollection ParameterCollection, string StoredProcName, string ConnectionString)
        {
            DataHelper objData = new DataHelper
            {
                ConnectionString = ConnectionString,
                StoredProcName = StoredProcName,
                ParameterCollection = ParameterCollection
            };

            SqlCommand cmd = DataHelper.GetCommand(objData);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        public static void ExecuteDB(ParameterCollection ParameterCollection, string StoredProcName, string ConnectionString, out int ReturnID)
        {
            DataHelper objData = new DataHelper
            {
                ConnectionString = ConnectionString,
                StoredProcName = StoredProcName,
                ParameterCollection = ParameterCollection
            };

            SqlCommand cmd = DataHelper.GetCommand(objData);
            try
            {
                /*
                SqlParameter sqlReturnParam = new SqlParameter("@ReturnValue", SqlDbType.Int);
                sqlReturnParam.Value = 0;
                sqlReturnParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(sqlReturnParam);
                
                //cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                //cmd.Parameters["@ReturnValue"].Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                ReturnID = (int)cmd.Parameters["@ReturnValue"].Value;
                */

                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                cmd.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                ReturnID = (int)cmd.Parameters["@ReturnValue"].Value;
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        public static void ExecuteDBScalar(ParameterCollection ParameterCollection, string StoredProcName, string ConnectionString, out int ReturnValue)
        {
            DataHelper objData = new DataHelper
            {
                ConnectionString = ConnectionString,
                StoredProcName = StoredProcName,
                ParameterCollection = ParameterCollection
            };

            SqlCommand cmd = DataHelper.GetCommand(objData);
            try
            {
                ReturnValue = Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        public static Object HydrateObject<T>(SqlDataReader DR, ObjectPropertyDictionary PropertyValues)
        {
            //notes:    set recordcount property for object to 1 to indicate to UI that valid item exists
            Object objGeneric = DataHelper.GetObjectRecordCount<T>(1);

            //notes:    dynamically hydrates object properties and returns to calling program
            //          no need to get value from BaseObject property since object is passed into this method
            foreach (PropertyInfo info in objGeneric.GetType().GetProperties())
            {
                if (PropertyValues.ContainsKey(info.Name))
                {
                    switch (PropertyValues[info.Name])
                    {
                        case SqlDbType.Bit:
                            //info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? false : Convert.ToBoolean(DR[info.Name]), null);
                            //info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? null : Convert.ChangeType(DR[info.Name], typeof(bool?)), null);
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? null : DR[info.Name], null);
                            break;

                        case SqlDbType.BigInt:
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? -1 : Convert.ToInt64(DR[info.Name]), null);
                            break;

                        case SqlDbType.Int:
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? -1 : Convert.ToInt32(DR[info.Name]), null);
                            break;

                        case SqlDbType.VarChar:
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? "" : Convert.ToString(DR[info.Name]), null);
                            break;

                        case SqlDbType.DateTime:
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DR[info.Name]), null);
                            break;
                    }
                }
            }

            return objGeneric;
        }
        public static Object HydrateObject<T>(DataRow DR, ObjectPropertyDictionary PropertyValues)
        {
            //notes:    set recordcount property for object to 1 to indicate to UI that valid item exists
            Object objGeneric = DataHelper.GetObjectRecordCount<T>(1);

            //notes:    dynamically hydrates object properties and returns to calling program
            //          no need to get value from BaseObject property since object is passed into this method
            foreach (PropertyInfo info in objGeneric.GetType().GetProperties())
            {
                if (PropertyValues.ContainsKey(info.Name))
                {
                    switch (PropertyValues[info.Name])
                    {
                        case SqlDbType.Bit:
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? null : DR[info.Name], null);
                            //info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? null : Convert.ChangeType(DR[info.Name], typeof(bool?)), null);
                            break;
                        case SqlDbType.BigInt:
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? -1 : Convert.ToInt64(DR[info.Name]), null);
                            break;
                        case SqlDbType.Int:
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? -1 : Convert.ToInt32(DR[info.Name]), null);
                            break;
                        case SqlDbType.VarChar:
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? "" : Convert.ToString(DR[info.Name]), null);
                            break;
                        case SqlDbType.DateTime:
                            info.SetValue(objGeneric, DR[info.Name] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DR[info.Name]), null);
                            break;
                    }
                }
            }

            return objGeneric;
        }
        public static Object GetObjectRecordCount<T>(int RecordCount)
        {
            Object objGeneric = (T)Activator.CreateInstance(typeof(T));

            //notes:    make sure it exists before setting RecordCount property
            try
            {
                PropertyInfo info = objGeneric.GetType().GetProperty("RecordCount");
                info.SetValue(objGeneric, RecordCount, null);
            }
            catch
            {
            }

            return objGeneric;
        }

        #endregion
    }
}