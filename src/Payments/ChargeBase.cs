﻿using System.Threading.Tasks;
using RaveNetLibrary.Security;

namespace RaveNetLibrary.Payments;

    public abstract class ChargeBase<T1, T2> : ICharge<T1, T2> where T1 : RaveApiResponse<T2>, new() where T2 : PayResponseData
    {
        protected ChargeBase(RavePayConfig config)
        {
            Config = config;
            ApiRequest = new RavePayApiRequest<T1, T2>(config);
            PaymentDataEncryption = new RaveEncryption(); // Sets to the default encryption
        }

        protected internal RavePayConfig Config { get; }
        internal IRavePayApiRequest<T1, T2> ApiRequest { get; }

        public IPaymentDataEncryption PaymentDataEncryption { get; }
        public abstract Task<T1> Charge(IChargeParams chargeParams, bool isRecurring = false);
    }

