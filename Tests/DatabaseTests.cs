using System;
using Episode1.Models;
using NUnit.Framework;

namespace Tests
{
    //TDD - test driven development
    
    //Red -> Green -> Refactor
    
    
    [TestFixture]
    public class DatabaseTests
    {
        public User User;
        public IDatabase Database;
        
        [SetUp]
        public void Setup()
        {
            User = new User("user1@email.com", "secret");
            Database = new Database();
        }
        
        
        [Test]
        public void invoking_connect_should_set_is_connected_to_true()
        {
            //Arrange
           
            
            //Act
            Database.Connect();
            
            //Assert
            Assert.IsTrue(Database.IsConnected);
        }
    }
}