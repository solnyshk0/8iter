#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	int a, b, c, d;

	cout << "Введите 4 числа" << endl;
	cin >> a >> b >> c >> d;


	cout << "Среднее арифметическое четырех чисел =" <<(double)(a + b + c + d) / 4 << endl;
}