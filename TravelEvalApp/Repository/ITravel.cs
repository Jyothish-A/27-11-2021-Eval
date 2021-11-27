using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEvalApp.Models;

namespace TravelEvalApp.Repository
{
    public interface ITravel
    {
        Task<int> UserExistCheck(string username, string password);

        Task<List<Login>> GetUserByUPT();

        Task<List<Login>> GetUserByUP();

        Task<List<Request>> GetRequests();
        Task<int> AddRequest(Request r);
        Task<int> UpdateRequest(Request r);

        Task<List<Project>> GetProjects();
        Task<int> AddProject(Project r);
        Task<int> UpdateProject(Project r);


        Task<List<Employee>> GetEmployees();

        Task<int> AddLogin(Login r);

        Task<int> AddEmployee(Employee r);



    }
}
