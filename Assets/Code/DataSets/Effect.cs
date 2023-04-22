using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
    [SerializeField]
    private int effectID;
    [SerializeField]
    private string effectName;
    [SerializeField]
    private float effectLevel;

    public int EffectID
    {
        get => effectID;
        set => effectID = value;
    }

    public string EffectName
    {
        get => effectName;
        set => effectName = value;
    }

    public float EffectLevel
    {
        get => effectLevel;
        set => effectLevel = value;
    }

    public Effect(int effectID, string effectName, float effectLevel)
    {
        EffectID = effectID;
        EffectName = effectName;
        EffectLevel = effectLevel;
    }
}