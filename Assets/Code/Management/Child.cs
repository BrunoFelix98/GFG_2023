using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Child : MonoBehaviour
{
    public float childHappinessLevel;
    public float childEnergyLevel;
    public float childKnowledgeLevel;
    public float childProgressionLevel;

    public float eventTimer;

    public static Child instance;

    public Sprite msgIMG;
    public string msgTitle;
    public string msgDesc;

    public AudioSource phoneSourceNotif;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        phoneSourceNotif = Manager.instance.gameObject.transform.GetChild(5).GetComponent<AudioSource>();
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
                Manager.instance.canTakePhone = true;
                eventTimer = 0;
            }
        }
    }

    public void GenerateRandomEvent()
    {
        phoneSourceNotif.Play();

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
        }else if (childHappinessLevel <= 30) //If the child is very unhappy they might be able to generate a sad event
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
        else
        {
            SendNeutralMessage();
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
            msgIMG = Manager.instance.messages[3].MsgImage;
            msgTitle = Manager.instance.messages[3].Title;
            msgDesc = Manager.instance.messages[3].Description;
        }

        childHappinessLevel += 10;
        childEnergyLevel--;
    }

    public void SendBadMessage()
    {
        int rand = 0;
        rand = Random.Range(0, 100);

        if (rand <= 50)
        {
            msgIMG = Manager.instance.messages[2].MsgImage;
            msgTitle = Manager.instance.messages[2].Title;
            msgDesc = Manager.instance.messages[2].Description;
        }
        else
        {
            msgIMG = Manager.instance.messages[4].MsgImage;
            msgTitle = Manager.instance.messages[4].Title;
            msgDesc = Manager.instance.messages[4].Description;
        }
        //Generate UI for this message, when the parent opens the phone, it will take away happiness from them
        childHappinessLevel -= 10;
        childEnergyLevel--;
    }

    public void SendNeutralMessage()
    {
        int rand = 0;
        rand = Random.Range(0, 100);

        if (rand <= 50)
        {
            msgIMG = Manager.instance.messages[0].MsgImage;
            msgTitle = Manager.instance.messages[0].Title;
            msgDesc = Manager.instance.messages[0].Description;
        }
        else
        {
            msgIMG = Manager.instance.messages[1].MsgImage;
            msgTitle = Manager.instance.messages[1].Title;
            msgDesc = Manager.instance.messages[1].Description;
        }
        //Generate UI for this message, when the parent opens the phone, it will not affect the parent
        childEnergyLevel--;
    }
}