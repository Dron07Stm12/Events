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
            else
            {
                Console.WriteLine("Не произошло событие");
            }

        }
    }

    public class X 
    {
        public void Hendler_x() 
        {
            Console.WriteLine("Событие обьекта класса Х");
        }
    
    }

    public class Y
    {
        public void Hendler_y()
        {
            Console.WriteLine("Событие обьекта класса Y");
        }

    }


    public class Program
    {
        // Обработчик события, 
        static void Hendler() 
        {
            Console.WriteLine("Произошло событие");
        }

        static void Main(string[] args)
        {
            MyEvent my = new MyEvent();
            X x = new X();  
            Y y = new Y();


            // Добавить обработчики в список событий. 
            //В данном примере создаются два дополнительных класса, X и Y, в которых также 
            //определяются обработчики событий, совместимые с делегатом MyEvent Handler.
            //Поэтому эти обработчики могут быть также включены в цепочку событий. 
              my.SomeEvent += Hendler;
              my.SomeEvent += x.Hendler_x;
              my.SomeEvent += y.Hendler_y;
              //Запускаем событие
              my.Method_SomeEvent();
              my.SomeEvent -= x.Hendler_x;
              my.Method_SomeEvent();


        }
    }
}
