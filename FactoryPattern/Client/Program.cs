using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceInterface;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IInvoice objInvoice;

            Console.WriteLine("Enter the invoice type");
            int invoiceType = Convert.ToInt32(Console.ReadLine());
            objInvoice = FactoryInvoice.FactoryInvoice.GetInvoiceObject(invoiceType);
            objInvoice.Print();

            Console.ReadLine();
        }
    }
}
