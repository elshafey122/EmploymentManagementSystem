using EmployeeManagementSystem.Core.IRepositories.IAuthRepositories;
using EmployeeManagementSystem.Core.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EF.Repositories.AuthRepositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly UserManager<IdentityUser> _usermanager ;
        private readonly RoleManager<IdentityRole> _rolemanager ;
        public AuthRepository(UserManager<IdentityUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }
        public async Task <int> Register(Register regster)
        {
            var user = await _usermanager.FindByEmailAsync(regster.Email);
            if (user != null)
            {
                return 0;
            }
            IdentityUser newuser = new IdentityUser()
            {
                Email = regster.Email,
                UserName = regster.UserName,
            };
            IdentityResult result =await _usermanager.CreateAsync(newuser, regster.Password);
            if (!result.Succeeded) 
            {
                return -1; 
            }
            return 1;
        }
    }
}
