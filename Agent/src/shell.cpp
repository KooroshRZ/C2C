#include "shell.h"


int main() {

	initSock((LPCSTR)IP_ADDRESS, PORT);

	char* data = (char*)"";
	

	while (strcmp(data, "Exit\n") != 0) {
		
		data = recvData();

		system("PAUSE");

		printf("%s", data);
		//printf("Here : %s\n", base64Decode(data, sizeof(data)));

		if (!strcmp(data, (char*)"wollawolla")) {
			printf("Remote host closed the connection\n");
			break;
		}

	}

	system("PAUSE");

}