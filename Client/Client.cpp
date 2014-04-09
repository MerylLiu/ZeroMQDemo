// Client.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "zmq.h"
#include "zmq_utils.h"

#pragma comment(lib,"libzmq.lib")

int _tmain(int argc, _TCHAR* argv[])
{
	void *m_context;
	void *m_subscriber;
	char m_subAddr[64];

	m_context = zmq_init(1);
	m_subscriber = zmq_socket(m_context,ZMQ_SUB);

	char *puberIp = "127.0.0.1";
	WORD port = 8585;

	memset(m_subAddr,0,sizeof(m_subAddr));
	sprintf_s(m_subAddr,"tcp://%s:%d",puberIp,port);

	zmq_connect(m_subscriber,m_subAddr);

	int ret = zmq_setsockopt(m_subscriber,ZMQ_SUBSCRIBE,"sss",0);

	while (1)
	{
		BYTE buffer[1024] = {0};
		DWORD bufLen = sizeof(buffer);
		DWORD gotLen = zmq_recv(m_subscriber,buffer,bufLen,0);

		printf("收到发布信息：%s\n",buffer);
	}

	zmq_close(m_subscriber);
	zmq_term(m_context);

	return 0;
}

