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
            print("Bedroom Chosen");

            print(Manager.instance.rooms[0].Activities[activityNumber].ActivityName);
        }

        if (inLivingRoom)
        {
            print("Living room Chosen");

            print(Manager.instance.rooms[1].Activities[activityNumber].ActivityName);
        }

        if (inPlayingRoom)
        {
            print("Playing room Chosen");
            
            print(Manager.instance.rooms[2].Activities[activityNumber].ActivityName);
        }

        if (inKitchen)
        {
            print("Kitchen Chosen");

            print(Manager.instance.rooms[3].Activities[activityNumber].ActivityName);
        }

        if (inMassageRoom)
        {
            print("Massage room Chosen");

            print(Manager.instance.rooms[4].Activities[activityNumber].ActivityName);
        }
    }

    public void RoomActivity()
    {
        if (inBedroom)
        {
            print("Bedroom Chosen");

            print(Manager.instance.rooms[0].Activities[0].ActivityName);
        }

        if (inLivingRoom)
        {
            print("Living room Chosen");

            for (int i = 0; i < Manager.instance.rooms[1].Activities.Length; i++)
            {
                print(Manager.instance.rooms[1].Activities[i].ActivityName);
            }
        }

        if (inPlayingRoom)
        {
            print("Playing room Chosen");

            for (int i = 0; i < Manager.instance.rooms[2].Activities.Length; i++)
            {
                print(Manager.instance.rooms[2].Activities[i].ActivityName);
            }
        }

        if (inKitchen)
        {
            print("Kitchen Chosen");

            for (int i = 0; i < Manager.instance.rooms[3].Activities.Length; i++)
            {
                print(Manager.instance.rooms[3].Activities[i].ActivityName);
            }
        }

        if (inMassageRoom)
        {
            print("Massage room Chosen");

            print(Manager.instance.rooms[4].Activities[0].ActivityName);
        }
    }
}
