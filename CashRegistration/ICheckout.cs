using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegistration
{
    internal interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();

    }
}
