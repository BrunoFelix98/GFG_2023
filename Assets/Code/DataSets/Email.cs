using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Email
{
    [SerializeField]
    private int emailType; //0 = bad, 1 = good, 2 = neutral
    [SerializeField]
    private float emailCompleteness;
    public int EmailType
    {
        get => emailType;
        set => emailType = value;
    }

    public float EmailCompleteness
    {
        get => emailCompleteness;
        set => emailCompleteness = value;
    }

    public Email(int emailType, float emailCompleteness)
    {
        EmailType = emailType;
        EmailCompleteness = emailCompleteness;
    }
}
