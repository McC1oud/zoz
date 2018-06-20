using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TextManagerHandler : NetworkBehaviour {

    public int maxMessages = 100;

    public GameObject serverReference;

    public GameObject chatPanel, textObject;
    public InputField chatBox;

    [SerializeField]
    List<Message> messageList = new List<Message>();


	void Start ()
    {
        if(isServer)
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
        /*
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }
           

        if(!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //SendMessageToChat("You pressed space!");
                //Debug.Log("Space");
            }
        }
    }
    
    void Update ()
    {

    public void SendMessageToChat(string text)
    {
        if(messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = "Nelson: " + newMessage.text;

        serverReference.transform.GetComponent<ServerData>().ServerMessages(newMessage.textObject.text);

        newMessage.textObject.text = serverReference.transform.GetComponent<ServerData>().currentMessage;

        messageList.Add(newMessage);


    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}
