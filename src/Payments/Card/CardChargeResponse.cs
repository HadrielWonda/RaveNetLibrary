using System;
using System.Collections.Generic;
using System.Text;

namespace RaveNetLibrary.Payments;

   public class CardChargeResponse<T>: RaveApiResponse<T> where T: CardResponseData
    {
        public override T Data { get; set; }
    }


