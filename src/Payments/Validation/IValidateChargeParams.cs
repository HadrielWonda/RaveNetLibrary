using System;


namespace RaveNetLibrary.Payments;

    public interface IValidateChargeParams
    {
        string PbfPubKey { get; set; }
    }

