#include "Indexer.h"
#include<stdexcept>
#include<exception>

Indexer::Indexer(double* array, int arrLength, int begin, int length)
{
	if (CheckArg(arrLength, begin, length))
	{
		this->array = array;
		this->first = begin;
		this->length = length;
	}
	else throw std::invalid_argument("ArgumentException");
}

double& Indexer::operator[](int index)
{
	if (CheckIndex(first, length, index))
		return array[first + index];
	else throw std::invalid_argument("IndexOutOfRangeException");
}

bool Indexer::CheckArg(int arrLength, int first, int length)
{
	if (first < 0 || length <= 0 || (first + length) > arrLength)
		return false;
	else
		return true;
}

bool Indexer::CheckIndex(int first, int length, int index)
{
	if (index < 0 || (index + first) > length)
		return false;
	else
		return true;
}
