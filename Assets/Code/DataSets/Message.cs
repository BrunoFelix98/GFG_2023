using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Message
{
    [SerializeField]
    private int messageID;
    [SerializeField]
    private string text;
    [SerializeField]
    private int messageType; //0 = bad, 1 = good, 2 = neutral

    public int MessageID
    {
        get => messageID;
        set => messageID = value;
    }

    public string Text
    {
        get => text;
        set => text = value;
    }

    public int MessageType
    {
        get => messageType;
        set => messageType = value;
    }

    public Message(int messageID, string message, int messageType)
    {
        MessageID = messageID;
        Text = message;
        MessageType = messageType;
    }
}
