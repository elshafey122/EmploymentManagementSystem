using AutoMapper;
using EmployeeManagementSystem.Core.Dto;
using EmployeeManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EF.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<DeptDto, Departement>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<TaskDto, Taski>();
        }
    }
}
