namespace Salon.CustomerBase.Core.Interfaces
{
    public interface IMessageSender
    {
        void SendNotificationEmail(string toAddress,string subject, string messageBody);
        string GetMessageTypeTemplate(string messageType);
    }
}
