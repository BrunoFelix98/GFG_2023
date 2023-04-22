using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room
{
    [SerializeField]
    private int roomID;
    [SerializeField]
    private string roomName;
    [SerializeField]
    private Activity[] activities;

    public int RoomID
    {
        get => roomID;
        set => roomID = value;
    }

    public string RoomName
    {
        get => roomName;
        set => roomName = value;
    }

    public Activity[] Activities
    {
        get => activities;
        set => activities = value;
    }

    public Room(int roomID, string roomName, Activity[] activities)
    {
        this.RoomID = roomID;
        this.RoomName = roomName;
        this.Activities = activities;
    }
}
