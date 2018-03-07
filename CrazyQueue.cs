using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Generic_Crazy_Queue
{
    public class CrazyQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        // if true, run probs, if not, run normal
        public bool IsCrazy { get; set; }
        // Front property (read only)
        public T Front { get { return CQueue[0]; } }
        // Size property (read only)
        public int Size { get { return CQueue.Count; } }
        // IsEmpty (read only)
        public bool IsEmpty { get { return (CQueue.Count == 0); } }
        private Random Rand = new Random();
        private int Chance;
        // The queue itself
        private List<T> CQueue = new List<T>();
        private T Temp;

        // constructor
        public CrazyQueue(bool ic = true)
        {
            IsCrazy = ic;
        }

        // enqueue
        public void Enqueue(T element)
        {
            if (IsCrazy)
            {
                Chance = Rand.Next(100) + 1;
                //75
                if (Chance < 75)
                {
                    //normal op, add element to back
                    CQueue.Add(element);
                }
                //25
                else
                {
                    //duplicate element and put in two random locations
                    Chance = Rand.Next(CQueue.Count);
                    CQueue.Insert(Chance, element);
                    Chance = Rand.Next(CQueue.Count);
                    CQueue.Insert(Chance, element);
                }
            }
            else
            {
                //normal op, add element to back
                CQueue.Add(element);
            }
        }

        // dequeue
        public T Dequeue()
        {
            if (IsCrazy)
            {
                Chance = Rand.Next(100) + 1;
                //50
                if (Chance < 50)
                {
                    //normal op, remove and return front element
                    Temp = CQueue[0];
                    CQueue.Remove(Temp);
                    return Temp;
                }
                //25
                else if (Chance < 75)
                {
                    //remove and return a random element from the first half
                    Chance = Rand.Next(CQueue.Count / 2) + 1;
                    Temp = CQueue[Chance];
                    CQueue.Remove(Temp);
                    return Temp;
                }
                //15
                else if (Chance < 90)
                {
                    //remove and return the most duplicated element
                    //if there's a tie, return an random element 
                    // from the group of most duplicated
                    Temp = getMostDuplicated();
                    return Temp;
                }
                //10
                else
                {
                    //remove and return least element
                    Temp = CQueue[0];
                    for (int i = 0; i < CQueue.Count; i++)
                    {
                        if (Temp.CompareTo(CQueue[i]) > 1)
                        {
                            Temp = CQueue[i];
                        }
                    }
                    return Temp;
                }
            }
            else
            {
                //normal op , remove and return front element
                Temp = CQueue[0];
                CQueue.Remove(Temp);
                return Temp;
            }
        }

        //private method to find the most duplicated element
        private T getMostDuplicated()
        {
            // I'm aware it would have been easier with LINQ, 
            // but I'm not familiar enough with LINQ to find
            // the easier solution

            // Yay, I found a use for tuples!
            // List of tuples that holds (T value, int number)
            List<(T val, int num)> numApps = new List<(T val, int num)>();
            // count for number of appearances
            int apps = 0;
            // iterate through CQueue, fill list of tuples
            for (int k = 0; k < CQueue.Count; k++)
            {
                for (int j = 0; j < CQueue.Count; j++)
                {
                    if (CQueue[k].Equals(CQueue[j]))
                    {
                        apps++;
                    }
                }
                numApps.Add((CQueue[k], apps));
                apps = 0;
            }
            // find greatest number
            int max = 0;
            for (int m = 0; m < numApps.Count; m++)
            {
                if (numApps[m].Item2 > max)
                    max = numApps[m].Item2;
            }
            // for all tuples in numApps with max appearances, add the values to a new list
            List<T> valueSet = new List<T>();
            for (int v = 0; v < numApps.Count; v++)
            {
                if (numApps[v].Item2 == max)
                    valueSet.Add(numApps[v].Item1);
            }
            // set random value to temp
            Chance = Rand.Next(valueSet.Count);
            Temp = valueSet[Chance];
            // return temp
            return Temp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)CQueue).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)CQueue).GetEnumerator();
        }

        public CQueueEnum<T> GetEnumerator()
        {
            return new CQueueEnum<T>(CQueue);
        }
    }
}
