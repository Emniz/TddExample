#pragma once
#include"LinearEquation.h"
#include<string>
class SystemLinearEquation
{
private:
	vector<LinearEquation> system;
	int n;
public:
	SystemLinearEquation(int _n) :n(_n) {}
	~SystemLinearEquation() { 
		vector<LinearEquation>().swap(system);}
	LinearEquation& operator[] (int index);
	int size();
	void shiftg();
	void add(LinearEquation&);
	void remove();
	vector<double> System();
	operator std::string();
};