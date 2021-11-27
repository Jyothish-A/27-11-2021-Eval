using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravelEvalApp.Models;
using TravelEvalApp.Repository;

namespace TravelEvalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {

		ITravel travel;

		private IConfiguration _config;

		public TravelController(ITravel _travel, IConfiguration config)
		{
			travel = _travel;
			_config = config;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login([FromBody] Login _user)
		{
			IActionResult response = Unauthorized();
			int user = await AuthenticateUser(_user);
			if (user > 0)
			{
				// var role = company.GetUserRole(user);
				var tokenString = GenerateJSONWebToken(_user);
				response = Ok(new { token = tokenString });
			}
			return response;
		}

		private object GenerateJSONWebToken(object user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			//   _config["jwt:Key"],


			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.Role, "ADMIN"));
			claims.Add(new Claim(ClaimTypes.Role, "HR"));
			claims.Add(new Claim(ClaimTypes.Role, "USER"));
			claims.Add(new Claim("customType", "customValue"));

			var token = new JwtSecurityToken(
				_config["jwt:Issuer"],
				_config["jwt:Issuer"],
				claims: claims,
				null,
				expires: DateTime.Now.AddMinutes(120),
				signingCredentials: credentials
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}


		private async Task<int> AuthenticateUser(Login user)
		{

			int user_id = await travel.UserExistCheck(user.Username, user.Password);


			if (user_id > 0)
			{
				return user_id;
			}
			return 0;
		}



		[AllowAnonymous]
		[HttpGet()]
		[Route("GetUserByUPT/{username}/{password}")]
		// [Authorize(AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> GetUserByUPT(string username, string password)
		{
			try
			{
				IActionResult response = Unauthorized();
				var employee = await travel.GetUserByUPT();
				var employeee = employee.Where(b => b.Username == username && b.Password == password)
					.FirstOrDefault();
				if (employeee == null)
				{
					return NotFound();
				}

				int user = await AuthenticateUser(employeee);
				if (user > 0)
				{
					// var role = company.GetUserRole(user);
					var tokenString = GenerateJSONWebToken(employeee);
					response = Ok(new
					{
						uName = employeee.Username,
						role = employeee.Usertype,
						token = tokenString
					});
				}
				return response;

			}

			catch (Exception)
			{
				return BadRequest();
			}
		}



			[HttpGet]
			[Route("GetUserByUP/{username}/{password}")]			
			// [Authorize(Roles = "Admin")]
			public async Task<IActionResult> GetUserByUP(string username, string password)
			{
				try
				{


					var employee = await travel.GetUserByUP();

					var employeee = employee.Where(b => b.Username == username && b.Password == password)
						.FirstOrDefault();

					if (employeee == null)
					{
						return NotFound();
					}
					return Ok(employeee);
				}
				catch (Exception)
				{
					return BadRequest();
				}
			}



		[HttpGet]
		[Route("GetRequests")]
		public async Task<IActionResult> GetRequests()
		{
			try
			{
				var requests = await travel.GetRequests();
				if (requests == null)
				{
					return NotFound();
				}
				return Ok(requests);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}


		[HttpPost]
		[Route("AddRequest")]
		public async Task<IActionResult> AddRequest([FromBody] Request r)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var result = await travel.AddRequest(r);
					if (result > 0)
					{
						return Ok(result);
					}
				}
				catch (Exception)
				{
					return BadRequest();
				}
			}
			return BadRequest();
		}


		[HttpPost]
		[Route("AddLogin")]
		public async Task<IActionResult> AddLogin([FromBody] Login r)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var result = await travel.AddLogin(r);
					if (result > 0)
					{
						return Ok(result);
					}
				}
				catch (Exception)
				{
					return BadRequest();
				}
			}
			return BadRequest();
		}

		[HttpPost]
		[Route("AddEmployee")]
		public async Task<IActionResult> AddEmployee([FromBody] Employee r)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var result = await travel.AddEmployee(r);
					if (result > 0)
					{
						return Ok(result);
					}
				}
				catch (Exception)
				{
					return BadRequest();
				}
			}
			return BadRequest();
		}



		[HttpPut]
		[Route("UpdateRequest")]
		public async Task<IActionResult> UpdateRequest([FromBody] Request r)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var result = await travel.UpdateRequest(r);
					if (result > 0)
					{
						return Ok(result);
					}
				}
				catch (Exception)
				{
					return BadRequest();
				}
			}
			return BadRequest();
		}





		[HttpGet]
		[Route("GetProjects")]
		public async Task<IActionResult> GetProjects()
		{
			try
			{
				var Projects = await travel.GetProjects();
				if (Projects == null)
				{
					return NotFound();
				}
				return Ok(Projects);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}


		[HttpPost]
		[Route("AddProject")]
		public async Task<IActionResult> AddProject([FromBody] Project r)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var result = await travel.AddProject(r);
					if (result > 0)
					{
						return Ok(result);
					}
				}
				catch (Exception)
				{
					return BadRequest();
				}
			}
			return BadRequest();
		}



		[HttpPut]
		[Route("UpdateProject")]
		public async Task<IActionResult> UpdateProject([FromBody] Project r)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var result = await travel.UpdateProject(r);
					if (result > 0)
					{
						return Ok(result);
					}
				}
				catch (Exception)
				{
					return BadRequest();
				}
			}
			return BadRequest();
		}



		[HttpGet]
		[Route("GetEmployees")]
		public async Task<IActionResult> GetEmployees()
		{
			try
			{
				var requests = await travel.GetEmployees();
				if (requests == null)
				{
					return NotFound();
				}
				return Ok(requests);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}



	}
}
