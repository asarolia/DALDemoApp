using System;
using Demo.Common;
using System.Data;

namespace Demo.Business
{
    public class Person : DemoBaseObject
    {
        #region Fields

        private int _personID = Constants.NullInt;
        private string _nameFirst = Constants.NullString;
        private string _nameLast = Constants.NullString;
        private DateTime _dob = Constants.NullDateTime;

        #endregion 

        #region Properties

        public int PersonID
        {
            get{return _personID;}
            set{_personID = value;}
        }

        public string NameFirst
        {
            get{return _nameFirst;}
            set{_nameFirst = value;}
        }

        public string NameLast
        {
            get{return _nameLast;}
            set{_nameLast = value;}
        }

        public DateTime DOB
        {
            get{return _dob;}
            set{_dob = value;}
        }


        #endregion 

        #region Methods

        public override bool MapData(DataRow row)
        {
            PersonID = GetInt(row, "PersonID");
            NameFirst = GetString(row, "NameFirst");
            NameLast = GetString(row, "NameLast");
            DOB = GetDateTime(row, "DOB");
            return base.MapData(row);
        }

        public static Person GetByPersonID(int personID)
        {
            Person obj = new Person();
            DataSet ds = new Demo.DataAccessLayer.PersonDataService().Person_GetByPersonID(personID);
            if (!obj.MapData(ds)) obj = null;
            return obj;
        }

        public static void Delete(int personID)
        {
            Delete(personID, null);
        }

        public static void Delete(int personID, IDbTransaction txn)
        {
            new Demo.DataAccessLayer.PersonDataService(txn).Person_Delete(personID);
        }

        public void Delete()
        {
            Delete(PersonID);
        }

        public void Delete(IDbTransaction txn)
        {
            Delete(PersonID, txn);
        }

        public void Save()
        {
            Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new Demo.DataAccessLayer.PersonDataService(txn).Person_Save(ref _personID, _nameFirst, _nameLast, _dob);
        }

        #endregion 
    }
}
