using EmployeeModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepositoryLayer
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {
        }
        public DbSet<EmployeeModels> EmployeeTable { get; set; }
        public EmployeeDBContext()
        { }
    }
}
