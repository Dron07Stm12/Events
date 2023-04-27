using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace Events
{
    //1 - создается класс MyEventArgs, производный от класса EventArgs. 
    public class MyEventArgs : EventArgs
    {
        public int EventNum;


    }
    //объявляется делегат MyEventHandler, принимающий два параметра, требующиеся 
    //для среды.NET Framework, и  под событие
    // первый параметр содержит  
    // ссылку на объект, формирующий событие, а второй параметр — ссылку на объект класса
    //EventArgs или производного от него класса.
    public delegate void MyEventHandler(object source, MyEventArgs e);


    public class MyEvent 
    {
        public  static int count;
        //событие
        public event MyEventHandler SomeEvent;
       
        //создадим метод для запуска события
        public void Method_SomeEvent() 
        {
            MyEventArgs args = new MyEventArgs();
            if (SomeEvent != null)
            {
                args.EventNum = count++;
                SomeEvent(this,args);
            }
        
        }
    
    }

    //Обработчики событий Handler (),  
    //определяемые в классах X и Y, принимают параметры тех же самых типов.

    public class X 
    {
        public void Handler(object source,MyEventArgs args)
        {
            Console.WriteLine("Событие " + args.EventNum + " получено обьектом класса Х ");
            Console.WriteLine("Источник(ссылка на обьект формирующие событие): " + source);
        
        } 
    
    }

    public class Y 
    {

        public void Handler(object source, MyEventArgs eventArgs) 
        {
            Console.WriteLine("Cобытие " + eventArgs.EventNum + " получено обьектом класса Y ");
            Console.WriteLine("Источник(ссылка на обьект формирующие событие): " + source);
        }
    
    }



    public class Program
    {

       
        static void Main(string[] args)
        {
            MyEvent myEvent = new MyEvent();
            X x = new X();
            Y y = new Y();
            myEvent.SomeEvent += x.Handler;
            myEvent.SomeEvent += y.Handler;
           
            myEvent.Method_SomeEvent();
            myEvent.Method_SomeEvent();

        }
    }
}
