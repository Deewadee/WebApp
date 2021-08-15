using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Web.ModelBinding;

namespace WebApp
{
    public partial class Default : Page
    {
        private void Page_Load(object sender, EventArgs e)
        {
            displayNamesBtn.Text = "Вывести имена, начинающиеся с этой буквы";
            displayCountLettersBtn.Text = "Вывести количество вхождений буквы в имена";
        }

        protected void DisplayNumberLettersAndRowsPage(object sender, EventArgs e)
        {
            CheckInputedLetter("NumberLettersAndRowsPage.aspx");
        }

        protected void DisplayPersonsPageOrEmployeesPage(object sender, EventArgs e)
        {
            if (!IsEmployeeCheckBox.Checked)
            {
                CheckInputedLetter("ListFirstNamesPage.aspx");
            }
            else
            {
                CheckInputedLetter("ListEmployeesPage.aspx");
            }
        }

        private void CheckInputedLetter(string pageName)
        {
            string inputedValue = GetInputedLetter();

            if (Page.IsValid)
            {
                DisplayNewPage(pageName + "?Letter=" + inputedValue);
            }
        }

        private void DisplayNewPage(string pageName)
        {
            Response.Redirect(pageName);
        }

        private string GetInputedLetter()
        {
            return inputTextBox.Text;
        }
    }
}