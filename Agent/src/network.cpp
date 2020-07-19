#include "shell.h"

SOCKET connSock = INVALID_SOCKET;

char* recvData() {
	
	char sBuf[256] = "";

	int sSize = recv(connSock, sBuf, 256, 0);
	sBuf[sSize] = '\0';

	if (sSize > 0) {

		long dSize = atoi(sBuf);
		long dataSize = dSize;
		long toread = 0;

		char* data = new char[dSize + 1];

		//memcpy(data, (char*)"", dataSize);
		//data[dataSize] = '\0';

		
		//char* buf = new char[SOCK_BUFFER];
		//memcpy(buf, (char*)"", SOCK_BUFFER);

		char buf[SOCK_BUFFER+1];
		
		while (dSize > 0) {

			toread = dSize > SOCK_BUFFER ? SOCK_BUFFER : dSize;

			//char* buf = (char*) malloc(sizeof(char)*toread+1);
			

			//memcpy(buf, (char*)"", SOCK_BUFFER);

			
			printf("toread : %d\n", toread);

			int ret = 0;
			if (toread == SOCK_BUFFER)
				ret = recv(connSock, buf, toread, 0);
			else
				ret = recv(connSock, buf, toread, 0);

			
			buf[toread] = '\0';
			strcat(data, buf);
			dSize -= toread;
			printf("DSIZE : %d\n", dSize);

			//printf("%s\n", buf);
			printf("read : %d\n", ret);
			system("PAUSE");

			//char* buf = new char[SOCK_BUFFER];
			//memcpy(buf, (char*)"", SOCK_BUFFER);
			//data[SOCK_BUFFER - 1] = '\0';
			
				
		}

		data[dataSize-1] = '\0';

		printf("data : %s\n", data);
		//printf("address : %p\n", (void*)(data));

		return data;
	}
	
	return (char*)"wollawolla";
	
}

int initSock(LPCSTR ipAddress, int port) {

	WSADATA wsaData;

	int iResult = 1;

	// initialize Winsock
	// returns zero on success
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);

	if (iResult){
		printf("Error on WSAstartup() : %d\n", WSAGetLastError());
		return -1;
	}

	connSock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (connSock == INVALID_SOCKET) {
		printf("Error on socket() : %d\n", WSAGetLastError());
		return -1;
	}

	struct sockaddr_in server;

	server.sin_addr.S_un.S_addr = inet_addr(ipAddress);
	server.sin_family = AF_INET;
	server.sin_port = htons(port);

	int cResult = 1;
	while (cResult) {
		cResult = connect(connSock, (struct sockaddr*)&server, sizeof(server));
		Sleep(3000);
	}

	// set non-blocking

	//u_long iMode;
	//int ioctlResult = ioctlsocket(connSock, FIONBIO, &iMode);

	//if (ioctlResult != NO_ERROR)
	//	printf("ioctlsocket failed with error: %ld\n", ioctlResult);

	return 0;

}

