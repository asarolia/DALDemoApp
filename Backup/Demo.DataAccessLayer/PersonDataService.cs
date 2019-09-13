using System;
using System.Data;
using System.Data.SqlClient;
using Demo.Common;


/// <summary>
/// Summary description for DemoDataService
/// </summary>

namespace Demo.DataAccessLayer
{

    public class PersonDataService : DataServiceBase
    {
        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public PersonDataService() : base() { }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public PersonDataService(IDbTransaction txn) : base(txn) { }


        public DataSet Person_GetAll()
        {
            return ExecuteDataSet("Person_GetAll", null);
        }


        public DataSet Person_GetByPersonID(int personID)
        {
            return ExecuteDataSet("Person_GetByPersonID", 
                CreateParameter("@PersonID", SqlDbType.Int, personID));
        }
        
        public void Person_Save(ref int personID, string nameFirst, string nameLast, DateTime dob)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Person_Save",
                CreateParameter("@PersonID", SqlDbType.Int, personID, ParameterDirection.InputOutput),
                CreateParameter("@NameFirst", SqlDbType.NVarChar, nameFirst),
                CreateParameter("@NameLast", SqlDbType.NVarChar, nameLast),
                CreateParameter("@DOB", SqlDbType.DateTime, dob));            
            personID = (int)cmd.Parameters["@PersonID"].Value;
            cmd.Dispose();
        }

        
        public void Person_Delete(int personID)
        {
            ExecuteNonQuery("Person_Delete",
                CreateParameter("@PersonID", SqlDbType.Int, personID));
        }

    } //class

} //namespace