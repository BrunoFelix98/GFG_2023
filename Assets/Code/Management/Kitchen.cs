using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    public RectTransform[] children;
    public AudioSource audioSourceCozinha;

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
   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSourceCozinha.Play();
            RoomManager.instance.places[1].SetActive(false);
            RoomManager.instance.roomsController.SetActive(true);
        }
    }
}
