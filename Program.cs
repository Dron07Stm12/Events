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

        int id;

        public X(int x)
        {
           id = x; 
        }
        public void Hendler_x() 
        {
            Console.WriteLine("Событие обьекта класса Х " + id);
        }
    
    }

  
    public class Program
    {
     
        static void Main(string[] args)
        {
            MyEvent my = new MyEvent();
            X x1 = new X(1);
            X x2 = new X(2);
            X x3 = new X(3);

            // добавить экземпляры класса Х методов(обработчиков событий) в список событий
            my.SomeEvent += x1.Hendler_x;
            my.SomeEvent += x2.Hendler_x;
            my.SomeEvent += x3.Hendler_x;
            //запускаем событие
            my.Method_SomeEvent();  

        }
    }
}
