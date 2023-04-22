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

    public int tempNumber;

<<<<<<< Updated upstream
=======
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

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        tempNumber = 10;
<<<<<<< Updated upstream
        Manager.instance.getValue();
=======
        ChildrenEnergyBar = GameObject.FindGameObjectWithTag("ChildrenEnergyBar").GetComponent<Slider>();
        ChildrenHappinessBar = GameObject.FindGameObjectWithTag("ChildrenHappinessBar").GetComponent<Slider>();
        ChildrenKnowledgeBar = GameObject.FindGameObjectWithTag("ChildrenKnowledgeBar").GetComponent<Slider>();
        ChildrenProgressBar = GameObject.FindGameObjectWithTag("ChildrenProgressBar").GetComponent<Slider>();
        ParentEnergyBar = GameObject.FindGameObjectWithTag("ParentEnergyBar").GetComponent<Slider>();
        ParentHappinessBar = GameObject.FindGameObjectWithTag("ParentHappinessBar").GetComponent<Slider>();

        for (int i = 0; i < places.Length; i++)
        {
            places[i].SetActive(false);
        }
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        tempNumber = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomNumber>().number;
    }

    public void DoActivity(int activityNumber)
    {
        if (inBedroom)
        {
            print(Manager.instance.rooms[0].Activities[activityNumber].ActivityName);

            Child.instance.childEnergyLevel = 100;
            Parent.instance.parentEnergyLevel = 100;

            tempNumber = 10;
        }

        if (inLivingRoom)
        {
            print(Manager.instance.rooms[1].Activities[activityNumber].ActivityName);

            switch (activityNumber)
            {
                case 0: //Watch TV
                    //Increase happiness of both
                    Child.instance.childHappinessLevel += 3;
                    Parent.instance.parentHappinessLevel += 3;

                    //Decrease energy of both
                    Child.instance.childEnergyLevel -= 3;
                    Parent.instance.parentEnergyLevel -= 3;
                    break;
                case 1: //Socializing
                    //Increase happiness of both
                    Child.instance.childHappinessLevel += 3;
                    Parent.instance.parentHappinessLevel += 3;

                    //Decrease energy of both
                    Child.instance.childEnergyLevel -= 3;
                    Parent.instance.parentEnergyLevel -= 3;
                    break;
                case 2: //Rest with kids
                    //Increase happiness of both
                    Child.instance.childHappinessLevel += 3;
                    Parent.instance.parentHappinessLevel += 3;

                    //Increase energy of both
                    Child.instance.childEnergyLevel += 3;
                    Parent.instance.parentEnergyLevel += 3;
                    break;
                case 3: //Resting
                    //Increase happiness of parent
                    Parent.instance.parentHappinessLevel += 3;

                    //Increase energy of parent
                    Parent.instance.parentEnergyLevel += 3;

                    break;
                default: break;
            }

            tempNumber = 10;
        }

        if (inPlayingRoom)
        {

            print(Manager.instance.rooms[2].Activities[activityNumber].ActivityName);

            switch (activityNumber)
            {
                case 0: //Playing with kids
                    //Increase happiness of both
                    Child.instance.childHappinessLevel += 3;
                    Parent.instance.parentHappinessLevel += 3;

                    //Decrease energy of both
                    Child.instance.childEnergyLevel -= 3;
                    Parent.instance.parentEnergyLevel -= 3;

                    break;
                case 1: //Teaching
                    //Increase knowledge of kid
                    Child.instance.childKnowledgeLevel += 3;

                    break;
                default: break;
            }

            tempNumber = 10;
        }

        if (inKitchen)
        {

            print(Manager.instance.rooms[3].Activities[activityNumber].ActivityName);

            switch (activityNumber)
            {
                case 0: //Recycling
                    //Increase knowledge of kid
                    Child.instance.childKnowledgeLevel += 3;

                    //Decrease energy of both
                    Child.instance.childEnergyLevel -= 3;
                    Parent.instance.parentEnergyLevel -= 3;

                    print("Recycling");
                    break;
                case 1: //Cooking
                    //Decrease energy of parent
                    Parent.instance.parentEnergyLevel -= 3;

                    print("Cooking");
                    break;
                case 2: //Cleaning
                    //Increase knowledge of child
                    Child.instance.childKnowledgeLevel += 3;

                    //Decrease energy of both
                    Child.instance.childEnergyLevel -= 3;
                    Parent.instance.parentEnergyLevel -= 3;

                    break;
                default: break;
            }

            tempNumber = 10;
        }

        if (inMassageRoom)
        {
            print(Manager.instance.rooms[4].Activities[activityNumber].ActivityName);

            //Increase happiness of both
            Child.instance.childHappinessLevel += 3;
            Parent.instance.parentHappinessLevel += 3;
            //Increase energy of both
            Child.instance.childEnergyLevel += 3;
            Parent.instance.parentEnergyLevel += 3;

            inMassageRoom = false;
        }
        Manager.instance.getValue();
    }
}