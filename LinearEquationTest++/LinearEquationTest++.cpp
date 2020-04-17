#include "pch.h"
#include "CppUnitTest.h"
#include"../Task2++/LinearEquation.h"
#include"../Task2++/LinearEquation.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace LinearEquationTestC
{
	TEST_CLASS(UnitTest1)
	{
	public:

		TEST_METHOD(MassInit)
		{
			LinearEquation a(10);
			a.MassInit(5.0);
			Assert::AreEqual(5.0, a[5]);
		}

		TEST_METHOD(CorrectIndex1)
		{
			std::vector<double>_a{ 1,2,3,7,8 };
			LinearEquation a(_a);
			Assert::AreEqual(2.0, a[1]);
		}

		TEST_METHOD(CorrectIndex2)
		{
			std::string s = "1,2,3,7,8";
			LinearEquation a(s);
			Assert::AreEqual(7.0, a[3]);
		}

		TEST_METHOD(CorrectIndex3)
		{
			LinearEquation a(10);
			Assert::AreEqual(0.0, a[3]);
		}

		TEST_METHOD(CorrectMult1)
		{
			std::string s = "1,2,3,4,5";
			LinearEquation a(s);
			a = a * 2.0;
			Assert::AreEqual(4.0, a[1]);
		}

		TEST_METHOD(CorrectMult2)
		{
			std::string s = "1,2,3,4,5";
			LinearEquation a(s);
			a = 3.0 * a;
			Assert::AreEqual(15.0, a[4]);
		}

		TEST_METHOD(CorrectSum)
		{
			std::string s1 = "1,3,5,7,9,12,15";
			std::string s2 = "1,2,3,4,5,6,7";
			LinearEquation a(s1);
			LinearEquation b(s2);
			LinearEquation res("2,5,8,11,14,18,22");
			Assert::AreEqual(true, res == (a + b));
		}

		TEST_METHOD(CorrectSub)
		{
			std::string s1 = "2,3,4,5,6";
			std::string s2 = "1,2,3,4,5";
			LinearEquation a(s1);
			LinearEquation b(s2);
			LinearEquation res("1,1,1,1,1");
			Assert::AreEqual(true, res == (a - b));
		}

		TEST_METHOD(CorrectUnaryMinus)
		{
			LinearEquation a("1,3,5,7,9");
			a = -a;
			Assert::AreEqual(-1.0, a[0]);
		}

		TEST_METHOD(CheckContradictoryEquation)
		{
			LinearEquation a("1.2,0,0,0");
			bool check = (a) ? true : false;
			Assert::AreEqual(false, check);
		}


		TEST_METHOD(CheckSolvableEquation)
		{
			LinearEquation a("1,4,0,0");
			bool check = (a) ? true : false;
			Assert::AreEqual(true, check);
		}

		TEST_METHOD(CopyToList)
		{
			LinearEquation a("1,1,0,-4");
			std::list<double> tmp = a;
			Assert::AreEqual(0.0, tmp.front());
		}

		TEST_METHOD(FailWithWrongIndexing1)
		{
			auto func = []() {

				LinearEquation a("1,2,3,5,6");
				double tmp = a[-18];
			};
			Assert::ExpectException<std::out_of_range>(func);
		}

		TEST_METHOD(FailWithWrongIndexing2)
		{
			auto func = []()
			{
				LinearEquation a("1,2,3,5,6");
				double tmp = a[18];
			};
			Assert::ExpectException<std::out_of_range>(func);
		}
	};
}