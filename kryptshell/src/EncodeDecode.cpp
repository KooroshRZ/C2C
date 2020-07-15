#include "shell.h"

//char_set = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

char* base64Decode(char data[], int size) {

	char* decode = (char*)malloc(size * sizeof(char));
	
	int i, j, k = 0;

	// Store bitstream
	int num = 0;

	// count_bits stores current 
	// number of bits in num. 
	int count_bits = 0;

	for (i = 0; i < size; i += 4) {

		num = 0;
		count_bits = 0;

		for (j = 0; j < 4; j++) {

			if (data[i + j] != '=') {
				num = num << 6;
				count_bits += 6;
			}

			if (data[i + j] >= 'A' && data[i + j] <= 'Z')
				num = num | (data[i + j] - 'A');

			else if (data[i + j] >= 'a' && data[i + j] <= 'z')
				num = num | (data[i + j] - 'a' + 26);

			else if (data[i + j] >= '0' && data[i + j] <= '9')
				num = num | (data[i + j] - '0' + 52);

			else if (data[i + j] == '+')
				num = num | 62;

			else if (data[i + j] == '/')
				num = num | 63;

			else {
				num = num >> 2;
				count_bits -= 2;
			}

		}
		
		while (count_bits != 0) {
			count_bits -= 8;

			// 255 in binary is 11111111 
			decode[k++] = (num >> count_bits) & 255;
		}

	}

	decode[k] = '\0';

	return decode;

}