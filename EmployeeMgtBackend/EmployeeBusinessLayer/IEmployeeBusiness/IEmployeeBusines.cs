using EmployeeModel;
using EmployeeModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBusinessLayer.IEmployeeBusiness
{
    public interface IEmployeeBusines
    {
        EmployeeModels RegisterEmployee(EmployeeModels create);

        EmployeeModels LoginUser(LoginModel login);

        IEnumerable<EmployeeModels> GetAllEmployees();

        IEnumerable<EmployeeModels> GetEmployee_ID(int employeeId);

        EmployeeModels UpdateEmployee(EmployeeModels updateEmployee);

        string DeleteEmployee(int employeeId);
    }
}
