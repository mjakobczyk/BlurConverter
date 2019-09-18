// C++ DLL

#include <stdio.h>
#include <cstdint>
#include <algorithm>

extern "C"
{
	__declspec(dllexport) 

	/*
		Funkcja realizuj¹ca rozmycie
		@param width			of input array
		@param height			of input array
		@param radius			of blur conversion
		@param row				id to be modified
		@param surroundingArea	containing pixels around the modified row
	*/
	void __stdcall BlurTransformRowC(int width, int height, int radius, uint8_t * row, uint8_t * surroundingArea)
	{
		for (int x = 3*radius; x < width - 3*radius; x++)
		{
			int elementsSum = 0;

			int elementsAmount = 0;

			for (int j = 0; j < height; ++j)
			{
				for (int i = -radius; i <= radius; ++i)
				{
					elementsSum += surroundingArea[j * width + x + 3 * i];
					elementsAmount++;
				}
			}

			if (elementsAmount > 0)
			{
				elementsSum /= elementsAmount;

				if (elementsSum < 0)
				{
					elementsSum = 0;
				}
				else if (elementsSum > 255)
				{
					elementsSum = 255;
				}
			}

			row[x] = elementsSum;
		}

		return;
	}
}