#include <iostream>
#include <ctime>

using namespace std;

void input(int* arr, int l)	 // Ввод массива
{
	for (int i = 0; i < l; i++)
	{
		cin >> arr[i];
	}
}

void randinput(int* arr, int l) // Заполнение массива рандомными числами от 0 до 30
{
	for (int i = 0; i < l; i++)
	{
		arr[i] = rand() % 30;
	}
}

void output(int* arr, int l)  // Вывод массива
{
	for (int i = 0; i < l; i++)
	{
		cout << arr[i];
		if (i < l - 1)
		{
			cout << ", ";
		}
	}

	cout << endl;
}

void copyarr(int* arr, int* ver, int l)  // Копирование массива
{
	for (int i = 0; i < l; i++)
	{
		ver[i] = arr[i];
	}
}

void MonteCarlo(int* arr, int l) // Сортировка методом Монте Карло
{
	int count = rand() % 20;
	int tmp;
	for (int i = 0; i < count; i++)
	{
		int p1 = rand() % l;
		int p2 = rand() % l;
		tmp = arr[p1];
		arr[p1] = arr[p2];
		arr[p2] = tmp;
	}
}

void LasVegas(int* arr, int l) // Сортировка массива методом Лас Вегаса
{
	bool exit = true;
	while (exit)
	{
		for (int i = 0; i < l - 1; i++)
		{
			if (arr[i] > arr[i + 1])
			{
				exit = true;
				break;
			}
			else
			{
				exit = false;
			}
		}
		if (exit)
		{
			MonteCarlo(arr, l);
			cout << "101" << endl;
		}
	}
}

bool Check(int** arr, int n) // Проверка на выполнения условий решения задачи о n-ферзях
{
	bool Normal = true;
	int lineSum, columnSum, diagSum1, diagSum2, diagSum3, diagSum4, diagMain, diagSec;
	diagMain = 0;
	diagSec = 0;
	int k = 0;
	int l = 0;
	int r = 0;
	for (int i = 0; i < n; i++) // Проверка на кол-во элементов в строках, столбцах, главной и побочной диагоналях
	{
		lineSum = 0;
		columnSum = 0;
		diagMain += arr[i][i];
		diagSec += arr[i][n - 1 - i];
		for (int j = 0; j < n; j++)
		{
			lineSum += arr[i][j];
			columnSum += arr[j][i];
		}
		if (lineSum > 1 || columnSum > 1 || diagMain > 1 || diagSec > 1)
		{
			Normal = false;
			break;
		}
	}
	for (int i = 0; i < n; i++) // Проверка на кол-во элементов на диагоналях параллельных главной и побочной
	{
		k = i;
		r = n - i - 1;
		diagSum1 = 0;
		diagSum2 = 0;
		diagSum3 = 0;
		diagSum4 = 0;
		for (int j = 0; k > -1; j++)
		{
			diagSum1 += arr[k][j];
			diagSum2 += arr[n - j - 1][r];
			k--;
			r++;
		}
		l = 0;
		for (int j = n - i - 1; j < n; j++)
		{
			diagSum3 += arr[l][j];
			diagSum4 += arr[j][l];
			l++;
		}
		if (diagSum1 > 1 || diagSum2 > 1 || diagSum3 > 1 || diagSum4 > 1)
		{
			Normal = false;
			break;
		}
	}
	return Normal;
}

void Show(int** arr, int n) // функция вывода двумерного массива
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout << arr[i][j] << " ";
		}
		cout << endl;
	}
}

void Comb(int n) // Функция решения задачи о n-ферзях методом Лас-Вегаса
{
	int** arr = new int* [n];
	for (int i = 0; i < n; i++)
		arr[i] = new int[n];
	bool exit = true;
	bool result = false;
	while (exit)
	{
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				arr[i][j] = 0;
			}
		}
		int j;
		for (int i = 0; i < n; i++)
		{
			j = rand() % n;
			arr[i][j] = 1;
		}
		result = Check(arr, n);
		if (result)
		{
			exit = false;
		}
		cout << "101" << endl;
	}
	Show(arr, n);
	for (int i = 0; i < n; i++)
		delete[]arr[i];
	delete[]arr;
}

using namespace std;

int main()
{
	srand(time(NULL));
	setlocale(LC_ALL, "rus");

	cout << "\t\t\tМинистерство науки и высшего образования Российской Федерации \n"
		<< "\t\t\t\t   федеральное государственное бюджетное\n"
		<< "\t\t\t      образовательное учреждение высшего образования \n"
		<< "\t\t\t «Российский экономический университет имени Г.В. Плеханова»\n"
		<< "\t\t\t   Институт математики, информационных систем и цифровой экономики\n"
		<< "\t\t\t    Базовая кафедра цифровой экономики института развития \n"
		<< "\t\t\t\t\t   информационного общества\n"
		<< "\n\n\n\t\t\t\t\t\tКУРСОВАЯ РАБОТА\n"
		<< "\t\t\tпо дисциплине «Структуры и алгоритмы компьютерной обработки данных»\n"
		<< "\t\t\t\t\t на тему «Вероятностные алгоритмы»\n\n\n"
		<< "\t\t\t\t\t\t\t\t\tВыполнил \n"
		<< "\t\t\t\t\t\t\t\t\tобучающийся группы 15.11д-мо12/19б\n"
		<< "\t\t\t\t\t\t\t\t\tочной формы обучения\n"
		<< "\t\t\t\t\t\t\t\t\tинститута математики,\n"
		<< "\t\t\t\t\t\t\t\t\tинформационных систем\n"
		<< "\t\t\t\t\t\t\t\t\tи цифровой экономики\n"
		<< "\t\t\t\t\t\t\t\t\tАндриевский Тарас Эдуардович.\n\n"
		<< "\t\t\t\t\t\t\t\t\tНаучный руководитель:\n"
		<< "\t\t\t\t\t\t\t\t\tДоцент Н.В. Комлева\n"
		<< "\n\n\n\t\t\t\t\t\tМосква – 2021\n";

	system("pause");
	system("cls");

	int chose1;

	bool exit = true;
	while (exit) // Цикл обеспечивающий работоспособность меню, работающий до тех пор пока пользователь не выберет пункт отвечающий за завершение работы программы
	{
		cout << "1.Вероятностный подход к сортировке массивов." << endl
			<< "2.Вероятностный подход к решению задачи о n-ферзях." << endl
			<< "3.Завершить работу программы." << endl;
		cin >> chose1;
		if (chose1 == 1) // Обработка выбранного пользователем пункта меню
		{
			system("cls");
			bool leave = true;
			while (leave)  // Цикл обеспечивающий работоспособность вложенного меню
			{
				cout << "Введите каким способом хотите заполнить массив:" << endl
					<< "1.С клавиатуры." << endl
					<< "2.Рандомное заполнение массива числами от 0 до 30." << endl;
				int chose2 = 0;
				cin >> chose2;
				system("cls");
				cout << "Введите кол-во элементов массива:" << endl;
				int l;
				cin >> l;
				system("cls");
				int* arr = new int[l];
				int* ver = new int[l];
				if (chose2 == 1)// Обработка выбранного пользователем пункта меню
				{
					input(arr, l);
				}
				else if (chose2 == 2)// Обработка выбранного пользователем пункта меню
				{
					randinput(arr, l);
					cout << "Сгененрированный массив :" << endl;
					output(arr, l);
				}
				bool back = true;
				while (back) // Цикл отвечающий за работу вложенного меню, работающий до тех пор пока пользователь не выберет пункт возврата в основное меню или возврата в предыдущему уровню меню
				{
					copyarr(arr, ver, l);
					int chose3 = 0;
					cout << "1.Сортировка методом Монте-Карло." << endl
						<< "2.Сортировка методом Лас-Вегаса." << endl
						<< "3.Создать новый массив." << endl
						<< "4.Вернуться обратно в меню." << endl;
					cin >> chose3;
					if (chose3 == 1)// Обработка выбранного пользователем пункта меню
					{
						bool sorted = false;
						for (int i = 0; i < l - 1; i++)
						{
							if (ver[i] > ver[i + 1])
							{
								sorted = false;
								break;
							}
							else
							{
								sorted = true;
							}
						}
						if (!sorted)
						{
							MonteCarlo(ver, l); // Вызов функции сортировки массива методом Монте-Карло
							for (int i = 0; i < l - 1; i++)
							{
								if (ver[i] > ver[i + 1])
								{
									sorted = false;
									break;
								}
								else
								{
									sorted = true;
								}
							}
						}
						if (sorted)
						{
							cout << "Массив отсортирован." << endl;
							output(ver, l);
						}
						else
						{
							cout << "Массив не отсортирован." << endl;
						}
					}
					else if (chose3 == 2)// Обработка выбранного пользователем пункта меню
					{
						LasVegas(ver, l); // Вызов функции сортировки массива методом Лас-Вегаса
						output(ver, l); // Вызов функции вывода массива
					}
					else if (chose3 == 3)// Обработка выбранного пользователем пункта меню
					{
						cout << "Возврат к созданию массива." << endl;
						back = false; // Выход в уровень меню выше
					}
					else if (chose3 == 4)// Обработка выбранного пользователем пункта меню
					{
						cout << "Возврат в меню." << endl;
						back = false;
						leave = false; // Выход в основное меню
					}
					else // Защита от выбора несуществующего пункта меню
					{
						cout << "Вы выбрали пункт который не соответствует ни одному пункту меню." << endl;
					}
					system("pause");
					system("cls");
				}
				delete[]arr;
				delete[]ver;
			}

		}
		if (chose1 == 2) // Обработка выбранного пользователем пункта меню
		{
			system("cls");
			bool leave = true;
			while (leave) // Цикл обеспечивающий работоспособность вложенного меню, работающий до тех пор пока пользователь не выберет соответствующий определенный пункт в данном меню
			{
				int chose2 = 0;
				cout << "1.Решить задачу о n-ферзях методом Лас Вегаса." << endl
					<< "2.Вернуться обратно в меню." << endl;
				cin >> chose2;
				system("cls");
				if (chose2 == 1) // Обработка выбранного пользователем пункта меню
				{
					int n;
					cout << "Введите количество ферзей для которого хотите получить решение:";
					cin >> n;
					system("cls");
					cout << "В ответе единица означает ферзя." << endl;
					Comb(n); // Вызов функции решения задачи о расстановке n-ферзей на поле размером n*n
					system("pause");
					system("cls");
				}
				else if (chose2 == 2) // Обработка выбранного пользователем пункта меню
				{
					system("cls");
					leave = false;
				}
			}
		}
		if (chose1 == 3) // Обработка выбранного пользователем пункта меню
		{
			exit = false; // Завершение работы программы
		}
		system("cls");
	}

	return 0;
}