using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
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
                arr[k] = random.Next(-100, 100);
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

        public void SortEvenElements(SortType sortOrder)
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

            switch (sortOrder)
            {
                case SortType.Descending: sortArr = DescendingSort(sortArr, itr); break;
                case SortType.Ascending: sortArr = AscendingSort(sortArr, itr); break;
            }

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

        public int FindFirstEvenElementIndex()
        {
            int index = 0;
            for (index = 0; index < count; index++)
            {
                if ((arr[index] % 2 == 0) && (arr[index] != 0))
                    break;
            }

            return index;
        }

        public int FindFirstNegativeElementIndex()
        {
            int index = 0;
            for (index = 0; index < count; index++)
            {
                if (arr[index] < 0)
                    break;
            }

            return index;
        }

        public int FindValueIndex(int value)
        {
            int index = 0;
            for (index = 0; index < count; index++)
            {
                if (arr[index] == value)
                    break;
            }

            return index;
        }

        public int Calculate()
        {
            int summ = 0;
            for (int k = 0; k < count; k++)
            {
                summ += arr[k] / count;
            }

            return summ;
        }

        int[] DescendingSort(int[] sourceArray, int length)
        {
            for (int k = 0; k < length - 1; k++)
            {
                for (int j = 0; j < length - k - 1; j++)
                    if (sourceArray[j + 1] < sourceArray[j])
                    {
                        int temp = sourceArray[j + 1];
                        sourceArray[j + 1] = sourceArray[j];
                        sourceArray[j] = temp;
                    }
            }

            return sourceArray;
        }

        int[] AscendingSort(int[] sourceArray, int length)
        {
            for (int k = 0; k < length - 1; k++)
            {
                for (int j = 0; j < length - k - 1; j++)
                    if (sourceArray[j + 1] > sourceArray[j])
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
