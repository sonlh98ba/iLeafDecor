﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.Data.Entities
{
    public class Transaction
    {
        public int ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ExternalTransactionID { get; set; }
        public int Amount { get; set; }
        public decimal Fee { get; set; }
        public int Result { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int Provider { get; set; }
    }
}
