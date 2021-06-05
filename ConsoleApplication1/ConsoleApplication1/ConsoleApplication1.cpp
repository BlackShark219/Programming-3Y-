
#include <stdio.h>

int main(void)
{
	float notExactFive = 5.4;
	float notExactNumber = 6.7;
	int exactFive;
	int roundedNumber;
	if (notExactNumber - notExactNumber > 0.5)
	{
		roundedNumber = (int)notExactNumber + 1;
	}
	else
	{
		roundedNumber = (int)notExactNumber + 1;
	}
	exactFive = (int)notExactFive;
	printf("Five is: %d\n", exactFive);
	printf("Rounded to seven: %d\n", roundedNumber);
	return 0;
}
