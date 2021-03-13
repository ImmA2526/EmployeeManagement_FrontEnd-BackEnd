using EmployeeBusinessLayer.IEmployeeBusiness;
using EmployeeModel;
using EmployeeModelLayer;
using EmployeeRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;

namespace EmployeeBusinessLayer
{
    public class EmployeeBusiness : IEmployeeBusines
    {
        IEmployeeRepository employeeRepo;

        public EmployeeBusiness(IEmployeeRepository employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public EmployeeModels RegisterEmployee(EmployeeModels create)
        {
            var add = employeeRepo.RegisterEmployee(create);
            return add;
        }

        public EmployeeModels LoginUser(LoginModel login)
        {
            var logins = employeeRepo.LoginUser(login);
            return logins;
        }

        public IEnumerable<EmployeeModels> GetAllEmployees()
        {
            var getEmployee = employeeRepo.GetAllEmployees();
            return getEmployee;
        }

        public IEnumerable<EmployeeModels> GetEmployee_ID(int employeeId)
        {
            var getById = employeeRepo.GetEmployee_ID(employeeId);
            return getById;
        }
    }
}
