using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public bool inBedroom;
    public bool inLivingRoom;
    public bool inPlayingRoom;
    public bool inKitchen;
    public bool inMassageRoom;

    public GameObject roomsController;

    public AudioSource audioSourceCozinha;
    public AudioSource audioSourceTv;
    public AudioSource audioSourceSleeping;
    public AudioSource audioSourceMassage;


    [SerializeField]
    private Slider ChildrenEnergyBar;
    [SerializeField]
    private Slider ChildrenHappinessBar;
    [SerializeField]
    private Slider ChildrenKnowledgeBar;
    [SerializeField]
    private Slider ChildrenProgressBar;
    [SerializeField]
    private Slider ParentEnergyBar;
    [SerializeField]
    private Slider ParentHappinessBar;

    public static RoomManager instance;

    public GameObject[] places;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChildrenEnergyBar = GameObject.FindGameObjectWithTag("ChildrenEnergyBar").GetComponent<Slider>();
        ChildrenHappinessBar = GameObject.FindGameObjectWithTag("ChildrenHappinessBar").GetComponent<Slider>();
        ChildrenKnowledgeBar = GameObject.FindGameObjectWithTag("ChildrenKnowledgeBar").GetComponent<Slider>();
        ChildrenProgressBar = GameObject.FindGameObjectWithTag("ChildrenProgressBar").GetComponent<Slider>();
        ParentEnergyBar = GameObject.FindGameObjectWithTag("ParentEnergyBar").GetComponent<Slider>();
        ParentHappinessBar = GameObject.FindGameObjectWithTag("ParentHappinessBar").GetComponent<Slider>();

        roomsController = GameObject.FindGameObjectWithTag("RoomsController");

        for (int i = 0; i < places.Length; i++)
        {
            places[i].SetActive(false);
        }
        audioSourceTv = Manager.instance.gameObject.transform.GetChild(4).GetComponent<AudioSource>();
    }

    public void DoActivity(int activityNumber)
    {
        if (inBedroom)
        {
            audioSourceSleeping.Play();
            
            print(Manager.instance.rooms[0].Activities[activityNumber].ActivityName);

            Child.instance.childEnergyLevel = 100;
            Parent.instance.parentEnergyLevel = 100;

            Manager.instance.UpdateValues();
        }

        if (inLivingRoom)
        {   

            print(Manager.instance.rooms[1].Activities[activityNumber].ActivityName);

            switch (activityNumber)
            {
                case 0: //Watch TV
                    if(Parent.instance.parentEnergyLevel >= 15 && Child.instance.childEnergyLevel >= 15)
                    {  
                        audioSourceTv.Play();

                        // Increase happiness of both
                        Child.instance.childHappinessLevel += 3;
                        Parent.instance.parentHappinessLevel += 3;

                        //Decrease energy of both
                        Child.instance.childEnergyLevel -= 15;
                        Parent.instance.parentEnergyLevel -= 15;

                        Manager.instance.UpdateValues();
                    }
                    break;
                case 1: //Socializing
                    if(Parent.instance.parentEnergyLevel >= 15 && Child.instance.childEnergyLevel >= 15)
                    {
                        //Increase happiness of both
                        Child.instance.childHappinessLevel += 3;
                        Parent.instance.parentHappinessLevel += 3;

                        //Decrease energy of both
                        Child.instance.childEnergyLevel -= 15;
                        Parent.instance.parentEnergyLevel -= 15;

                        Manager.instance.UpdateValues();
                    }
                    break;
                case 2: //Rest with kids
                    //Increase happiness of both
                    Child.instance.childHappinessLevel += 5;
                    Parent.instance.parentHappinessLevel += 5;

                    //Increase energy of both
                    Child.instance.childEnergyLevel = 80;
                    Parent.instance.parentEnergyLevel = 100;

                    Manager.instance.UpdateValues();
                    GameManager.instance.EndDay();
                    break;
                case 3: //Resting
                    //Increase happiness of parent
                    Parent.instance.parentHappinessLevel += 3;

                    //Increase energy of parent
                    Parent.instance.parentEnergyLevel = 100;

                    Manager.instance.UpdateValues();
                    GameManager.instance.EndDay();
                    break;
                default: break;
            }
        }

        if (inPlayingRoom)
        {
            print(Manager.instance.rooms[2].Activities[activityNumber].ActivityName);

            switch (activityNumber)
            {
                case 0: //Playing with kids
                    if(Parent.instance.parentEnergyLevel >= 15 && Child.instance.childEnergyLevel >= 15)
                    { 
                        audioSourceTv.Play();
                        
                        //Increase happiness of both
                        Child.instance.childHappinessLevel += 3;
                        Parent.instance.parentHappinessLevel += 3;

                        //Decrease energy of both
                        Child.instance.childEnergyLevel -= 15;
                        Parent.instance.parentEnergyLevel -= 15;

                        Manager.instance.UpdateValues();
                    }
                    break;
                case 1: //Teaching
                    if(Parent.instance.parentEnergyLevel >= 15 && Child.instance.childEnergyLevel >= 15)
                    {
                        //Increase knowledge of kid
                        Child.instance.childKnowledgeLevel += 3;
                        //Decrease energy of both
                        Parent.instance.parentEnergyLevel -= 15;
                        Child.instance.childEnergyLevel -= 15;

                        Manager.instance.UpdateValues();
                    }

                    break;
                default: break;
            }
        }

        if (inKitchen)
        {
            audioSourceCozinha.Play();

            print(Manager.instance.rooms[3].Activities[activityNumber].ActivityName);

            switch (activityNumber)
            {
                case 0: //Recycling
                    if(Parent.instance.parentEnergyLevel >= 15 && Child.instance.childEnergyLevel >= 15)
                    {
                        //Increase knowledge of kid
                        Child.instance.childKnowledgeLevel += 3;

                        //Decrease energy of both
                        Child.instance.childEnergyLevel -= 15;
                        Parent.instance.parentEnergyLevel -= 15;

                        Manager.instance.UpdateValues();
                    }
                    break;
                case 1: //Cooking
                    if(Parent.instance.parentEnergyLevel >= 15)
                    {
                        //Decrease energy of parent
                        Parent.instance.parentEnergyLevel -= 15;
                        //Increase child happiness
                        Child.instance.childHappinessLevel += 5;

                        Manager.instance.UpdateValues();
                    }
                    break;
                case 2: //Cleaning
                    if(Parent.instance.parentEnergyLevel >= 15 && Child.instance.childEnergyLevel >= 15)
                    {
                        //Increase knowledge of child
                        Child.instance.childKnowledgeLevel += 3;

                        //Decrease energy of both
                        Child.instance.childEnergyLevel -= 15;
                        Parent.instance.parentEnergyLevel -= 15;

                        Manager.instance.UpdateValues();
                    }
                    break;
                default: break;
            }
        }

        if (inMassageRoom)
        {
            audioSourceMassage.Play();
            print(Manager.instance.rooms[4].Activities[activityNumber].ActivityName);

            //Increase happiness of parent
            Parent.instance.parentHappinessLevel += 3;
            //Increase energy of parent
            Parent.instance.parentEnergyLevel += 20;

            Manager.instance.UpdateValues();
        }
    }
}