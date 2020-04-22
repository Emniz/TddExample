#pragma once
#include"LinearEquation.h"
#include<string>

class SystemOfLinearEquation
{
private:
	std::vector<LinearEquation> system;
	int n;
public:
	SystemOfLinearEquation(int _n) :n(_n) {}
	~SystemOfLinearEquation() { std::vector<LinearEquation>().swap(system); }
	LinearEquation& operator[] (int index);
	int size();
	void add(LinearEquation&);
	void remove();
	void shiftg();
	std::vector<double> System();
	operator std::string();
};