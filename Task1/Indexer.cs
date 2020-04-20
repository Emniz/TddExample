using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Indexer
    {
        double[] array;
        int first, length;

        public Indexer(double[] array, int first, int length)
        {
            if (CheckArg(array.Length, first, length))
            {
                this.array = array;
                this.first = first;
                this.length = length;
            }
            else throw new ArgumentException();
        }
        public bool CheckArg(int arrayLength, int first, int length)
        {
            if (first < 0 || length < 0 || (first + length) > arrayLength)
                return false;
            else
                return true;
        }

        public bool CheckIndex(int index)
        {
            if (index < 0 || index >= Length || index + first >= array.Length)
                return false;
            else
                return true;
        }

        public int Length
        {
            get
            {
                return length;
            }
        }

        public double this[int index]
        {
            get
            {
                if (CheckIndex(index))
                    return array[index + first];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (CheckIndex(index))
                    array[index + first] = value;
                else throw new IndexOutOfRangeException();
            }
        }
    }
}
