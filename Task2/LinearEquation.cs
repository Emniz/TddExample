using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    public class LinearEquation
    {
        public List<double> indexes;
        public LinearEquation(double[] cf)
        {
            indexes = new List<double>(cf);
        }
        public LinearEquation(List<double> cf)
        {
            indexes = new List<double>(cf);
        }
        public LinearEquation(int n)
        {
            if (n > 0)
            {
                indexes = new List<double>();
                for (int i = 0; i <= n; i++)
                    indexes.Add(0);
            }
            else throw new ArgumentException();
        }
        public int Size
        {
            get
            {
                return indexes.Count;
            }
        }
        public LinearEquation(IEnumerable<double> cf)
        {
            indexes = new List<double>(cf);
        }
        public LinearEquation(string coeff)
        {
            string[] cf = Regex.Split(coeff, @"[^\d.-]");
            indexes = new List<double>();
            for (int i = 0; i < coeff.Length; i++)
            {
                if (cf[i] != "")
                {
                    cf[i] = cf[i].Replace('.', ',');
                    indexes.Add(double.Parse(cf[i]));
                }
            }
        }
        public void Random()
        {
            Random rand = new Random();
            for (int i = 0; i < Size; i++)
                indexes[i] = rand.Next(1,100);
        }
        public void MassArr(double value)
        {
            for (int i = 0; i < Size; i++)
                indexes[i] = value;
        }
        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < Size)
                    return indexes[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Size)
                    indexes[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public static LinearEquation operator +(LinearEquation a, LinearEquation b)
        {
            var result = a.indexes.Zip(b.indexes, (first, second) => first + second);
            return new LinearEquation(result);
        }
        public static LinearEquation operator -(LinearEquation a, LinearEquation b)
        {
            var result = a.indexes.Zip(b.indexes, (first, second) => first - second);
            return new LinearEquation(result);
        }
        public static LinearEquation operator *(LinearEquation a, double r)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Size; i++)
                result.Add(a[i] * r);
            return new LinearEquation(result);
        }
        public static LinearEquation operator *(double r, LinearEquation a)
        {
            return a * r;
        }
        public static LinearEquation operator -(LinearEquation a)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Size; i++)
                result.Add(-a[i]);
            return new LinearEquation(result);
        }
        public override string ToString()
        {
            string res = "";
            int i;
            for (i = 0; i < Size - 2; i++)
                res += (indexes[i + 1] >= 0) ? (indexes[i].ToString() + 'x' + (i + 1).ToString() + '+') : (indexes[i].ToString() + 'x' + (i + 1).ToString());
            res += (indexes[i].ToString() + 'x' + (i + 1).ToString());
            res += '=' + indexes[Size - 1].ToString();
            return res;
        }
        public static bool operator ==(LinearEquation a, LinearEquation b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(LinearEquation a, LinearEquation b)
        {
            return !(a == b);
        }
        public static implicit operator double[](LinearEquation a)
        {
            return a.indexes.ToArray();
        }
        public static bool operator false(LinearEquation a)
        {
            if (a)
                return false;
            else
                return true;
        }
        public static bool operator true(LinearEquation a)
        {
            for (int i = 0; i < a.Size - 1; i++)
                if (a[i] != 0)
                    return true;
            return (a[a.Size - 1] != 0) ? false : true;
        }
        public override bool Equals(object obj)
        {
            LinearEquation a = (LinearEquation)obj;
            for (int i = 0; i < Size; i++)
                if (Math.Abs(this[i] - a[i]) > 1e-9)
                    return false;
            return true;
        }
        public bool IsNull()
        {
            for (int i = 0; i < Size; i++)
                if (this[i] != 0)
                    return false;
            return true;
        }
        public void CopyTo(LinearEquation a)
        {
            a.indexes = indexes.ToList();
        }
    }
}
