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
    }
}
