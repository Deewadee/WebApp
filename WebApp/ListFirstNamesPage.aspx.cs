using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text;

namespace WebApp
{
    public partial class ListFirstNamesPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayDefaultPageButton.Text = "Главная страница";
            displayPreviousButton.Text = "Предыдущая страница";

            if (!IsPostBack)
            {
                AddPersonsIntoViewState();
                BindData();
                AddReferenceUrlIntoViewState();
            }

            messageLabel.Text = $"Количество имён, начинающихся с буквы '{Letter}' равно: {NumberWords}";
        }

        protected void GridViewPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPersonsFirstNames.PageIndex = e.NewPageIndex;

            BindData();
        }

        private void BindData()
        {
            if (Persons != null)
            {
                gvPersonsFirstNames.DataSource = Persons;
                gvPersonsFirstNames.DataBind();
            }
        }

        protected void DisplayPersonPage(object sender, EventArgs e)
        {
            int businessEntityId = int.Parse((sender as LinkButton).CommandArgument);
            AddPersonIntoSession(businessEntityId);

            DisplayNewPage("PersonPage.aspx");
        }

        private void AddPersonIntoSession(int id)
        {
            var person = Persons.Where(pers => pers.BusinessEntityId == id);

            AddObjectIntoSession("Person", person);
        }

        private void AddObjectIntoSession(string sessionObjectName, object addedObject)
        {
            Session[sessionObjectName] = addedObject;
        }

        private void AddReferenceUrlIntoViewState()
        {
            string refUrl = Request.UrlReferrer.ToString();

            AddObjectIntoViewState("RefUrl", refUrl);
        }

        private void AddPersonsIntoViewState()
        {
            List<Person> persons = PersonsStorage.GetPersons(Letter, true);

            AddObjectIntoViewState("Persons", persons);
        }

        private void AddObjectIntoViewState(string viewStateObjectName, object addedObject)
        {
            ViewState[viewStateObjectName] = addedObject;
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

        private List<Person> Persons
        {
            get
            {
                return (List<Person>)ViewState["Persons"];
            }
        }

        private int NumberWords
        {
            get
            {
                List<Person> persons = Persons;

                return (int)persons.Count();
            }
        }
    }
}