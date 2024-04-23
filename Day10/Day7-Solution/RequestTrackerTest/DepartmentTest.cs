using NUnit.Framework;
using RequestTrackerDALLibery;
using RequestTrackerModelLibery;
using System.Collections.Generic;

namespace RequestTrackerTest
{
    public class DepartmentTest
    {
        private DepartmentRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
        }

        [Test]
        public void Add_Successful()
        {
            // Arrange
            Department department = new Department() { Name = "IT", Department_Head = 101 };

            // Act
            var result = repository.Add(department);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(department, result);
            Assert.IsTrue(repository.GetAll().Contains(department));
        }

        [Test]
        public void Add_Fail_DuplicateId()
        {
            // Arrange
            Department department1 = new Department() { Id = 1, Name = "IT", Department_Head = 101 };
            Department department2 = new Department() { Id = 1, Name = "HR", Department_Head = 102 };

            // Act
            repository.Add(department1);
            var result = repository.Add(department2);

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(1, repository.GetAll().Count);
        }

        [Test]
        public void Add_Fail_DuplicateValue()
        {
            // Arrange
            Department department1 = new Department() { Id = 1, Name = "IT", Department_Head = 101 };
            Department department2 = new Department() { Id = 2, Name = "IT", Department_Head = 102 };

            // Act
            repository.Add(department1);
            var result = repository.Add(department2);

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(1, repository.GetAll().Count);
        }

        [Test]
        public void Delete_Successful()
        {
            // Arrange
            Department department = new Department() { Id = 1, Name = "IT", Department_Head = 101 };
            repository.Add(department);

            // Act
            var result = repository.Delete(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(department, result);
            Assert.IsFalse(repository.GetAll().Contains(department));
        }

        [Test]
        public void Delete_NotFound()
        {
            // Act
            var result = repository.Delete(1);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Get_Successful()
        {
            // Arrange
            Department department = new Department() { Id = 1, Name = "IT", Department_Head = 101 };
            repository.Add(department);

            // Act
            var result = repository.Get(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(department, result);
        }

        [Test]
        public void Get_NotFound()
        {
            // Act
            var result = repository.Get(1);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAll_Successful()
        {
            // Arrange
            Department department1 = new Department() { Id = 1, Name = "IT", Department_Head = 101 };
            Department department2 = new Department() { Id = 2, Name = "HR", Department_Head = 102 };
            repository.Add(department1);
            repository.Add(department2);
            List<Department> expected = new List<Department> { department1, department2 };

            // Act
            var result = repository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void GetAll_Empty()
        {
            // Act
            var result = repository.GetAll();

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Update_Successful()
        {
            // Arrange
            Department department = new Department() { Id = 1, Name = "IT", Department_Head = 101 };
            repository.Add(department);
            Department updatedDepartment = new Department() { Id = 1, Name = "HR", Department_Head = 102 };

            // Act
            var result = repository.Update(updatedDepartment);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedDepartment, result);
            Assert.AreEqual(updatedDepartment.Name, repository.Get(1).Name);
        }

        [Test]
        public void Update_NotFound()
        {
            // Arrange
            Department department = new Department() { Id = 1, Name = "IT", Department_Head = 101 };

            // Act
            var result = repository.Update(department);

            // Assert
            Assert.IsNull(result);
        }
    }
}
