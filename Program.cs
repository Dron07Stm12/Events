using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


// Объявить тип делегата для события, 
public  delegate void MyEventHandler(int i);

namespace Events
{
    public class MyEvent 
    {
        public event MyEventHandler SomeEvent;

        //Метод для запуска события
        public void Method(int n) 
        {
            if (SomeEvent != null)
            {
                SomeEvent(n);
            }
        
        }


    }

    

    public class Program
    {

        static void Method_Program(int i)
        { 
            Console.WriteLine("Добавляем в список событий статический метод " + i);
        }
     
        static void Main(string[] args)
        {
            MyEvent my = new MyEvent();

           // добавим обработку в список события
            my.SomeEvent += delegate (int i)
            {
                Console.WriteLine("Добавляем в список событий анонимный метод номер " + i);
            };

            my.SomeEvent += n => Console.WriteLine("lymbda "+ n);

          
            my.SomeEvent += Program.Method_Program;
            //запустим событие
            my.Method(1);
          //  my.Method(2);
           

        }
    }
}
