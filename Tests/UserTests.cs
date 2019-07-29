using System;
using Episode1.Models;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UserTests
    {
        public User User;
        
        [SetUp]
        public void Setup()
        {
            User = new User("user1@email.com", "secret");
        }
        
        
        [Test]
        public void changing_email_should_succeed()
        {
            //Arrange
            var expectedEmail = "user@email.com";

            
            //Act
            User.SetEmail(expectedEmail);
            
            //Assert
            Assert.AreEqual(User.Email, expectedEmail);    
        } 
        
        [Test]
        public void providing_empty_password_should_fail()
        {
            //Arrange
            
           
            
            //Act
            var exception =Assert.Throws<Exception>(() =>  User.SetPassword(string.Empty));
            
            //Assert
            Assert.NotNull(exception);
            Assert.IsTrue(exception.Message.Equals("password is incorrect."));
        }    
        
        
        
        
   
    }
}