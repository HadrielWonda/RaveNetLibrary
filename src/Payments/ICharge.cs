﻿using System.Threading.Tasks;
using RaveNetLibrary.Security;

namespace RaveNetLibrary.Payments;

    internal interface ICharge<T1, T2> where T1 : RaveApiResponse<T2>, new() where T2 : PayResponseData
    {

        IPaymentDataEncryption PaymentDataEncryption { get; }
        Task<T1> Charge(IChargeParams chargeParams, bool isRecurring = false);

    }

