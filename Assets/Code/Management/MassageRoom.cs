using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassageRoom : MonoBehaviour
{
    public RectTransform[] children;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        if (RectTransformUtility.RectangleContainsScreenPoint(children[0], mousePos))
        {
            if (Input.GetMouseButtonDown(0))
            {
                RoomManager.instance.DoActivity(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RoomManager.instance.places[4].SetActive(false);
            RoomManager.instance.roomsController.SetActive(true);
        }
    }
}
