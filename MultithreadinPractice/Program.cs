using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultithreadinPractice
{
    class Program
    {
        private static ManualResetEvent eventTalk = new ManualResetEvent(false);
        private static ManualResetEvent eventIs = new ManualResetEvent(false);
        private static ManualResetEvent eventCheap = new ManualResetEvent(false);
        private static ManualResetEvent eventShow = new ManualResetEvent(false);
        private static ManualResetEvent eventMe = new ManualResetEvent(false);
        private static ManualResetEvent eventThe = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            //Task chaining
            Task taskTalk = Task.Run(() => Talk());
            Task taskIs = taskTalk.ContinueWith((task) => Is());
            Task taskCheap = taskIs.ContinueWith((task) => Cheap());
            Task taskShow = taskCheap.ContinueWith((task) => Show());
            Task taskMe = taskShow.ContinueWith((task) => Me());
            Task taskThe = taskMe.ContinueWith((task) => The());
            Task taskCode = taskThe.ContinueWith((task) => Code());
            Console.ReadLine();

            //Reset events
            Task mreTaskTalk = Task.Run(() => MRETalk());
            Task mreTaskIs = Task.Run(() => MREIs());
            Task mreTaskCheap = Task.Run(() => MRECheap());
            Task mreTaskShow = Task.Run(() => MREShow());
            Task mreTaskMe = Task.Run(() => MREMe());
            Task mreTaskThe = Task.Run(() => MREThe());
            Task mreTaskCode = Task.Run(() => MRECode());
            Console.ReadLine();
        }

        private static void Talk()
        {
            Console.Write("Talk ");
        }

        private static void Is()
        {
            Console.Write("is ");
        }

        private static void Cheap()
        {
            Console.Write("cheap. ");
        }

        private static void Show()
        {
            Console.Write("Show ");
        }

        private static void Me()
        {
            Console.Write("me ");
        }

        private static void The()
        {
            Console.Write("the ");
        }

        private static void Code()
        {
            Console.Write("code.");
        }

        private static void MRETalk()
        {
            Talk();
            eventTalk.Set();
        }

        private static void MREIs()
        {
            eventTalk.WaitOne();
            Is();
            eventIs.Set();
        }

        private static void MRECheap()
        {
            eventIs.WaitOne();
            Cheap();
            eventCheap.Set();
        }

        private static void MREShow()
        {
            eventCheap.WaitOne();
            Show();
            eventShow.Set();
        }

        private static void MREMe()
        {
            eventShow.WaitOne();
            Me();
            eventMe.Set();
        }

        private static void MREThe()
        {
            eventMe.WaitOne();
            The();
            eventThe.Set();
        }

        private static void MRECode()
        {
            eventThe.WaitOne();
            Code();
        }
    }
}
