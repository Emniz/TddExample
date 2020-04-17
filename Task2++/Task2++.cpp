#include"SystemOfLinearEquation.h"
#include"LinearEquation.h"
#include <iostream>
#include<vector>
#include<ctime>
using namespace std;

int main()
{	
	int n = 3;
	srand(time(NULL));
	SystemLinearEquation s(n);
	LinearEquation a1(3);
	LinearEquation a2(3);
	LinearEquation a3(3);
	a1.randomInit();
	a2.randomInit();
	a3.randomInit();
	s.add(a1);
	s.add(a2);
	s.add(a3);
	cout << (string)s << endl;
	s.shiftg();
	cout << (string)s << endl;
	vector<double> ans = s.System();
	for (int i = 0; i < ans.size(); i++)
		cout << ans[i] << "   ";
}