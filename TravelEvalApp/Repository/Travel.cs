using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelEvalApp.Models;

namespace TravelEvalApp.Repository
{
    public class Travel : ITravel
    {
        TRAVELContext db;

        public Travel(TRAVELContext _db)
        {
            db = _db;
        }


        public async Task<int> UserExistCheck(string username, string password)
        {
            var user = await (from u in db.Login
                              where username == u.Username &&
                              password == u.Password
                              select new Login
                              {
                                  Loginid = u.Loginid,
                                  Username = u.Username,
                                  Password = u.Password,
                                  Usertype = u.Usertype
                              }
                             ).ToListAsync();

            Console.WriteLine(user);

            if (user.Count > 0)
            {
                return user[0].Loginid;
            }
            return 0;
        }



        public async Task<List<Login>> GetUserByUPT()
        {
            if (db != null)
            {
                return await db.Login.ToListAsync();
            }
            return null;
        }


        public async Task<List<Login>> GetUserByUP()
        {
            if (db != null)
            {
                return await db.Login.ToListAsync();
            }
            return null;
        }

        public async Task<List<Request>> GetRequests()
        {
            if (db != null)
            {
                return await db.Request.ToListAsync();
            }
            return null;
        }

        public async Task<int> AddRequest(Request r)
        {
            if (db != null)
            {
                await db.Request.AddAsync(r);
                await db.SaveChangesAsync();
                return (int)r.Requestid;
                //return 1;
            }
            return 0;
        }


        public async Task<int> AddLogin(Login r)
        {
            if (db != null)
            {
                await db.Login.AddAsync(r);
                await db.SaveChangesAsync();
                return (int)r.Loginid;
                //return 1;
            }
            return 0;
        }

        public async Task<int> AddEmployee(Employee r)
        {
            if (db != null)
            {
                await db.Employee.AddAsync(r);
                await db.SaveChangesAsync();
                return (int)r.EmpId;
                //return 1;
            }
            return 0;
        }

        public async Task<int> UpdateRequest(Request r)
        {
            if (db != null)
            {
                db.Request.Update(r);
                await db.SaveChangesAsync();
                //return (int)bc.Id;
                return r.Requestid;
            }
            return 0;
        }





        public async Task<List<Project>> GetProjects()
        {
            if (db != null)
            {
                return await db.Project.ToListAsync();
            }
            return null;
        }

        public async Task<int> AddProject(Project r)
        {
            if (db != null)
            {
                await db.Project.AddAsync(r);
                await db.SaveChangesAsync();
                return (int)r.ProjectId;
                //return 1;
            }
            return 0;
        }

        public async Task<int> UpdateProject(Project r)
        {
            if (db != null)
            {
                db.Project.Update(r);
                await db.SaveChangesAsync();
                //return (int)bc.Id;
                return r.ProjectId;
            }
            return 0;
        }



        public async Task<List<Employee>> GetEmployees()
        {
            if (db != null)
            {
                return await db.Employee.ToListAsync();
            }
            return null;
        }


    }
}
