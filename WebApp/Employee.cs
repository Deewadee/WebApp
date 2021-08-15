using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Employee : Person
    {
        public Employee()
        {
        }

        public Employee(int businessEntityId, string personType, bool nameStyle, string title, string firstName, string middleName,
            string lastName, string suffix, int emailPromotion, string additionalContactInfo, string demographics, string personRowguid, 
            DateTime personModifiedDate, int nationalIdNumber, string loginId, string organizationNode, string organizationLevel, 
            string jobTitle, DateTime birthDate, string maritalStatus, string gender, DateTime hireDate, int salariedFlag, 
            int vacationHours, int sickLeaveHours, int currentFlag, string employeeRowguid, DateTime employeeModifiedDate) : base
            (businessEntityId, personType, nameStyle, title, firstName, middleName, lastName, suffix, 
             emailPromotion, additionalContactInfo, demographics, personRowguid, personModifiedDate)
        {
            _nationalIdNumber = nationalIdNumber;
            _loginId = loginId;
            _organizationNode = organizationNode;
            _organizationLevel = organizationLevel;
            _jobTitle = jobTitle;
            _birthDate = birthDate;
            _maritalStatus = maritalStatus;
            _gender = gender;
            _hireDate = hireDate;
            _salariedFlag = salariedFlag;
            _vacationHours = vacationHours;
            _sickLeaveHours = sickLeaveHours;
            _currentFlag = currentFlag;
            _rowguid = employeeRowguid;
            _modifiedDate = employeeModifiedDate;
        }

        public int NationalIdNumber
        {
            get
            {
                return _nationalIdNumber;
            }
        }

        public string LoginId
        {
            get
            {
                return CheckValue(_loginId);
            }
        }

        public string OrganizationNode
        {
            get
            {
                return CheckValue(_organizationNode);
            }
        }

        public string OrganizationLevel 
        {
            get
            {
                return CheckValue(_organizationLevel);
            }
        }

        public string JobTitle
        {
            get
            {
                return CheckValue(_jobTitle);
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
        }

        public string MaritalStatus
        {
            get
            {
                return CheckValue(_maritalStatus);
            }
        }

        public string Gender
        {
            get
            {
                return CheckValue(_gender);
            }
        }

        public DateTime HireDate
        {
            get
            {
                return _hireDate;
            }
        }

        public int SalariedFlag
        {
            get
            {
                return _salariedFlag;
            }
        }

        public int VacationHours
        {
            get
            {
                return _vacationHours;
            }
        }

        public int SickLeaveHours
        {
            get
            {
                return _sickLeaveHours;
            }
        }

        public int CurrentFlag
        {
            get
            {
                return _currentFlag;
            }
        }

        public new string Rowguid
        {
            get
            {
                return CheckValue(_rowguid);
            }
        }

        public new DateTime ModifiedDate
        {
            get
            {
                return _modifiedDate;
            }
        }

        private static string CheckValue(string value)
        {
            return string.IsNullOrEmpty(value) ? "" : value;
        }

        private int _nationalIdNumber;
        private string _loginId;
        private string _organizationNode;
        private string _organizationLevel;
        private string _jobTitle;
        private DateTime _birthDate;
        private string _maritalStatus;
        private string _gender;
        private DateTime _hireDate;
        private int _salariedFlag;
        private int _vacationHours;
        private int _sickLeaveHours;
        private int _currentFlag;
        private string _rowguid;
        private DateTime _modifiedDate;
    }
}