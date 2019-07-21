namespace Episode1.Models
{
    public interface IEmailSender
    {
        void SendMessage(string receiver, string title, string message);
    }

    public class EmailSender : IEmailSender
    {
        public void SendMessage(string receiver, string title, string message)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IDatabase
    {
        bool IsConnected { get; }
        void Connect();
        User GetUser(string email);
        Order GetOrder(int id);
        void SaveChanges();
    }
    
    public class Database : IDatabase
    {
        public bool IsConnected { get; }
        public void Connect()
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new System.NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }


    public interface IOrderProcessor
    {
        void ProcessOrder(string email, int orderid);
    }

    public class OrderProcessor : IOrderProcessor
    {
        private readonly IDatabase _database;
        private readonly IEmailSender _emailSender;

        public OrderProcessor(IDatabase database, IEmailSender emailSender)
        {
            _database = database;
            _emailSender = emailSender;
        }
        
        public void ProcessOrder(string email, int orderid)
        {
            User user = _database.GetUser(email);
            Order order = _database.GetOrder(orderid);
            user.PurchaseOrder(order);
            _database.SaveChanges();
            _emailSender.SendMessage(email, "Order purchased", "You've purchased an order.");
        }
    }

    public class Shop
    {
        public void CompleteOrder()
        {
            IDatabase database = new Database();
            IEmailSender emailSender = new EmailSender();
            IOrderProcessor orderProcessor = new OrderProcessor(database, emailSender);
        }
    }

}