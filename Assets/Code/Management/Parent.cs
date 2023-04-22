using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parent : MonoBehaviour
{
    public float currentHappinessLevel;
    public float currentEnergyLevel;
    public float currentEmailCompleteness;
    public Email currentEmail;

    public float timeOfDay;

    public int emailsCompleted;

    public static Parent instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("WorkScene"))
        {
            //Handle workday stuff
            if (timeOfDay <= 60000)
            {
                Work();
                timeOfDay += Time.deltaTime;
            }
            else
            {
                timeOfDay = 0;
                GameManager.instance.EndWorkDay();
            }
        }
        else if(scene.name.Equals("HouseScene"))
        {
            //Handle houseday stuff
        }
        else
        {
            //Handle main menu stuff
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
