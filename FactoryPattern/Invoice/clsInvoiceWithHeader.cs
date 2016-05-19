using InvoiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    public class clsInvoiceWithHeader : IInvoice
    {
        public void Print()
        {
            Console.WriteLine("Invoice with header.");
        }
    }
}
