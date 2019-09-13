using System;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for DemoDataService
/// </summary>

namespace Demo.DataAccessLayer
{

    public class DemoDataService
    {
        #region Constructor

        ////////////////////////////////////////////////////////////////////////
        #region Constructors

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public DemoDataService()
        { 
        }

        ////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///	Creates a new DataService and specifies a transaction with
        ///	which to operate
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public DemoDataService(IDbTransaction txn) : this()
        {
        }

        #endregion

        #endregion

        public DataSet TestProcA(int paramInt, string paramVarChar, Guid paramGuid)
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            DataRow dr = dt.Rows.Add(paramInt, paramVarChar, paramGuid);
            return ds;
        }

        public int TestProcB(int paramInputCode)
        {
            return paramInputCode;
        }

        public void TestProcC()
        {
            //no code
        }

    }

}