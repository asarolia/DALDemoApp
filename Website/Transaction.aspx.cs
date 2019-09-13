using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Demo.DataAccessLayer;
using Demo.Business;

public partial class Transaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //This is just an example and is not meant to actually run
        if (false)
        {
            Person personA = Person.GetByPersonID(1);
            Person personB = Person.GetByPersonID(2);
            Person personC = Person.GetByPersonID(3);

            IDbTransaction txn = DataServiceBase.BeginTransaction();
            try
            {
                personA.Save(txn);
                personB.Save(txn);
                personC.Delete(txn);
                txn.Commit();
            }
            catch
            {
                //An error occured so roll the transaction back
                txn.Rollback();
            }
        }
        
    }
}
