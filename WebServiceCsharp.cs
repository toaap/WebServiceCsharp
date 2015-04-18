using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Data.SqlClient;


/// <summary>
/// Summary description for WebServiceCsharp
/// </summary>
[WebService(Namespace = "http://grupp14VT.lu.se")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceCsharp : System.Web.Services.WebService {

    private Controller controller = new Controller();

    public class Apartment
    {
        private string apartmentNr;
        
        public string ApartmentNr
        {
            get { return apartmentNr; }
            set { apartmentNr = value; }
        }

        public Apartment() { }

        public Apartment(global::Apartment apartment) 
        {
            ApartmentNr = apartment.apartmentNr;
        }
    }
    /*
     *static string error;

    [WebMethod]
    public string getError  (){
        return error;
    }
     * */

    public class Employee
    {
        public Employee() { }

        public Employee(string id, string firstName)
        {
            this.id = id;
            this.firstName = firstName;
        }

        public string id { get; set; }

        public string firstName { get; set; }

    }

    public WebServiceCsharp () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<Apartment> GetAllApartments()
    {
        List<Apartment> apartments = new List<Apartment>();
        
        
        foreach (global::Apartment apartment in controller.GetAllApartments())
        {
            Apartment newApartment = new Apartment(apartment);
            apartments.Add(newApartment);
        }

        return apartments;
        
    }


    [WebMethod]
    public string GetFileContent(string filename)
    {
        //Try allt
        if (filename != null)
        {
            StreamReader streamReader = new StreamReader(filename);
            string text = streamReader.ReadToEnd();
            streamReader.Close();

            return text;
        }
        return null;
        //catch io ex - Sparar errormeddelandet i errorklass
        
    }

    //SQL DATA
    [WebMethod]
    public List<List<string>> GetEmployees()
    {
        return controller.GetEmployees();
    }

    [WebMethod]
    public List<List<string>> GetRelative()
    {
        return controller.GetRelative();
    }

    [WebMethod]
    public List<List<string>> GetEmployeeAbsence()
    {
        return controller.GetEmployeeAbsence();
    }
    
    [WebMethod]
    public List<List<string>> GetSickestEmployee()
    {
        return controller.GetSickestEmployee();
    }

    //SQL META
    [WebMethod]
    public List<List<string>> GetKeys()
    {
        return controller.GetKeys();
    }

    [WebMethod]
    public List<List<string>> GetIndexes()
    {
        return controller.GetIndexes();
    }

    [WebMethod]
    public List<List<string>> GetConstraints()
    {
        return controller.GetConstraints();
    }

    [WebMethod]
    public List<List<string>> GetAllTables()
    {
        return controller.GetAllTables();
    }

    [WebMethod]
    public List<List<string>> GetAllTables2()
    {
        return controller.GetAllTables2();
    }

    [WebMethod]
    public List<List<string>> GetEmployeesMeta()
    {
        return controller.GetEmployeesMeta();
    }

    [WebMethod]
    public List<List<string>> GetEmployeesMeta2()
    {
        return controller.GetEmployeesMeta2();
    }

    //-----Add/remove/insert/update---------

    [WebMethod]
    public Employee GetEmployee(string id)
    {
        SqlDataReader sqlReader = controller.GetEmployee(id);
        
        Employee emp = null;

        while (sqlReader.Read())
        {
            emp = new Employee();
            emp.id = sqlReader.GetString(0);
            emp.firstName = sqlReader.GetString(1);
        }

        return emp;
    }

    [WebMethod]
    public void AddEmployee(string id, string firstName)
    {
        controller.AddEmployee(id, firstName);
    }

    [WebMethod]
    public void DeleteEmployee(string id)
    {
        controller.DeleteEmployee(id);
    }

    [WebMethod]
    public void UpdateEmployee(string id, string firstName)
    {
        controller.UpdateEmployee(id, firstName);
    }
    
}

