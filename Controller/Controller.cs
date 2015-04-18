using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Controller
/// </summary>
public class Controller
{
    private DataAccessLayer dal = new DataAccessLayer();

	public Controller()
	{

	}

    public List<Apartment> GetAllApartments()
    {
        return dal.GetAllApartments();
    }

    public List<List<string>> GetEmployees()
    {
        return dal.GetEmployees();
    }

    public List<List<string>> GetRelative()
    {
        return dal.GetRelative();
    }
    
    public List<List<string>> GetEmployeeAbsence()
    {
        return dal.GetEmployeeAbsence();
    }

    public List<List<string>> GetSickestEmployee()
    {
        return dal.GetSickestEmployee();
    }

    public List<List<string>> GetKeys()
    {
        return dal.GetKeys();
    }

    public List<List<string>> GetIndexes()
    {
        return dal.GetIndexes();
    }

    public List<List<string>> GetConstraints()
    {
        return dal.GetConstraints();
    }

    public List<List<string>> GetAllTables()
    {
        return dal.GetAllTables();
    }

    public List<List<string>> GetAllTables2()
    {
        return dal.GetAllTables2();
    }

    public List<List<string>> GetEmployeesMeta()
    {
        return dal.GetEmployeesMeta();
    }

    public List<List<string>> GetEmployeesMeta2()
    {
        return dal.GetEmployeesMeta2();
    }

    //---------add/remove/insert/update-------------

    public SqlDataReader GetEmployee(string id)
    {
        return dal.GetEmployee(id);
    }

    public void AddEmployee(string id, string firstName)
    {
        dal.AddEmployee(id, firstName);
    }

    public void DeleteEmployee(string id)
    {
        dal.DeleteEmployee(id);
    }

    public void UpdateEmployee(string id, string firstName)
    {
        dal.UpdateEmployee(id, firstName);
    }

}