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

using Demo.Business;

public partial class PersonShowAll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        gridPeople.DataSource = PersonCollection.GetAll();
        gridPeople.DataBind();
    }
    protected void lnkDeleteSelected_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form["chkSelectedItems"]))
        {
            string[] selectedItems = Request.Form["chkSelectedItems"].Split(',');
            for (int i = 0; i < selectedItems.Length; i++)
            {
                try
                {
                    Person.Delete(int.Parse(selectedItems[i]));
                }
                catch
                {
                }
            }
            gridPeople.DataSource = PersonCollection.GetAll();
            gridPeople.DataBind();
        }        
    }
}
