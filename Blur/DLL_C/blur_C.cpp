#include <stdio.h>
#include <cstdint>
#include <algorithm>

extern "C"
{
	__declspec(dllexport) 
		void __stdcall BlurTransformRowC(uint8_t * row, int rowSize, int radius)
	{
		unsigned int c = 0;

		for (int x = 0; x < rowSize; x++)
		{
			int red = row[c];
			int green = row[c + 1];
			int blue = row[c + 2];

			row[c + 0] = (uint8_t)std::min((.393 * red) + (.769 * green) + (.189 * blue), 255.0); // red
			row[c + 1] = (uint8_t)std::min((.349 * red) + (.686 * green) + (.168 * blue), 255.0); // green
			row[c + 2] = (uint8_t)std::min((.272 * red) + (.534 * green) + (.131 * blue), 255.0); // blue
			c = c + 3;
		}

		return;
	}
}