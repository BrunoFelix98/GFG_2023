using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public bool inBedroom;
    public bool inLivingRoom;
    public bool inPlayingRoom;
    public bool inKitchen;
    public bool inMassageRoom;

    public int tempNumber;

    // Start is called before the first frame update
    void Start()
    {
        tempNumber = 10;
    }

    // Update is called once per frame
    void Update()
    {
        RoomActivity();

        tempNumber = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomNumber>().number;

        DoActivity(tempNumber);
    }

    public void DoActivity(int activityNumber)
    {
        if (inBedroom)
        {
            print(Manager.instance.rooms[0].Activities[activityNumber].ActivityName);

            Child.instance.childEnergyLevel = 100;
            Parent.instance.parentEnergyLevel = 100;

            inBedroom = false;
        }

        if (inLivingRoom)
        {
            print(Manager.instance.rooms[1].Activities[activityNumber].ActivityName);

            switch (activityNumber) {
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

            inLivingRoom = false;
        }

        if (inPlayingRoom)
        {
            
            print(Manager.instance.rooms[2].Activities[activityNumber].ActivityName);

            switch(activityNumber)
            {
                case 1: //Playing with kids
                    //Increase happiness of both
                    Child.instance.childHappinessLevel += 3;
                    Parent.instance.parentHappinessLevel += 3;

                    //Decrease energy of both
                    Child.instance.childEnergyLevel -= 3;
                    Parent.instance.parentEnergyLevel -= 3;

                    break;
                case 2: //Teaching
                    //Increase knowledge of kid
                    Child.instance.childKnowledgeLevel += 3;

                    break;
                default : break;
            }

            inPlayingRoom = false;
        }

        if (inKitchen)
        {

            print(Manager.instance.rooms[3].Activities[activityNumber].ActivityName);

            switch(activityNumber)
            {
                case 1: //Recycling
                    //Increase knowledge of kid
                    Child.instance.childKnowledgeLevel += 3;

                    //Decrease energy of both
                    Child.instance.childEnergyLevel -= 3;
                    Parent.instance.parentEnergyLevel -= 3;

                    print("Recycling");
                    break;
                case 2: //Cooking
                    //Decrease energy of parent
                    Parent.instance.parentEnergyLevel -= 3;

                    print("Cooking");
                    break;
                case 3: //Cleaning
                    //Increase knowledge of child
                    Child.instance.childKnowledgeLevel += 3;

                    //Decrease energy of both
                    Child.instance.childEnergyLevel -= 3;
                    Parent.instance.parentEnergyLevel -= 3;

                    break;
                default: break;
            }

            inKitchen = false;
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
    }

    public void RoomActivity()
    {
        if (inBedroom)
        {
            print("Bedroom Chosen");

            //print(Manager.instance.rooms[0].Activities[0].ActivityName);
        }

        if (inLivingRoom)
        {
            print("Living room Chosen");

            //for (int i = 0; i < Manager.instance.rooms[1].Activities.Length; i++)
            //{
            //    print(Manager.instance.rooms[1].Activities[i].ActivityName);
            //}
        }

        if (inPlayingRoom)
        {
            print("Playing room Chosen");

            //for (int i = 0; i < Manager.instance.rooms[2].Activities.Length; i++)
            //{
            //    print(Manager.instance.rooms[2].Activities[i].ActivityName);
            //}
        }

        if (inKitchen)
        {
            print("Kitchen Chosen");

            //for (int i = 0; i < Manager.instance.rooms[3].Activities.Length; i++)
            //{
            //    print(Manager.instance.rooms[3].Activities[i].ActivityName);
            //}
        }

        if (inMassageRoom)
        {
            print("Massage room Chosen");

            //print(Manager.instance.rooms[4].Activities[0].ActivityName);
        }
    }
}
