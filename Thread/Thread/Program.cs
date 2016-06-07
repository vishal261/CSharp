using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace ThreadMain
{
    class Program
    {
        public delegate int MyDelegate(int a, int b);
        static bool isDone = false;

        static void Main(string[] args)
        {

            Console.WriteLine("Current main thread is {0}", Thread.CurrentThread.ManagedThreadId);

            // Show details of hosting AppDomain/Context.
            Console.WriteLine("Name of current AppDomain: {0}",
            Thread.GetDomain().FriendlyName);

            MyDelegate del = new MyDelegate(Add);

            // Synchronus
            //int answer = del.Invoke(10, 20);

            // Asynchronus
            //var asyncRes = del.BeginInvoke(10, 20, null, null);

            var asyncRes = del.BeginInvoke(10, 20, new AsyncCallback(AddComplete) , "Sucessfully executed add complete method.");
            
            // while (!asyncRes.IsCompleted)
            while (!isDone)
            {
                Console.WriteLine("Doning more work on main !!!!!!");
                Thread.Sleep(1000);
            }

            //int answer = del.EndInvoke(asyncRes);
            //Console.WriteLine("10 + 20 = {0}", answer);

            Console.ReadLine();
        }

        static int Add(int a, int b)
        {
            Console.WriteLine(string.Format("Thread running on Add method : {0}", Thread.CurrentThread.ManagedThreadId));
            Thread.Sleep(5000);
            return a + b;
        }

        static void AddComplete(IAsyncResult asyncRes)
        {
            Console.WriteLine(string.Format("Thread running on add complete method : {0}", Thread.CurrentThread.ManagedThreadId));

            // using System.Runtime.Remoting.Messaging;
            AsyncResult async = (AsyncResult)asyncRes;
            MyDelegate deleg = (MyDelegate)async.AsyncDelegate;

            int answer = deleg.EndInvoke(asyncRes);
            Console.WriteLine("10 + 20 = {0}", answer);

            string msg = (string)async.AsyncState;
            Console.WriteLine(msg);

            isDone = true;
        }
    }
}
