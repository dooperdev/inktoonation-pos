using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Transactions
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TotalAmount { get; set; }
        public string PaymentType { get; set; }

        public int TotalItems { get; set; }
    }
}
