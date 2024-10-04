﻿using System;
using System.Collections.Generic;
using System.Text;
using RaveNetLibrary.Banks;
using Newtonsoft.Json;

namespace RaveNetLibrary.Payments;

    public class AccountChargeParams : ChargeParamsBase
    {


        public AccountChargeParams(string pbfPubKey, string firstName, string lastName, string email, string accountNumber, decimal amount, string bank, string txRef) : base(pbfPubKey, firstName, lastName, email)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Accountbank = bank;
            PaymentType = "account";
            TxRef = txRef;
        }

        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }


        /// <summary>
        /// This specifies that the payment method being used is for account payments
        /// </summary>
        [JsonProperty("payment_type")]
        public  string PaymentType { get; set; }

        [JsonProperty("accountbank")]
        public string Accountbank { get; set; }

        /// <summary>
        /// This requires that the customer date of birth is collected and passed in this format DDMMYYYY
        /// </summary>
        [JsonProperty("passcode")]
        public string Passcode { get; set; }

        [JsonProperty("otp")]
        public  string Otp { get; set; }
    }

