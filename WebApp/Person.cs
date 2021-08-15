using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;

namespace WebApp
{
    [Serializable]
    public class Person
    {
        public Person()
        {
        }

        public Person(int businessEntityId)
        {
            _businessEntityId = businessEntityId;
        }

        public Person(int businessEntityId, string personType, bool nameStyle, string title, string firstName, string middleName,
            string lastName, string suffix, int emailPromotion, string additionalContactInfo, string demographics, string rowguid, DateTime modifiedDate)
        {
            _businessEntityId = businessEntityId;
            _personType = personType;
            _nameStyle = nameStyle;
            _title = title;
            _firstName = firstName;
            _middleName = middleName;
            _lastName = lastName;
            _suffix = suffix;
            _emailPromotion = emailPromotion;
            _additionalContactInfo = additionalContactInfo;
            _demographics = demographics;
            _rowguid = rowguid;
            _modifiedDate = modifiedDate;
        }

        public int BusinessEntityId
        {
            get
            {
                return _businessEntityId;
            }
        }
        public string PersonType
        {
            get
            {
                return CheckValue(_personType);
            }
        }
        public bool NameStyle
        {
            get
            {
                return _nameStyle;
            }
        }
        public string Title
        {
            get
            {
                return CheckValue(_title);
            }
        }
        public string FirstName
        {
            get
            {
                return CheckValue(_firstName);
            }
        }
        public string MiddleName
        {
            get
            {
                return CheckValue(_middleName);
            }
        }
        public string LastName
        {
            get
            {
                return CheckValue(_lastName);
            }
        }
        public string Suffix
        {
            get
            {
                return CheckValue(_suffix);
            }
        }
        public int EmailPromotion
        {
            get
            {
                return _emailPromotion;
            }
        }
        public string AdditionalContactInfo
        {
            get
            {
                return CheckValue(_additionalContactInfo);
            }
        }
        public string Demographics
        {
            get
            {
                return CheckValue(_demographics);
            }
        }
        public string Rowguid
        {
            get
            {
                return CheckValue(_rowguid);
            }
        }
        public DateTime ModifiedDate
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

        private int _businessEntityId;
        private bool _nameStyle;
        private int _emailPromotion;
        private string _personType;
        private string _title;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _suffix;
        private string _additionalContactInfo;
        private string _demographics;
        private string _rowguid;
        private DateTime _modifiedDate;
    }
}