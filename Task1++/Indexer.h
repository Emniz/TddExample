#pragma once
class Indexer
{
private:
	double* array;
	int first;
	int length;
	bool CheckArg(int, int, int);
	bool CheckIndex(int, int, int);

public:
	Indexer(double* array, int, int, int);
	~Indexer() {}
	int getLength() 
	{ 
		return length; 
	}
	double& operator[] (int index);
};

