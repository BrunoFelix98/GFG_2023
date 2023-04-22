using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Child : MonoBehaviour
{
    public float childHappinessLevel;
    public float childEnergyLevel;
    public float childKnowledgeLevel;
    public float childMannersLevel;
    public float childProgressionLevel;

    public float eventTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name.Equals("WorkScene"))
        {
            if (eventTimer <= 60000)
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

        if (childProgressionLevel <= 20)
        {
            //Progression messages are always good, the amount of progression just dictates how much happiness the parent gets

            SendGoodMessage(true);
        }
    }

    public void SendGoodMessage(bool progMsg)
    {
        //Generate UI for this message, when the parent opens the phone, it will give them happiness

        if (progMsg)
        {
            if (childProgressionLevel <= 20)
            {
                //happiness given is +5
            }
            else if (childProgressionLevel <= 40)
            {
                //happiness given is +8
            }
            else if (childProgressionLevel <= 60)
            {
                //happiness given is +11
            }
            else if (childProgressionLevel <= 99)
            {
                //happiness given is +14
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
    }

    public void SendBadMessage()
    {
        //Generate UI for this message, when the parent opens the phone, it will take away happiness from them
    }

    public void SendNeutralMessage()
    {
        //Generate UI for this message, when the parent opens the phone, it will not affect the parent
    }
}
