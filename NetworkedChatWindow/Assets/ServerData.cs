using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerData : NetworkBehaviour {

    public string currentMessage;

	public void ServerMessages(string newMessage)
    {
        currentMessage = newMessage;

        //RpcCastNewMessage(currentMessage);
    }
/*
    [ClientRpc]
    public void RpcCastNewMessage(string theMessage)
    {
        transform.GetComponents<TextManagerHandler>.ServerMessages(). = theMessage;
    }
    */
}
