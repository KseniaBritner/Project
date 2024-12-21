using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomen
{
    public class EmployeeTest
    {

        //Нулевой Employee
        [Fact]
        public void Create_ThrowArgumentException_NameIsNull()
        {
            var exception = Assert.Throws<ArgumentException>(() => Employee.Create(null, Guid.NewGuid(), Guid.NewGuid()));
            Assert.StartsWith("Имя не может быть пустым или состоять только из пробелов.", exception.Message);
            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void Create_ThrowArgumentException_NameIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => Employee.Create(string.Empty, Guid.NewGuid(), Guid.NewGuid()));
            Assert.StartsWith("Имя не может быть пустым или состоять только из пробелов.", exception.Message);
            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void Create_ThrowArgumentException_NameIsWhiteSpace()
        {
            var exception = Assert.Throws<ArgumentException>(() => Employee.Create("    ", Guid.NewGuid(), Guid.NewGuid()));
            Assert.StartsWith("Имя не может быть пустым или состоять только из пробелов.", exception.Message);
            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void Create_ThrowArgumentException_RoleIdIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => Employee.Create("John", Guid.Empty, Guid.NewGuid()));
            Assert.StartsWith("RoleId не может быть пустым.", exception.Message);
            Assert.Equal("roleId", exception.ParamName);
        }

        [Fact]
        public void Create_ThrowArgumentException_CompanyIdIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => Employee.Create("John", Guid.NewGuid(), Guid.Empty));
            Assert.StartsWith("CompanyId не может быть пустым.", exception.Message);
            Assert.Equal("companyId", exception.ParamName);
        }

        [Fact]
        public void Create_ShouldCreateEmployee_ValidInputs()
        {
            var roleId = Guid.NewGuid();
            var companyId = Guid.NewGuid();
            var employee = Employee.Create("John", roleId, companyId);

            Assert.NotNull(employee);
            Assert.Equal("John", employee.Name);
            Assert.Equal(roleId, employee.RoleId);
            Assert.Equal(companyId, employee.CompanyId);
        }

        [Fact]
        public void Create_ShouldThrowArgumentException_RoleIdIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => Employee.Create("John", Guid.Empty, Guid.NewGuid()));
            Assert.StartsWith("RoleId не может быть пустым.", exception.Message);
            Assert.Equal("roleId", exception.ParamName);
        }

    }
}
