using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class EmployeeStorage
    {
        public static List<Employee> GetEmployees(string letter, bool isFirstLetter)
        {
            List<Employee> employees = new List<Employee>();

            DataTable employeesTable = GetPersonsWhoIsEmployeesFromDatabase(letter, isFirstLetter);

            foreach (DataRow row in employeesTable.Rows)
            {
                int businessEntityId = row.Field<int>("Persons.BusinessEntityID");
                string personType = row.Field<string>("Persons.PersonType");
                bool nameStyle = row.Field<bool>("Persons.NameStyle");
                string title = row.Field<string>("Persons.Title");
                string firstName = row.Field<string>("Persons.FirstName");
                string middleName = row.Field<string>("Persons.MiddleName");
                string lastName = row.Field<string>("Persons.LastName");
                string suffix = row.Field<string>("Persons.Suffix");
                int emailPromotion = row.Field<int>("Persons.EmailPromotion");
                string additionalContactInfo = row.Field<string>("Persons.AdditionalContactInfo");
                string demographics = row.Field<string>("Persons.Demographics").ToString();
                string personRowguid = row.Field<Guid>("Persons.Rowguid").ToString();
                DateTime personModifiedDate = row.Field<DateTime>("Persons.ModifiedDate");

                int nationalIdNumber = row.Field<int>("Employees.NationalIdNumber");
                string loginId = row.Field<string>("Employees.LoginId");
                string organizationNode = row.Field<string>("Employees.OrganizationNode");
                string organizationLevel = row.Field<string>("Employees.OrganizationLevel"); //убрать этот столбец из селекта, смотреть по типам полей
                string jobTitle = row.Field<string>("Employees.JobTitle");
                DateTime birthDate = row.Field<DateTime>("Employees.BirthDate");
                string maritalStatus = row.Field<string>("Employees.MaritalStatus");
                string gender = row.Field<string>("Employees.Gender");
                DateTime hireDate = row.Field<DateTime>("Employees.HireDate");
                int salariedFlag = row.Field<int>("Employees.SalariedFlag");
                int vacationHours = row.Field<int>("Employees.VacationHours");
                int sickLeaveHours = row.Field<int>("Employees.SickLeaveHours");
                int currentFlag = row.Field<int>("Employees.CurrentFlag");
                string employeeRowguid = row.Field<Guid>("Employees.Rowguid").ToString();
                DateTime employeeModifiedDate = row.Field<DateTime>("Employees.ModifiedDate");

                Employee employee = new Employee(businessEntityId, personType, nameStyle, title, firstName, middleName, lastName,
                    suffix, emailPromotion, additionalContactInfo, demographics, personRowguid, personModifiedDate, nationalIdNumber, loginId,
                    organizationNode, organizationLevel, jobTitle, birthDate, maritalStatus,
                    gender, hireDate, salariedFlag, vacationHours, sickLeaveHours, currentFlag,
                    employeeRowguid, employeeModifiedDate);

                employees.Add(employee);
            }

            return employees;
        }

        private static string connectionStr = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;

        private static DataTable GetPersonsWhoIsEmployeesFromDatabase(string letter, bool isFirstLetter)
        {
            DataTable persons = new DataTable("PersonsWhoIsEmployees");

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetPersonWhoIsEmployeeData", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter letterParam = new SqlParameter
                {
                    ParameterName = "@letter",
                    Value = letter
                };

                SqlParameter isFirstLetterParam = new SqlParameter
                {
                    ParameterName = "@isFirstLetter",
                    Value = isFirstLetter
                };

                command.Parameters.Add(letterParam);
                command.Parameters.Add(isFirstLetterParam);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(persons);
            }
            return persons;
        }
    }
}