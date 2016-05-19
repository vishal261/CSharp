using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceInterface;
using Invoice;

namespace FactoryInvoice
{
    public class FactoryInvoice 
    {
        /// <summary>
        /// This function return invoice class based on the invoice object
        /// </summary>
        /// <param name="invoiceType">Invoice type id should be pass from client side</param>
        /// <returns>return IInvoice type</returns>
        public static IInvoice GetInvoiceObject(int invoiceType)
        {
            IInvoice objInvoice = default(IInvoice);
            if (invoiceType == 1)
            {
                objInvoice = new clsInvoiceWithHeader();
            }
            else if (invoiceType == 2)
            {
                objInvoice = new clsInvoiceWithout();
            }
            return objInvoice;
        }
    }
}
