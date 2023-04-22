using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRoom : MonoBehaviour
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
                }
            }
        }
    }
}
