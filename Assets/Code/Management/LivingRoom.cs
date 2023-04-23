using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoom : MonoBehaviour
{
    public RectTransform[] children;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        for (int i = 0; i < children.Length; i++)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(children[i], mousePos))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RoomManager.instance.DoActivity(i);
                    if (i >= 2)
                    {
                        GameManager.instance.EndDay();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RoomManager.instance.places[0].SetActive(false);
            RoomManager.instance.roomsController.SetActive(true);
        }
    }
}
