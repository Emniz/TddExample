using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace LinearEquationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitArray()
        {
            const int n = 5;
            double[] coeff = new double[n] { 1, 2, 3, 4, 5 };
            LinearEquation a1 = new LinearEquation(coeff);
            Assert.AreEqual(2, a1[1]);
        }

        [TestMethod]
        public void InitList()
        {
            List<double> coeff = new List<double>() { 1, 2, 3, 4, 5 };
            LinearEquation a1 = new LinearEquation(coeff);
            Assert.AreEqual(2, a1[1]);
        }

        [TestMethod]
        public void InitString()
        {
            string coeff = "1,2,3,4,5,6,7";
            LinearEquation a1 = new LinearEquation(coeff);
            Assert.AreEqual(3, a1[2]);
        }

        [TestMethod]
        public void CorrectSum()
        {
            string coeff1 = "1,3,5,7,9,12,15";
            LinearEquation a1 = new LinearEquation(coeff1);
            string coeff2 = "1,2,3,4,5,6,7";
            LinearEquation a2 = new LinearEquation(coeff2);
            string res = "2,5,8,11,14,18,22";
            Assert.AreEqual(new LinearEquation(res), a1 + a2);
        }

        [TestMethod]
        public void CorrectSub()
        {
            string coeff1 = "2,3,4,5,6";
            LinearEquation a1 = new LinearEquation(coeff1);
            string coeff2 = "1,2,3,4,5";
            LinearEquation a2 = new LinearEquation(coeff2);
            string res = "1,1,1,1.1,1";
            Assert.AreEqual(new LinearEquation(res), a1 - a2);
        }

        [TestMethod]
        public void CorrectMul1()
        {
            string coeff = "1,2,3,4,5";
            LinearEquation a = new LinearEquation(coeff);
            string res = "2,4,6,8,10";
            Assert.AreEqual(new LinearEquation(res), a * 2);
        }

        [TestMethod]
        public void CorrectMul2()
        {
            string coeff = "1,2,3,4,5";
            LinearEquation a = new LinearEquation(coeff);
            string res = "2,4,6,8,10";
            Assert.AreEqual(new LinearEquation(res), 2 * a);
        }
   
        [TestMethod]
        public void CorrectMinus()
        {
            string coeff = "1,3,5,7,9";
            LinearEquation a = new LinearEquation(coeff);
            string res = "-1,-3,-5,-7,-9";
            Assert.AreEqual(new LinearEquation(res), -a);
        }

        [TestMethod]
        public void CorrectInitMass()
        {
            LinearEquation a = new LinearEquation(4);
            a.InitMass(1.2);
            string res = "1,2,3,4,5";
            Assert.AreEqual(new LinearEquation(res), a);
        }

        [TestMethod]
        public void Zero()
        {
            int n = 5;
            LinearEquation a = new LinearEquation(n);
            Assert.AreEqual("0x1+0x2+0x3+0x4+0x5=0", a.ToString());
        }

        [TestMethod]
        public void CorrectIndex()
        {
            string coeff = "1,2,3,7,8";
            LinearEquation a = new LinearEquation(coeff);
            Assert.AreEqual(3, a[2]);
        }

        [TestMethod]
        public void BadEquation()
        {
            string res = "1.2,0,0,0";
            LinearEquation a = new LinearEquation(res);
            bool check = (a) ? true : false;
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void TrueEquation()
        {
            string res = "1,4,0,0";
            LinearEquation a = new LinearEquation(res);
            bool check = (a) ? true : false;
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailIndex1()
        {
            string coeff = "1,2,3,5,6";
            LinearEquation a = new LinearEquation(coeff);
            Assert.Equals(typeof(IndexOutOfRangeException), a[18]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailIndex2()
        {
            string coeff = "1,2,3,5,6";
            LinearEquation a = new LinearEquation(coeff);
            Assert.Equals(typeof(IndexOutOfRangeException), a[-18]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailArgument()
        {
            Assert.Equals(typeof(ArgumentException), new LinearEquation(-50));
        }
    }
}
