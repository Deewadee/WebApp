using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class PersonsStorage
    {
        public static List<Person> GetPersons(string letter, bool isFirstLetter)
        {
            List<Person> persons = new List<Person>();

            DataTable personsTable = GetPersonsFromDatabase(letter, isFirstLetter);

            foreach (DataRow row in personsTable.Rows)
            {
                int businessEntityId = row.Field<int>("BusinessEntityID");
                string personType = row.Field<string>("PersonType");
                bool nameStyle = row.Field<bool>("NameStyle");
                string title = row.Field<string>("Title");
                string firstName = row.Field<string>("FirstName");
                string middleName = row.Field<string>("MiddleName");
                string lastName = row.Field<string>("LastName");
                string suffix = row.Field<string>("Suffix");
                int emailPromotion = row.Field<int>("EmailPromotion");
                string additionalContactInfo = row.Field<string>("AdditionalContactInfo");
                string demographics = row.Field<string>("Demographics");
                string rowguid = row.Field<Guid>("Rowguid").ToString();
                DateTime modifiedDate = row.Field<DateTime>("ModifiedDate");

                Person person = new Person(businessEntityId, personType, nameStyle, title, firstName, middleName, lastName,
                    suffix, emailPromotion, additionalContactInfo, demographics, rowguid, modifiedDate);

                persons.Add(person);
            }

            return persons;
        }

        private static DataTable GetPersonsFromDatabase(string letter, bool isFirstLetter)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            client.Open();

            DataTable persons = new DataTable();

            persons = client.GetPersonsFromDatabase(letter, isFirstLetter);

            client.Close();

            return persons;
        }
    }
}