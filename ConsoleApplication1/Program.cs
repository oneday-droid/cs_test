using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static Presenter presenter;

        static void Main(string[] args)
        {
            presenter = new Presenter();
            bool running = true;

            Console.WriteLine("Press 1 to add value");
            Console.WriteLine("Press 2 to remove value");
            Console.WriteLine("Press 3 to print array");
            Console.WriteLine("Press 4 to do task");
            Console.WriteLine("Press e to exit");
           
            while (running)
            {
		        Console.WriteLine("Enter command");
                string ch = Console.ReadLine();

                switch (ch)
                {
                    case "1": Add(); break;
                    case "2": Remove(); break;
                    case "3": Print(); break;
                    case "4": DoTask(); break;
                    case "5": Reset(); break;
                    case "e": running = false; break; 
                    default: Console.WriteLine("Unknown command"); break;
                }                    
            }
        }

        static void Add()
        {
            Console.WriteLine("Enter new value");
            string ch = Console.ReadLine();
            try
            {
                int value = Convert.ToInt32(ch);
                presenter.AddValue(value);
                Console.WriteLine("Value added");
                //presenter.Print();
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect value");
            }
        }

        static void Remove()
        {
            Console.WriteLine("Enter index to remove");
            string ch = Console.ReadLine();
            try
            {
                int index = Convert.ToInt32(ch);
                if(presenter.RemoveValue(index))
                    Console.WriteLine("Value removed");
                else
                    Console.WriteLine("Index out of range");

                //presenter.Print();
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect value");
            }
        }

        static void Print()
        {            
            presenter.Print();            
        }

        static void DoTask()
        {
            presenter.Task();
            presenter.Print();
        }

        static void Reset()
        {
            presenter.Reset();
            presenter.Print();
        }
    }

    public class Presenter
    {
        int[] arr;
        int count;
        Random random;

        public Presenter()
        {
            count = 10;
            arr = new int[count];
            random = new Random();
            
            Reset();                        
        }

        public void Reset()
        {            
            for (int k = 0; k < count; k++)
                arr[k] = random.Next(0, 100);
        }

        public void AddValue(int value)
        {            
            int[] source = arr;
            count++;

            arr = new int[count];
            for (int k = 0; k < count - 1; k++)
                arr[k] = source[k];

            arr[count - 1] = value;            
        }

        public bool RemoveValue(int index)
        {
            bool result = false;
            if (index < count)
            {
                int[] source = arr;
                arr = new int[count - 1];
                int arrK = 0;
                for (int k = 0; k < count; k++)
                    if (k != index)
                    {
                        arr[arrK] = source[k];
                        arrK++;
                    }
                count--;
                result = true;
            }

            return result;
        }

        public void Print()
        {
            Console.WriteLine("Print array");
            for (int k = 0; k < count; k++)
                Console.Write("{0}; ", arr[k]);
            Console.WriteLine("");
        }

        public void Task()
        {
            int[] sortArr = new int[count];
            Dictionary<int, int> valueIndexDict = new Dictionary<int, int>();
            int itr = 0;
            for (int k = 0; k < count; k++)
            {
                if ((arr[k] % 2 == 0) && (arr[k] != 0))
                {
                    valueIndexDict.Add(k, arr[k]);
                    sortArr[itr] = arr[k];
                    itr++;
                }
            }

            sortArr = DescendingSort(sortArr, itr);

            int sortIndex = 0;
            for (int k = 0; k < count; k++)
            {
                if (valueIndexDict.ContainsKey(k))
                {
                    arr[k] = sortArr[sortIndex];
                    sortIndex++;
                }
            }
        }

        int[] DescendingSort(int[] sourceArray, int length)
        {
            for (int k = 0; k < length - 1; k++)
            {
                for (int j = 0; j < length - k - 1; j++)
                    if(sourceArray[j+1] < sourceArray[j])
                    {
                        int temp = sourceArray[j + 1];
                        sourceArray[j + 1] = sourceArray[j];
                        sourceArray[j] = temp;
                    }
            }

            return sourceArray;
        }
    }
}
