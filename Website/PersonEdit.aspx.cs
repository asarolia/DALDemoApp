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
using Demo.Common;

public partial class PersonEdit : System.Web.UI.Page
{

    private Person _person;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Acquire the PersonID from the querystring
        int personID = 0;
        if (Request.QueryString["PersonID"] != null)
        {
            try
            {
                personID = int.Parse(Request.QueryString["PersonID"]);
            }
            catch
            {
            }
        }

        //Attempt to get the person if there is a PersonID
        if(personID > 0) _person = Person.GetByPersonID(personID);

        //Populate the form if this is the first request
        if(!IsPostBack)
        {
            //Only populate the form if the person object is valid
            if (_person != null)
            {
                lblPersonID.Text = _person.PersonID.ToString();
                txtNameFirst.Text = _person.NameFirst;
                txtNameLast.Text = _person.NameLast;
                if (_person.DOB != Constants.NullDateTime)
                {
                    txtDOB.Text = _person.DOB.ToString("M/d/yyyy");
                }
            }
            else
            {               
                //Display a message indicating that you are adding a person
                lblPersonID.Text = "New Person";
            }
        }
    }

    protected void cmdSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (_person == null) _person = new Person();
            _person.NameFirst = txtNameFirst.Text;
            _person.NameLast = txtNameLast.Text;
            if (!string.IsNullOrEmpty(txtDOB.Text))
            {
                _person.DOB = Convert.ToDateTime(txtDOB.Text);
            }
            else
            {
                _person.DOB = Constants.NullDateTime;
            }

            _person.Save();
            Response.Redirect("PersonShowAll.aspx");

        }
    }
}
