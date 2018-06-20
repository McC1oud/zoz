using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class TextManagerHandler : NetworkBehaviour {

    public string currentServerMessage;
    public string playerName;

    public int maxMessages = 100;

    public GameObject chatPanel, textObject;
    public InputField chatBox, nameBox;

    [SerializeField]
    List<Message> messageList = new List<Message>();


	void Start ()
    {
        nameBox.onEndEdit.AddListener(SetPlayerName);
        chatBox.onEndEdit.AddListener(UpdateMessages);

        if (isServer)
        {
            return;
        }

		if(!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
	}
    
    private void UpdateMessages(string arg0)
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text);
                chatBox.text = "";
            }
        }
    }

    private void SetPlayerName(string arg0)
    {
        if (nameBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playerName = nameBox.text;
                Destroy(nameBox.gameObject);
            }
        }
    }
    
    void Update ()
    {

    }



    public void SendMessageToChat(string text)
    {
        if(messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        CmdSendThisToServer(playerName + ": " + text);
    }
    
    [Command]
    public void CmdSendThisToServer(string messageToServer)
    {
        currentServerMessage = messageToServer;

        RpcSendThisToClients(currentServerMessage);
    }

    [ClientRpc]
    public void RpcSendThisToClients(string messageToClients)
    {
        print(messageToClients);

        Message newMessage = new Message();

        newMessage.text = messageToClients;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }


}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}



