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
using System.Text;
using System.Text.RegularExpressions;

namespace WebApp
{
    public partial class NumberLettersAndRowsPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayDefaultPage.Text = "Главная страница";
            displayPreviousPage.Text = "Предыдущая страница";

            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }

            DisplayNumbersLettersAndRows();
        }

        private void DisplayNumbersLettersAndRows()
        {
            int numberLetters;
            int numberRows;

            GetNumberInputedLettersAndRows(Letter, out numberLetters, out numberRows);

            numberLettersLabel.Text = $"<div><label>Количество вхождений буквы '{Letter}' в именах равно: {numberLetters}</label></div>";
            numberRowsLabel.Text = $"<div><label>Количество вхождений буквы '{Letter}' в строках равно: {numberRows}</label></div>";
        }

        private static void GetNumberInputedLettersAndRows(string letter, out int numberLetters, out int numberRows)
        {
            int letterCounter = 0;

            List<Person> persons = PersonsStorage.GetPersons(letter, false);

            foreach (Person person in persons)
            {
                foreach (char word in person.FirstName)
                {
                    if (word.ToString().Equals(letter))
                    {
                        letterCounter++;
                    }
                }
            }

            numberLetters = letterCounter;
            numberRows = persons.Count();
        }

        protected void DisplayDefaultPage(object sender, EventArgs e)
        {
            DisplayNewPage("Default.aspx");
        }

        protected void DisplayPreviousPage(object sender, EventArgs e)
        {
            string refUrl = ViewState["RefUrl"].ToString();

            if (!string.IsNullOrEmpty(refUrl))
            {
                DisplayNewPage(refUrl);
            }
        }

        private void DisplayNewPage(string pageName)
        {
            Response.Redirect(pageName);
        }

        private string Letter
        {
            get
            {
                return Request.QueryString["Letter"];
            }
        }

        private string IsEmployee
        {
            get
            {
                return Request.QueryString["IsEmployee"];
            }
        }
    }
}