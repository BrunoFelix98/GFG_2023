using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Parent : MonoBehaviour
{
    public float parentHappinessLevel;
    public float parentEnergyLevel;
    public float currentEmailCompleteness;
    public Email currentEmail;
    
    public AudioSource audioSourceTecla;
    public AudioSource audioSourceEmail;
    public AudioSource audioSourceBadEmail;

    public float timeOfDay;

    public int emailsCompleted;

    public static Parent instance;

    public GameObject emailTitle;
    public GameObject emailTxt;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("WorkScene"))
        {
            if (emailTitle == null)
            {
                emailTitle = GameObject.FindGameObjectWithTag("EmailTitle");
                emailTitle.SetActive(false);
            }

            if (emailTxt == null)
            {
                emailTxt = GameObject.FindGameObjectWithTag("EmailText");
            }
        }

        if (parentHappinessLevel >= 100)
        {
            parentHappinessLevel = 100;
        }

        if (parentHappinessLevel <= 0)
        {
            parentHappinessLevel = 0;
        }

        if (parentEnergyLevel >= 100)
        {
            parentEnergyLevel = 100;
        }

        if (parentEnergyLevel <= 0)
        {
            parentEnergyLevel = 0;
        }

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("WorkScene"))
        {
            //Handle workday stuff
            if (timeOfDay <= 60)
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
        if (parentEnergyLevel >= 3)
        {
            if (currentEmailCompleteness <= 99)
            {
                emailTitle.SetActive(true);

                if (Input.anyKeyDown)
                {
                    audioSourceTecla.Play();
                    currentEmailCompleteness += 5;
                    RectTransform emailTxtTransform = emailTxt.GetComponent<RectTransform>();
                    emailTxt.transform.position = new Vector3(emailTxt.transform.position.x + (15.5f / 2), emailTxt.transform.position.y, emailTxt.transform.position.z);
                    emailTxtTransform.sizeDelta = new Vector2(emailTxtTransform.sizeDelta.x + 15.5f, emailTxtTransform.sizeDelta.y);
                }
            }
            else
            {
                MessageEffect(currentEmail.EmailType);
                emailsCompleted++;
                emailTitle.SetActive(false);
                RectTransform emailTxtTransform = emailTxt.GetComponent<RectTransform>();
                emailTxt.transform.position = new Vector3(emailTxt.transform.position.x - 155, emailTxt.transform.position.y, emailTxt.transform.position.z);
                emailTxtTransform.sizeDelta = new Vector2(0, emailTxtTransform.sizeDelta.y);
                GenerateNewEmail();
            }
        }
    }

    //Generate a new email
    public void GenerateNewEmail()
    {

        if (parentEnergyLevel >= 70) //If the parent currently has a lot of energy, they have a 20% chance of recieving a bad email
        {
            int rand = Random.Range(0, 100);

            if (rand <= 19)
            {
                audioSourceBadEmail.Play();
                currentEmail = Manager.instance.emails[0];
            }
            else
            {
                currentEmail = Manager.instance.emails[2];
            }
        }
        else if(parentEnergyLevel <= 40) //If the parent currently doesnt not have a lot of energy, they have a 20% chance of recieving a good email
        {
            int rand = Random.Range(0, 100);

            if (rand <= 19)
            {
                audioSourceEmail.Play();
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
                parentHappinessLevel -= 15; //Decrease happiness
                parentEnergyLevel -= 3; //Decrease energy
                break;
            case 1: //Case good message
                parentHappinessLevel += 5; //Increase happiness
                parentEnergyLevel -= 3; //Decrease energy
                break;
            case 2: //Case neutral message
                parentEnergyLevel -= 3; //Decrease energy
                break;
            default:
                break;
        }
    }
}
