using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomen
{
    public class RoleTest
    {
        //правильная инициализация объекта
        [Fact]
        public void ValidArguments_Initializes()
        {
            var roleId = Guid.NewGuid();
            var roleName = "Admin";

            var role = new Role(roleId, roleName);

            Assert.Equal(roleId, role.Id);  
            Assert.Equal(roleName, role.Name); 
        }

        // конструктор выбрасывает исключение на null Name
        [Fact]
        public void NameIsNull_ThrowsArgumentException()
        {
            string roleName = null; 

            var exception = Assert.Throws<ArgumentNullException>(() => Role.Create(roleName)); 
            Assert.StartsWith("Имя роли не может быть null.", exception.Message); 
            Assert.Equal("name", exception.ParamName); 
        }

        [Fact]
        public void NameIsEmpty_ThrowsArgumentException()
        {
            string roleName = ""; 

            var exception = Assert.Throws<ArgumentException>(() => Role.Create(roleName)); 
            Assert.StartsWith("Имя роли не может быть пустым или состоять только из пробелов.", exception.Message); 
            Assert.Equal("name", exception.ParamName); 
        }

        // проверка на нулевую Role
        [Fact]
        public void Create_ThrowArgumentNullException_NameIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => Role.Create(null));
            Assert.StartsWith("Имя роли не может быть null.", exception.Message);
            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void Create_ThrowArgumentException_NameIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => Role.Create(string.Empty));
            Assert.StartsWith("Имя роли не может быть пустым или состоять только из пробелов.", exception.Message);
            Assert.Equal("name", exception.ParamName);

        }

        [Fact]
        public void Create_ThrowArgumentException_NameIsWhiteSpace()
        {
            var exception = Assert.Throws<ArgumentException>(() => Role.Create("    "));
            Assert.StartsWith("Имя роли не может быть пустым или состоять только из пробелов.", exception.Message);
            Assert.Equal("name", exception.ParamName);

        }

        [Fact]
        public void CreateRole_ShouldAssignGuidAndName()
        {
            string expectedName = "Admin";
            Role role = Role.Create(expectedName);

            Assert.NotEqual(Guid.Empty, role.Id);
            Assert.Equal(expectedName, role.Name);
        }
    }
}
