using System;
using Demo.DataAccessLayer;

namespace Demo.Business
{
    public class PersonCollection : DemoBaseCollection<Person>
    {
        public static PersonCollection GetAll()
        {
            PersonCollection obj = new PersonCollection();
            obj.MapObjects(new PersonDataService().Person_GetAll());
            return obj;
        }

    }
}
