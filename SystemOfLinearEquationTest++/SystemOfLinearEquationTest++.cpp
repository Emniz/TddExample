#include "pch.h"
#include "CppUnitTest.h"
#include"../Task2++/LinearEquation.h"
#include"../Task2++/LinearEquation.cpp"
#include"../Task2++/SystemOfLinearEquation.h"
#include"../Task2++/SystemOfLinearEquation.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace SystemOfLinearEquationTestC
{
	TEST_CLASS(UnitTest1)
	{
	public:

		TEST_METHOD(CorrectAnswer)
		{
			int n = 3;
			SystemOfLinearEquation s(n);
			LinearEquation a1("3.0, -1.0,1.0, 4.0");
			LinearEquation a2("2.0, -5.0, -3.0, -17.0");
			LinearEquation a3("1.0, 1.0, -1.0, 0.0");
			s.add(a1);
			s.add(a2);
			s.add(a3);
			s.shiftg();
			std::vector<double> res1 = s.System();
			bool check = true;
			std::vector<double>res2{ 1,2,3 };
			for (int i = 0; i < res1.size(); i++)
				if (abs(res1[i] - res2[i]) > 1e-9) check = false;
			Assert::AreEqual(true, check);
		}

		TEST_METHOD(CorrectIndex)
		{
			SystemOfLinearEquation s(3);
			s.add(LinearEquation("1,-2,1,0"));
			s.add(LinearEquation("2,2,-1,3"));
			s.add(LinearEquation("4,-1,1,5"));
			Assert::AreEqual(1.0, s[0][0]);
		}

		TEST_METHOD(NoSolutions)
		{
			auto func = []()
			{
				int n = 3;
				SystemOfLinearEquation s(n);
				LinearEquation a1("2.0,6.0,-5.0,5.0");
				LinearEquation a2("4.0,12.0,-10.0,20.0");
				LinearEquation a3("4.0,12.0,-10.0,20.0");
				s.add(a1);
				s.add(a2);
				s.add(a3);
				s.shiftg();
				std::vector<double> res1 = s.System();
			};
			Assert::ExpectException< std::invalid_argument>(func);
		}

		TEST_METHOD(InfSolutions)
		{
			auto func = []()
			{
				int n = 3;
				SystemOfLinearEquation s(n);
				LinearEquation a1("2.0,6.0,-5.0,10.0");
				LinearEquation a2("4.0,12.0,-10.0,20.0");
				LinearEquation a3("4.0,12.0,-10.0,20.0");
				s.add(a1);
				s.add(a2);
				s.add(a3);
				s.shiftg();
				std::vector<double> res1 = s.System();
			};
			Assert::ExpectException< std::invalid_argument>(func);
		}

		TEST_METHOD(FailWithIndexing1)
		{
			auto func = []()
			{
				SystemOfLinearEquation s(3);
				s.add(LinearEquation("1,-2,1,0"));
				s.add(LinearEquation("2,2,-1,3"));
				s.add(LinearEquation("4,-1,1,5"));
				LinearEquation tmp = s[-18];
			};
			Assert::ExpectException<std::out_of_range>(func);
		}

		TEST_METHOD(FailWithIndexing2)
		{
			auto func = []()
			{
				SystemOfLinearEquation s(3);
				s.add(LinearEquation("1,-2,1,0"));
				s.add(LinearEquation("2,2,-1,3"));
				s.add(LinearEquation("4,-1,1,5"));
				LinearEquation tmp = s[18];
			};
			Assert::ExpectException<std::out_of_range>(func);
		}

		TEST_METHOD(FailWithAddEquation)
		{
			auto func = []()
			{
				SystemOfLinearEquation s(3);
				s.add(LinearEquation("1,2,3,5,6,7,8"));
			};
			Assert::ExpectException<std::invalid_argument>(func);
		}
	};
}