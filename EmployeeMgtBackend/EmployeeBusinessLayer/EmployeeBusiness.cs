using EmployeeBusinessLayer.IEmployeeBusiness;
using EmployeeModel;
using EmployeeModelLayer;
using EmployeeRepositoryLayer.IRepository;
using System;

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

    }
}
