using CodeFirstAPI.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CodeFirstAPI.Models;
using CodeFirstAPI.Controllers;
using CodeFirstEntity.Entities;
using CodeFirstEntity.Classes;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Transactions;
using NUnit.Framework.Interfaces;

namespace EmployeesTest
{
    [TestFixture]
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeBL> MokEmployeeBL;       
        public EmployeeControllerTest()
        {
            MokEmployeeBL = new Mock<IEmployeeBL>();           
        }

        [Test]
        public  void GetEmployees()
        {
            MokEmployeeBL.Setup(x => x.GetEmployees()).Returns(new List<Employee>());
            var controler = new EmployeeController(MokEmployeeBL.Object);
             var result= controler.GetEmployees();
            Assert.AreEqual(result, new List<Employee>());
        }

        [Test]       
        public void SaveEmployees()
        {
            Employee empDet = null;
            MokEmployeeBL.Setup(x => x.SaveEmployee(empDet));
            var controler = new EmployeeController(MokEmployeeBL.Object);
           // controler.SaveEmployee(empDet);

            Assert.Throws<ArgumentException>(() => controler.SaveEmployee(empDet));

          // Assert.That(()=>controler.SaveEmployee(empDet),Throws.TypeOf<ArgumentException>());
        }

        [Test]
        [Rollback]
        [TestCase("Deenn","test",23,16)]
        [TestCase("shyam", "test", 23, 16)]
        public void SaveEmployee_DL(string name,string address,int age,int jobId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=B283LCOK\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True");
            EmployeeDetails empDet = new EmployeeDetails() { Name= name, Address= address, Age= age, EmployeeJobID= jobId }; 
            var dlayer = new EmployeeDL(con);           
            dlayer.SaveEmployeeTest(empDet);
        }


    }


    public class RollbackAttribute : Attribute, ITestAction  // (1), (2)
    {
        private TransactionScope transaction;

        public void BeforeTest(ITest testDetails)
        {
            transaction = new TransactionScope();  // (3)
        }

        public void AfterTest(ITest testDetails)
        {
            transaction.Dispose();  // (4)
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }  // (5)
        }
    }
}
