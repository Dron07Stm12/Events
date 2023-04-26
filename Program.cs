using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


// Объявить тип делегата для события, 
public  delegate void MyEventHandler();

namespace Events
{
    public class MyEvent 
    {
        //событие
        public event MyEventHandler SomeEvent;
        // Этот метод вызывается для запуска события

        //В методе Method_SomeEvent () вызывается обработчик событий с помощью  
        //делегата SomeEvent.

        public void Method_SomeEvent()
        {
            if (SomeEvent != null)
            {
                SomeEvent();
            }
            
        }
    }

    public class X 
    {
     
        public static void Hendler_x() 
        {
            Console.WriteLine("Событие обьекта класса Х ");
        }
    
    }

  
    public class Program
    {
     
        static void Main(string[] args)
        {
            MyEvent my = new MyEvent();

            //регистрируем статический обработчик в список событии
            my.SomeEvent += X.Hendler_x;
            
            //запускаем событие
            my.Method_SomeEvent();  

        }
    }
}
