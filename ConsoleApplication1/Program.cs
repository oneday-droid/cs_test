﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public enum SortType
    {
        Ascending = 0,
        Descending
    }

    class Program
    {
        static Presenter presenter;

        static void Main(string[] args)
        {
            presenter = new Presenter();
            bool running = true;

            ShowMessage("Press 1 to add value\n" +
                        "Press 2 to remove value by index\n" +
                        "Press 3 to print array\n" +
                        "Press 4 to descending sort even elements\n" +
                        "Press 5 to ascending sort even elements\n" +
                        "Press 6 to remove first even element\n" +
                        "Press 7 to remove first negative element\n" +
                        "Press 8 to remove value entered by user\n" +
                        "Press 9 to remove element that equal average value\n" +
                        "Press e to exit");
           
            while (running)
            {
                ShowMessage("Enter command");
                string key = GetUserInputValue();

                switch (key)
                {
                    case "1": Add(); break;
                    case "2": Remove(); break;
                    case "3": Print(); break;
                    case "4": DoTask(SortType.Descending); break;
                    case "5": DoTask(SortType.Ascending); break;
                    case "6": RemoveFirstEvenElement(); break;
                    case "7": RemoveFirstNegativeElement(); break;
                    case "8": RemoveElement(); break;
                    case "9": RemoveAverage(); break;
                    case "r": Reset(); break;
                    case "e": running = false; break;
                    default: ShowMessage("Unknown command"); break;
                }                    
            }
        }

        static void ShowMessage(string text)
        {
            Console.WriteLine(text);
        }

        static string GetUserInputValue()
        {
            string ch = Console.ReadLine();
            return ch;
        }

        static void Add()
        {
            ShowMessage("Enter new value");
            string ch = GetUserInputValue();
            try
            {
                int value = Convert.ToInt32(ch);
                presenter.AddValue(value);
                ShowMessage("Value added");
                //presenter.Print();
            }
            catch (Exception)
            {
                ShowMessage("Incorrect value");
            }
        }

        static void Remove()
        {
            ShowMessage("Enter index to remove");
            string ch = GetUserInputValue();
            try
            {
                int index = Convert.ToInt32(ch);
                if(presenter.RemoveValue(index))
                    ShowMessage("Value removed");
                else
                    ShowMessage("Index out of range");

                //presenter.Print();
            }
            catch (Exception)
            {
                ShowMessage("Incorrect value");
            }
        }

        static void Print()
        {            
            presenter.Print();            
        }

        static void DoTask(SortType sortOrder)
        {
            presenter.SortEvenElements(sortOrder);
            presenter.Print();
        }

        static void Reset()
        {
            presenter.Reset();
            presenter.Print();
        }

        static void RemoveFirstEvenElement()
        {
            int index = presenter.FindFirstEvenElementIndex();
            presenter.RemoveValue(index);
        }

        static void RemoveFirstNegativeElement()
        {
            int index = presenter.FindFirstNegativeElementIndex();
            presenter.RemoveValue(index);
        }

        static void RemoveElement()
        {
            ShowMessage("Enter new value");
            string ch = GetUserInputValue();
            try
            {
                int value = Convert.ToInt32(ch);
                int index = presenter.FindValueIndex(value);
                presenter.RemoveValue(index);
            }
            catch (Exception)
            {
                ShowMessage("Incorrect value");
            }            
        }

        static void RemoveAverage()
        {
            int value = presenter.Calculate();
            int index = presenter.FindValueIndex(value);
            presenter.RemoveValue(index);
        }
    }    
}
