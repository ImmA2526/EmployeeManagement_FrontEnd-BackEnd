using EmployeeModel;
using EmployeeModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepositoryLayer.IRepository
{
    public interface IEmployeeRepository
    {
        EmployeeModels RegisterEmployee(EmployeeModels create);
        
        EmployeeModels LoginUser(LoginModel login);
    }
}
