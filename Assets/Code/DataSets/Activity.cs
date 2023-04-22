using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Activity
{
    [SerializeField]
    private int activityID;
    [SerializeField]
    private string activityName;
    [SerializeField]
    private Effect[] effect;

    public int ActivityID
    {
        get => activityID;
        set => activityID = value;
    }

    public string ActivityName
    {
        get => activityName;
        set => activityName = value;
    }

    public Effect[] Effect
    {
        get => effect;
        set => effect = value;
    }

    public Activity(int activityID, string activityName, Effect[] effect)
    {
        this.activityID = activityID;
        this.activityName = activityName;
        this.effect = effect;
    }
}