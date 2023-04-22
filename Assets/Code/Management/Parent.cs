using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    public float currentHappinessLevel;
    public float currentEnergyLevel;
    public float currentEmailCompleteness;
    public Email currentEmail;

    public int emailsCompleted;
    public int maximumNumberOfEmailsPerDay;

    // Start is called before the first frame update
    void Start()
    {
        currentHappinessLevel = Manager.instance.people[1].Effects[0].EffectLevel;
        currentEnergyLevel = Manager.instance.people[1].Effects[1].EffectLevel;

        GenerateNewEmail();
    }

    void Update()
    {
        if (emailsCompleted < maximumNumberOfEmailsPerDay)
        {
            Work();
        }
    }

    public void Work()
    {
        if (currentEmailCompleteness <= 99)
        {
            if (Input.anyKeyDown)
            {
                currentEmailCompleteness += 5;
            }
        }
        else
        {
            MessageEffect(currentEmail.EmailType);
            emailsCompleted++;
            GenerateNewEmail();
        }
    }

    //Generate a new email
    public void GenerateNewEmail()
    {
        if (currentEnergyLevel >= 70) //If the parent currently has a lot of energy, they have a 20% chance of recieving a bad email
        {
            int rand = Random.Range(0, 100);

            if (rand <= 19)
            {
                currentEmail = Manager.instance.emails[0];
            }
            else
            {
                currentEmail = Manager.instance.emails[2];
            }
        }
        else if(currentEnergyLevel <= 40) //If the parent currently doesnt not have a lot of energy, they have a 20% chance of recieving a good email
        {
            int rand = Random.Range(0, 100);

            if (rand <= 19)
            {
                currentEmail = Manager.instance.emails[1];
            }
            else
            {
                currentEmail = Manager.instance.emails[2];
            }
        }
        else //If their energy is around average, they recieve a neutral email
        {
            currentEmail = Manager.instance.emails[2];
        }

        currentEmailCompleteness = 0;
    }

    //Effects of messages in the workplace for the parent
    public void MessageEffect(int messageType)
    {
        switch (messageType)
        {
            case 0: //Case bad message
                currentHappinessLevel -= 5; //Decrease happiness
                currentEnergyLevel -= 5; //Decrease energy
                break;
            case 1: //Case good message
                currentHappinessLevel += 5; //Increase happiness
                currentEnergyLevel -= 5; //Decrease energy
                break;
            case 2: //Case neutral message
                currentEnergyLevel -= 5; //Decrease energy
                break;
            default:
                break;
        }
    }
}
