using EmployeeModel;
using EmployeeModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBusinessLayer.IEmployeeBusiness
{
    public interface IEmployeeBusines
    {
        EmployeeModels LoginUser(LoginModel login);

        EmployeeModels CreateEmployee(EmployeeModels add);

    }
}
