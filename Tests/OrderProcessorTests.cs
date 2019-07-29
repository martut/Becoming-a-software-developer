using Episode1.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class OrderProcessorTests
    {
        public User User;
        public Order Order;
        public Mock<IDatabase> DatabaseMock;
        public Mock<IEmailSender> EmailSenderMock;
        public OrderProcessor OrderProcessor;

        
        [SetUp]
        public void Setup()
        {
            User = new User("user1@email.com", "secret");
            Order = new Order(1, 10);
            DatabaseMock = new Mock<IDatabase>();
            EmailSenderMock = new Mock<IEmailSender>();
            DatabaseMock.Setup(x => x.GetUser(User.Email))
                .Returns(User);
            DatabaseMock.Setup(x => x.GetOrder(Order.Id))
                .Returns(Order);
            
            OrderProcessor = new OrderProcessor(DatabaseMock.Object, EmailSenderMock.Object);
        }
        
        
        [Test]
        public void process_order_should_succeed()
        {
            //Arrange
           User.IncreaseFunds(100);
           User.Activate(); 
           
            //Act
            OrderProcessor.ProcessOrder(User.Email, Order.Id);
            
            //Assert
            
            DatabaseMock.Verify(x => x.GetUser(User.Email), Times.Once());
            DatabaseMock.Verify(x => x.GetOrder(Order.Id), Times.Once());
            Order.IsPurchased.Should().BeTrue();
        }
    }
}