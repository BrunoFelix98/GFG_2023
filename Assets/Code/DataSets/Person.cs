using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Person
{
    [SerializeField]
    private int personID;
    [SerializeField]
    private Effect[] effects;

    public int PersonID
    {
        get => personID;
        set => personID = value;
    }

    public Effect[] Effects
    {
        get => effects;
        set => effects = value;
    }

    public Person(int personID, Effect[] effects)
    {
        PersonID = personID;
        Effects = effects;
    }
}