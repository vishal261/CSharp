using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwait
{
    /* 
        Summarize the key points of this example, as follows:
        ------------------------------------------------------

        • Methods (as well as lambda expressions or anonymous methods) can be marked
        with the async keyword to enable the method to do work in a nonblocking
        manner.

        • Methods (as well as lambda expressions or anonymous methods) marked with the
        async keyword will run in a blocking manner until the await keyword is
        encountered.

        • A single async method can have multiple await contexts.

        • When the await expression is encountered, the calling thread is suspended until
        the awaited task is complete. In the meantime, control is returned to the caller of
        the method.

        • The await keyword will hide the returned Task object from view, appearing to
        directly return the underlying return value. Methods with no return value simply
        return void.

        • As a naming convention, methods that are to be called asynchronously should be
        marked with the “Async” suffix. 
    
    */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnDone_Click(object sender, EventArgs e)
        {
            txtResult.Text = await DoneWork();
        }

        private async Task<string> DoneWork()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Done with work!";
            });

        }
    }
}
