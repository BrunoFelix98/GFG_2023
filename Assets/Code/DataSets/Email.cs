using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Email
{
    [SerializeField]
    private int emailType; //0 = bad, 1 = good, 2 = neutral
    public int EmailType
    {
        get => emailType;
        set => emailType = value;
    }

    public Email(int emailType)
    {
        EmailType = emailType;
    }
}
