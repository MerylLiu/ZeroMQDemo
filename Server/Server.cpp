// Server.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Lib\zmq.h"
#include "Lib\zmq_utils.h"

#pragma comment(lib,"libzmq.lib") 

int _tmain(int argc, _TCHAR* argv[])
{
	void *m_context;
	void *m_publisher;

	char pubLocalAddr[64] = {0};
	sprintf_s(pubLocalAddr,"tcp://*:%d",8585);

	m_context = zmq_init(1);
	m_publisher = zmq_socket(m_context,ZMQ_PUB);

	zmq_bind(m_publisher,pubLocalAddr);

	char *msg = "test1234555testss";


	while (1)
	{
		DWORD sendlen = zmq_send(m_publisher,msg,strlen(msg),0);

		printf("发布信息：%s\n",msg);

		Sleep(1000);
	}

	zmq_close(m_publisher);
	zmq_term(m_context);

	return 1;
}

