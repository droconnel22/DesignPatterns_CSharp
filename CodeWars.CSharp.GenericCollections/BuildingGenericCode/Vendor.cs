using System;
using System.Text;

namespace CodeWars.CSharp.GenericCollections.BuildingGenericCode
{
    class Vendor
    {
        public int VendorId { get; }
        public string CompanyName { get; }
        public string Email { get; }

        //bad this code is very awful
        public OperationResult<bool, string> PlaceOrder(Product product, int quantity, DateTimeOffset? deliverBy = null, string instructions = "standard delivery")
        {
            ///bad
            if(product == null ) throw new ArgumentNullException(nameof(product));

            var success = false;
            var orderTextbuilder = new StringBuilder("Order from Acme, Inc"  + System.Environment.NewLine + "Deliver By: " + deliverBy.Value.ToString("d"));

            if (!string.IsNullOrWhiteSpace(instructions))
                orderTextbuilder.Append(System.Environment.NewLine + "Instructions: " + instructions);

            var orderText = orderTextbuilder.ToString();

            var emailService = new EmailService();

            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message Sent: ")) success = true;

            var operationResult = new OperationResult<bool,string>(success,orderText);
            return operationResult;
        }
    }
}