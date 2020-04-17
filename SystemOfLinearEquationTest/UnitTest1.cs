using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace SystemOfLinearEquationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Answer()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1.0,-2.0,1.0,0.0"));
            s.Add(new LinearEquation("2.0,2.0,-1.0,3.0"));
            s.Add(new LinearEquation("4.0,-1,1.0,5.0"));
            s.Shiftg();
            double[] res1 = new double[] { 2, 1, 3 };
            double[] res2 = s.System();
            bool check = true;
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(res1[i] - res2[i]) > 1e-9)
                    check = false;
            }
            Assert.AreEqual(true, check);
        }
        [TestMethod]
        public void CorrectIndexLine()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1,-2,1,0"));
            s.Add(new LinearEquation("2,2,-1,3"));
            s.Add(new LinearEquation("4,-1,1,5"));
            Assert.AreEqual(new LinearEquation("1,-2,1,0"), s[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithIndexing1()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1,-2,1,0"));
            s.Add(new LinearEquation("2,2,-1,3"));
            s.Add(new LinearEquation("4,-1,1,5"));
            Assert.Equals(typeof(IndexOutOfRangeException), s[18]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithIndexing2()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1,-2,1,0"));
            s.Add(new LinearEquation("2,2,-1,3"));
            s.Add(new LinearEquation("4,-1,1,5"));
            Assert.Equals(typeof(IndexOutOfRangeException), s[-5]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoSolutions()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("2.0,6.0,-5.0, 5.0"));
            s.Add(new LinearEquation("4.0,12.0,-10.0, -20.0"));
            s.Add(new LinearEquation("4.0,12.0,-10.0, -20.0"));
            s.Shiftg();
            Assert.Equals(typeof(ArgumentException), s.System());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InfSolutions()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("2.0,6.0,-5.0,10.0"));
            s.Add(new LinearEquation("4.0,12.0,-10.0,20.0"));
            s.Add(new LinearEquation("4.0,12.0,-10.0,20.0"));
            s.Shiftg();
            Assert.Equals(typeof(ArgumentException), s.System());
        }
    }
}
