// C++ DLL

#include <stdio.h>
#include <cstdint>
#include <algorithm>

extern "C"
{
	__declspec(dllexport) 

		/*
		Funkcja realizuj�ca rozmycie
		@param width			- szeroko�� przekazywanego wiersza i tablicy
		@param height			- wysoko�� przekazywanej tablicy
		@param radius			- promie�, na podstawie kt�rego wyznaczana jest
								  wysoko�� tablicy s�siaduj�cych pixeli, a tak�e
								  stopie� intensywno�ci rozmycia
		@param row				- modyfikowany wiersz
		@param surroundingArea	- tablica pixeli znajduj�cych si� wok�
								  modyfikowanego wiersza, w celu analizy ich
								  warto�ci przy obliczaniu wyniku ko�cowego
								  pixela na danej pozycji

		*/
		void __stdcall BlurTransformRowC(int width, int height, int radius, uint8_t * row, uint8_t * surroundingArea)
	{
		// P�tla iteruj�ca po ka�dym pixelu przekazywanego wiersza.
		// Iteracja rozpoczyna si� dla pixela o offescie 3*radius.
		// Jest to spowodowane faktem, i� nie mo�na rozmywa� kraw�dzi
		// bitmapy, gdy� wok� nich musia�yby by� pobierane nieistniej�ce
		// pixele. Nawet przy za�o�eniu, �e by�yby one ca�kowicie czarne
		// przek�amuje znacznie wygl�d bitmapy na rogach, co nadaje
		// jej nienaturalnego wygl�du. Iteracje ko�cz� si� z tego samego
		// powodu na iteracji width - 3*radius, czyli od maksymalnej
		for (int x = 3*radius; x < width - 3*radius; x++)
		{

			// Zmienna, w kt�rej przechowywana jest suma warto�ci poszczeg�lnych
			// analizowanych pixeli
			int elementsSum = 0;

			// Zmienna, w kt�rej jest przechowywana liczba analizowanych pixeli
			int elementsAmount = 0;

			// Zewn�trzna p�tla s�u��ca do przej�cia po wszystkich wierszach 
			// tablicy pixeli umiejscowionych w obszarze wok� analizowanego
			// piksela z g��wnego wiersza
			for (int j = 0; j < height; ++j)
			{
				// Wewn�trzna petla s�u��ca do przej�cia po wszystkich pixelach
				// wiersza tablicy pikseli
				for (int i = -radius; i <= radius; ++i)
				{
					// Warto�� ka�dego piksela dodajemy do lokalnej sumy warto�ci,
					// pobierana jest ona z tablicy pikseli o offsecie obliczanym
					// na podstawie aktualnego przesuni�cia wyznaczonego wed�ug
					// wzoru: numer kolumny * szeroko�� wiersza + aktualny piksel
					// wiersza + trzykrotno�� numeru piksela z obecnego wiersza
					// tablicy
					elementsSum += surroundingArea[j * width + x + 3 * i];

					// Po znalezieniu element�w inkrementujemy ilo�� pikseli z
					// z obecnej iteracji aby si� dowiedzie� ile ich by�o
					elementsAmount++;
				}
			}

			// Flaga kontrolna dla ilo�ci element�w - je�eli mia�oby si� okaza�, �e
			// w danej iteracji nie by�o �adnego piksela to jest to zabezpieczenie
			// przeciw dzieleniu przez 0. Je�eli jakiekolwiek piksele wyst�pi�y to
			// nast�puj�ce obliczanie wyniku ko�cowego
			if (elementsAmount > 0)
			{
				// Rezultatem operacji jest obliczenie wyj�ciowej warto��ci piksela z
				// nast�puj�cego wzoru: suma pikseli na obszarze / ilo�� pikseli na
				// obszarze. To w�a�nie do tego by�a potrzebna zmienna obliczaj�ca
				// ilo�� element�w
				elementsSum /= elementsAmount;

				// Je�eli piksele by�y, ale ich warto�ci by�y poni�ej dolnej granicy
				// dopuszczalno�ci do oblicze� to nale�y poprawi� to �ci�gaj�c warto��
				// piksela do w�a�nie tej granicy
				if (elementsSum < 0)
				{
					elementsSum = 0;
				}
				// Je�eli do przek�amania dosz�o przy g�rnej granicy to nale�y przy tym
				// przyj��, �e piksel przyjmie maksymaln� warto��
				else if (elementsSum > 255)
				{
					elementsSum = 255;
				}
			}

			// Po obliczeniu warto�ci piksela nale�y go zapisa� do piksela, kt�ry
			// by� aktualnie analizowany w wierszu g��wnym
			row[x] = elementsSum;
		}

		// Po zako�czeniu oblicze� nie ma potrzeby zwraca� wyniku, gdy� nadpisywana
		// jest pami�� przekazywana jako argumenty funkjc, dlatego nast�puje powr�t
		// do programu g��wnego
		return;
	}
}