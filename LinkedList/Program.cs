using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //[3]--[1]--[5]--null 
            EmployeeLinkedList listItem4 = null;
            EmployeeLinkedList listItem3 = new EmployeeLinkedList(5, listItem4);
            EmployeeLinkedList listItem2 = new EmployeeLinkedList(1, listItem3);
            EmployeeLinkedList listItem1 = new EmployeeLinkedList(3, listItem2);

            //[4]--[2]--[6]--[null] 
            EmployeeLinkedList listItemD = null;
            EmployeeLinkedList listItemC = new EmployeeLinkedList(6, listItemD);
            EmployeeLinkedList listItemB = new EmployeeLinkedList(2, listItemC);
            EmployeeLinkedList listItemA = new EmployeeLinkedList(4, listItemB);

            var manager = new LinkedListManager();

            //here is merging to given two linked list (destiniy listItem1, source listItemA)
            manager.MergeLinkedList(listItem1, listItemA);

            //this value list is created for keeping all values in the linked list.
            var values = new List<int>();

            //here is doing to fill all values in the given linked list 
            manager.FillValuesFromListValues(values, listItem1);

            //here is Changing values in the list one after another. 
            manager.SetSortedValue(values.OrderBy(x=>x).ToList(), listItem1);

            //here is displaying all values 
            manager.PrintAllValue(listItem1);

        }
    }

    class EmployeeLinkedList
    {
        public EmployeeLinkedList(int value, EmployeeLinkedList next)
        {
            Value = value;
            Next = next;
        }
        public EmployeeLinkedList Next { get; set; }
        public int Value { get; set; }

    }

    class LinkedListManager
    {
        public void FillValuesFromListValues(List<int> values, EmployeeLinkedList list)
        {
            
            if (list == null)
            {                
                return;
            }
            values.Add(list.Value);
            FillValuesFromListValues(values, list.Next);
        }

        public void SetSortedValue(List<int> sortedList, EmployeeLinkedList list, int index = 0)
        {
            if (list == null)
            {
                return;
            }
            list.Value = sortedList[index];
            index++;
            SetSortedValue(sortedList, list.Next, index);
        }

        public void MergeLinkedList(EmployeeLinkedList destiniyToMerge, EmployeeLinkedList sourceToMarge)
        {
            if (destiniyToMerge.Next == null)
            {
                destiniyToMerge.Next = sourceToMarge;
                return;
            }
            MergeLinkedList(destiniyToMerge.Next, sourceToMarge);
        }

        public void PrintAllValue(EmployeeLinkedList list)
        {
            if (list == null)
            {
                Console.WriteLine("null");
                return;
            }
            Console.WriteLine(list.Value);
            PrintAllValue(list.Next);
        }
    }
}
