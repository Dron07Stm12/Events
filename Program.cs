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

        MyEventHandler[] handler = new MyEventHandler[3];

        public event MyEventHandler SomeEvent 
        {
            
            add 
            {
                int i;
                for (i = 0; i < 3; i++)
                {
                    if (handler[i] == null)
                    {
                        handler[i] = value;
                        break;
                    }
                }

                if (i == 3)
                {
                    Console.WriteLine("Список событий заполнен");
                }
            
            }
            //Когда же обработчик событий удаляется 
            //из цепочки событий, то вызывается аксессор remove и в массиве evnt осуществляется
             //поиск ссылки на этот обработчик, передаваемой в качестве параметра value. 
            remove 
            {
                int i;
                for ( i = 0; i < 3; i++)
                {
                    if (handler[i] == value)
                    {
                        handler[i] = null;
                    }
                }

                if (i == 3)
                {
                    Console.WriteLine("Обработчик событий не найден");
                }
            }
             
        }

        public void Method_Event() 
        {
            for (int i = 0; i < handler.Length; i++)
            {
                if (handler[i] != null)
                {
                    handler[i]();
                }
            }
        
        
        }

        public void Method_Event2()
        {
            
                    handler[0]();
                
            


        }


    }

    public class X 
    {   
        public  void Hendler_x() 
        {
            Console.WriteLine("Событие обьекта класса Х ");
        }   
    }


    public class Y
    {
        public void Hendler_y()
        {
            Console.WriteLine("Событие обьекта класса Y ");
        }
    }


    public class Z
    {
        public void Hendler_z()
        {
            Console.WriteLine("Событие обьекта класса Z ");
        }
    }



    public class Program
    {
     
        static void Main(string[] args)
        {
            MyEvent my = new MyEvent();
            X x = new X();
            Y y = new Y();
            Z z = new Z();


            //Когда в цепочку событий добавляется обработчик событий, вызывается аксессор 
            //add, и в первом неиспользуемом(т.е.пустом) элементе массива evnt запоминается
            //ссылка на этот обработчик, содержащаяся в неявно задаваемом параметре value.
            my.SomeEvent += x.Hendler_x;
            my.SomeEvent += y.Hendler_y;
            my.SomeEvent += z.Hendler_z;
            //будет писать список событий заполнен
         //   my.SomeEvent += x.Hendler_x;
            my.Method_Event();

            // Удалить обработчик. будет писать дважды обработчик события не найден
            //   my.SomeEvent -= x.Hendler_x;
            Console.WriteLine();
            my.SomeEvent -= z.Hendler_z;
            my.Method_Event();
            //Обратно добавим обработчик событий
            Console.WriteLine();
            my.SomeEvent += z.Hendler_z;
            my.Method_Event();
            my.Method_Event2();

        }
    }
}
