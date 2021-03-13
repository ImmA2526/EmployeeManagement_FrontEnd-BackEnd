using EmployeeModel;
using EmployeeModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepositoryLayer.IRepository
{
    public interface IEmployeeRepository
    {
        EmployeeModels LoginUser(LoginModel login);

        EmployeeModels CreateEmployee(EmployeeModels add);
    }
}
