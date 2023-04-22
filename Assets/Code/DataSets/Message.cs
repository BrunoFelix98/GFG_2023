using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Message
{
    [SerializeField]
    private int messageID;
    [SerializeField]
    private string title;
    [SerializeField]
    private string description;
    [SerializeField]
    private int messageType; //0 = bad, 1 = good, 2 = neutral
    [SerializeField]
    private Sprite msgImage;

    public int MessageID
    {
        get => messageID;
        set => messageID = value;
    }

    public string Title
    {
        get => title;
        set => title = value;
    }

    public string Description
    {
        get => description;
        set => description = value;
    }

    public int MessageType
    {
        get => messageType;
        set => messageType = value;
    }

    public Sprite MsgImage
    {
        get => msgImage;
        set => msgImage = value;
    }

    public Message(int messageID, string title, string description, int messageType, Sprite msgImage)
    {
        MessageID = messageID;
        Title = title;
        Description = description;
        MessageType = messageType;
        MsgImage = msgImage;
    }
}
