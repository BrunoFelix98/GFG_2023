using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Child : MonoBehaviour
{
    public float childHappinessLevel;
    public float childEnergyLevel;
    public float childKnowledgeLevel;
    public float childProgressionLevel;

    public float eventTimer;

    public static Child instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (childHappinessLevel >= 100)
        {
            childHappinessLevel = 100;
        }

        if (childHappinessLevel <= 0)
        {
            childHappinessLevel = 0;
        }

        if (childEnergyLevel >= 100)
        {
            childEnergyLevel = 100;
        }

        if (childEnergyLevel <= 0)
        {
            childEnergyLevel = 0;
        }

        if (SceneManager.GetActiveScene().name.Equals("WorkScene"))
        {
            if (eventTimer <= 11)
            {
                eventTimer += Time.deltaTime;
            }
            else
            {
                GenerateRandomEvent();
                eventTimer = 0;
            }
        }
    }

    public void GenerateRandomEvent()
    {
        int rand = 0;

        if (childHappinessLevel >= 70) //If the child is very happy they might be able to generate a playful event
        {
            rand = Random.Range(0, 100);

            if (rand <= 70)
            {
                SendGoodMessage(false);
            }
            else
            {
                SendNeutralMessage();
            }
        }
        
        if (childHappinessLevel <= 30) //If the child is very unhappy they might be able to generate a sad event
        {
            rand = Random.Range(0, 100);

            if (rand <= 70)
            {
                SendBadMessage();
            }
            else
            {
                SendNeutralMessage();
            }
        }

        SendGoodMessage(true);
    }

    public void SendGoodMessage(bool progMsg)
    {
        //Generate UI for this message, when the parent opens the phone, it will give them happiness

        if (progMsg)
        {
            if (childProgressionLevel <= 20)
            {
                //happiness given is +5

                Parent.instance.parentHappinessLevel += 5;
            }
            else if (childProgressionLevel <= 40)
            {
                //happiness given is +8

                Parent.instance.parentHappinessLevel += 8;
            }
            else if (childProgressionLevel <= 60)
            {
                //happiness given is +11

                Parent.instance.parentHappinessLevel += 11;
            }
            else if (childProgressionLevel <= 99)
            {
                //happiness given is +14

                Parent.instance.parentHappinessLevel += 14;
            }
            else
            {
                GameManager.instance.GameEnded();
            }
        }
        else
        {
            //Generate a normal good message
        }

        childHappinessLevel += 10;
        childEnergyLevel--;
    }

    public void SendBadMessage()
    {
        //Generate UI for this message, when the parent opens the phone, it will take away happiness from them
        childHappinessLevel -= 10;
        childEnergyLevel--;
    }

    public void SendNeutralMessage()
    {
        //Generate UI for this message, when the parent opens the phone, it will not affect the parent
        childEnergyLevel--;
    }
}