// C++ DLL

#include <stdio.h>
#include <cstdint>
#include <algorithm>

extern "C"
{
	__declspec(dllexport) 

		/*
		Funkcja realizuj¹ca rozmycie
		@param width			- szerokoœæ przekazywanego wiersza i tablicy
		@param height			- wysokoœæ przekazywanej tablicy
		@param radius			- promieñ, na podstawie którego wyznaczana jest
								  wysokoœæ tablicy s¹siaduj¹cych pixeli, a tak¿e
								  stopieñ intensywnoœci rozmycia
		@param row				- modyfikowany wiersz
		@param surroundingArea	- tablica pixeli znajduj¹cych siê wokó³
								  modyfikowanego wiersza, w celu analizy ich
								  wartoœci przy obliczaniu wyniku koñcowego
								  pixela na danej pozycji

		*/
		void __stdcall BlurTransformRowC(int width, int height, int radius, uint8_t * row, uint8_t * surroundingArea)
	{
		// Pêtla iteruj¹ca po ka¿dym pixelu przekazywanego wiersza.
		// Iteracja rozpoczyna siê dla pixela o offescie 3*radius.
		// Jest to spowodowane faktem, i¿ nie mo¿na rozmywaæ krawêdzi
		// bitmapy, gdy¿ wokó³ nich musia³yby byæ pobierane nieistniej¹ce
		// pixele. Nawet przy za³o¿eniu, ¿e by³yby one ca³kowicie czarne
		// przek³amuje znacznie wygl¹d bitmapy na rogach, co nadaje
		// jej nienaturalnego wygl¹du. Iteracje koñcz¹ siê z tego samego
		// powodu na iteracji width - 3*radius, czyli od maksymalnej
		for (int x = 3*radius; x < width - 3*radius; x++)
		{

			// Zmienna, w której przechowywana jest suma wartoœci poszczególnych
			// analizowanych pixeli
			int elementsSum = 0;

			// Zmienna, w której jest przechowywana liczba analizowanych pixeli
			int elementsAmount = 0;

			// Zewnêtrzna pêtla s³u¿¹ca do przejœcia po wszystkich wierszach 
			// tablicy pixeli umiejscowionych w obszarze wokó³ analizowanego
			// piksela z g³ównego wiersza
			for (int j = 0; j < height; ++j)
			{
				// Wewnêtrzna petla s³u¿¹ca do przejœcia po wszystkich pixelach
				// wiersza tablicy pikseli
				for (int i = -radius; i <= radius; ++i)
				{
					// Wartoœæ ka¿dego piksela dodajemy do lokalnej sumy wartoœci,
					// pobierana jest ona z tablicy pikseli o offsecie obliczanym
					// na podstawie aktualnego przesuniêcia wyznaczonego wed³ug
					// wzoru: numer kolumny * szerokoœæ wiersza + aktualny piksel
					// wiersza + trzykrotnoœæ numeru piksela z obecnego wiersza
					// tablicy
					elementsSum += surroundingArea[j * width + x + 3 * i];

					// Po znalezieniu elementów inkrementujemy iloœæ pikseli z
					// z obecnej iteracji aby siê dowiedzieæ ile ich by³o
					elementsAmount++;
				}
			}

			// Flaga kontrolna dla iloœci elementów - je¿eli mia³oby siê okazaæ, ¿e
			// w danej iteracji nie by³o ¿adnego piksela to jest to zabezpieczenie
			// przeciw dzieleniu przez 0. Je¿eli jakiekolwiek piksele wyst¹pi³y to
			// nastêpuj¹ce obliczanie wyniku koñcowego
			if (elementsAmount > 0)
			{
				// Rezultatem operacji jest obliczenie wyjœciowej wartoœæci piksela z
				// nastêpuj¹cego wzoru: suma pikseli na obszarze / iloœæ pikseli na
				// obszarze. To w³aœnie do tego by³a potrzebna zmienna obliczaj¹ca
				// iloœæ elementów
				elementsSum /= elementsAmount;

				// Je¿eli piksele by³y, ale ich wartoœci by³y poni¿ej dolnej granicy
				// dopuszczalnoœci do obliczeñ to nale¿y poprawiæ to œci¹gaj¹c wartoœæ
				// piksela do w³aœnie tej granicy
				if (elementsSum < 0)
				{
					elementsSum = 0;
				}
				// Je¿eli do przek³amania dosz³o przy górnej granicy to nale¿y przy tym
				// przyj¹æ, ¿e piksel przyjmie maksymaln¹ wartoœæ
				else if (elementsSum > 255)
				{
					elementsSum = 255;
				}
			}

			// Po obliczeniu wartoœci piksela nale¿y go zapisaæ do piksela, który
			// by³ aktualnie analizowany w wierszu g³ównym
			row[x] = elementsSum;
		}

		// Po zakoñczeniu obliczeñ nie ma potrzeby zwracaæ wyniku, gdy¿ nadpisywana
		// jest pamiêæ przekazywana jako argumenty funkjc, dlatego nastêpuje powrót
		// do programu g³ównego
		return;
	}
}