#ifndef __H_CONNECT_PROCESS
#define __H_CONNECT_PROCESS
#include <stdio.h>
#include <map>
#include "Export.h"
#include "RakNetTypes.h"
#include "PluginInterface2.h"
#include "FT_DataStruct.h"

namespace RakNet{

class RakPeerInterface;
class FT_ConnectProcess;

class FT_ConnectProcessResultHandler {

public:
	FT_ConnectProcessResultHandler (void){}
	virtual ~FT_ConnectProcessResultHandler (void){}

	virtual void OnConnectedToServer () = 0;

	virtual void OnFailedToConnect () = 0;

	virtual void OnLostConnection () = 0;

	virtual void OnDisconnectedFromServer () = 0;

	virtual void DebugReceive (int flag) = 0;

	virtual void ReceiveLog () = 0;

	virtual void ReceiveLog2 () = 0;

	virtual PluginReceiveResult OnReceive(Packet *packet) { return RR_CONTINUE_PROCESSING; }
};

class FT_ConnectProcessResultHandlerTest : public FT_ConnectProcessResultHandler {

public:

	FT_ConnectProcessResultHandlerTest(void){}
	virtual ~FT_ConnectProcessResultHandlerTest(void){}

public:
	virtual void OnConnectedToServer () {
		printf_s("OnConnectedToServer");
	}

	virtual void OnFailedToConnect () {
		printf_s("OnFailedToConnect");
	}

	virtual void OnLostConnection () {
		printf_s("OnLostConnection");
	}

	virtual void OnDisconnectedFromServer () {
		printf_s("OnDisconnectedFromServer");
	}

	virtual void DebugReceive (int flag) {
		printf_s("DebugReceive : %d \n", flag);
	}

	virtual void ReceiveLog () {
		printf_s("ReceiveLog");
	}
};

class RAK_DLL_EXPORT FT_ConnectProcess : public PluginInterface2
{
public:

	STATIC_FACTORY_DECLARATIONS(FT_ConnectProcess)

	FT_ConnectProcess(void);
	~FT_ConnectProcess(void);

	void SetResultHandler(FT_ConnectProcessResultHandler *rh);

	virtual void Update(void) {};
	virtual PluginReceiveResult OnReceive(Packet *packet);
	virtual void OnRakPeerShutdown(void);

private:
	FT_ConnectProcessResultHandler *resultHandler;
};

class FT_Node_Process {

public:
	STATIC_FACTORY_DECLARATIONS(FT_Node_Process)

	FT_Node_Process ();
	virtual ~FT_Node_Process ();

	virtual FT_MessageTypesNode GetNodeType() { return NODE_FT_None; }

	virtual void OnProcess (BitStream* bsIn) {}

};

class FT_Node_Plugin : public PluginInterface2
{
public:

	STATIC_FACTORY_DECLARATIONS(FT_Node_Plugin)

	FT_Node_Plugin(void);
	~FT_Node_Plugin(void);

	PluginReceiveResult OnReceive(Packet *packet);

	void RegisterProcess(FT_Node_Process* handler);

private:
	std::map<FT_MessageTypesNode,FT_Node_Process*>	_Handler;

};

}
#endif
