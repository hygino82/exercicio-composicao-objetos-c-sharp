using ExercicioFix.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ExercicioFix.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
        
        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem orderItem in Items)
            {
                sum += orderItem.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (" + Client.BirthDate.ToString("dd/MM/yyyy" + ") - "));
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items:");
            
            foreach(OrderItem orderItem in Items)
            {
                sb.AppendLine(orderItem.ToString());
            }

            sb.Append("Total price: $");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
