using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace Events
{
      
    public class MyEvent 
    {
        // событие привязано к делегату - public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler SomeEvent;
        public int i = 2;

        //метод для запуска события
        public void Method_SomeEvent() 
        {
            MyEvent my = new MyEvent(); 
            if (SomeEvent != null)
            {
                SomeEvent(my.i,EventArgs.Empty);
            }      
        }
    }

    


    public class Program
    {
        public static void Handler(object source, EventArgs args) 
        {
            Console.WriteLine("Произошло событие, " + "источник "+ source.GetType() +" равный "+ source);
            Console.WriteLine();
        
        }
       
        static void Main(string[] args)
        {

            MyEvent my = new MyEvent();
            my.SomeEvent += Program.Handler;
           
            my.SomeEvent += delegate (object source, EventArgs args1)
            {
                Console.WriteLine("Источник события(ссылка на обьект формирующее событие): " + source);
                Console.WriteLine("Ссылка на обьект клаасса EventArgs" + args1.GetType());
                Console.WriteLine();
            };

            my.SomeEvent += (s, ar) => {
                Console.WriteLine("Источник события(ссылка на обьект формирующее событие): " + s);
                Console.WriteLine("Ссылка на обьект клаасса EventArgs" + ar.GetType());

            };

            my.Method_SomeEvent();
        }
    }
}
