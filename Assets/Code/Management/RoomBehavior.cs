using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomBehavior : MonoBehaviour
{
    public GameObject label;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        if (RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), mousePos))
        {
            switch (gameObject.tag)
            {
                case "LivingRoom":
                    label.transform.position = gameObject.transform.position;
                    label.GetComponent<TextMeshProUGUI>().text = "Living room";
                    break;
                case "Kitchen":
                    label.transform.position = gameObject.transform.position;
                    label.GetComponent<TextMeshProUGUI>().text = "Kitchen";
                    break;
                case "Bedroom":
                    label.transform.position = gameObject.transform.position;
                    label.GetComponent<TextMeshProUGUI>().text = "Bedroom";
                    break;
                case "PlayRoom":
                    label.transform.position = gameObject.transform.position;
                    label.GetComponent<TextMeshProUGUI>().text = "Play room";
                    break;
                case "MassageRoom":
                    label.transform.position = gameObject.transform.position;
                    label.GetComponent<TextMeshProUGUI>().text = "Massage room";
                    break;
                default:
                    break;
            }

            if (Input.GetMouseButtonDown(0))
            {
                switch (gameObject.tag)
                {
                    case "LivingRoom":
                        RoomManager.instance.inLivingRoom = true;
                        RoomManager.instance.places[0].SetActive(true);
                        GameObject.FindWithTag("RoomsController").SetActive(false);
                        break;
                    case "Kitchen":
                        RoomManager.instance.inKitchen = true;
                        RoomManager.instance.places[1].SetActive(true);
                        GameObject.FindWithTag("RoomsController").SetActive(false);
                        break;
                    case "Bedroom":
                        RoomManager.instance.inBedroom = true;
                        RoomManager.instance.places[2].SetActive(true);
                        GameObject.FindWithTag("RoomsController").SetActive(false);
                        break;
                    case "PlayRoom":
                        RoomManager.instance.inPlayingRoom = true;
                        RoomManager.instance.places[3].SetActive(true);
                        GameObject.FindWithTag("RoomsController").SetActive(false);
                        break;
                    case "MassageRoom":
                        RoomManager.instance.inMassageRoom = true;
                        RoomManager.instance.places[4].SetActive(true);
                        GameObject.FindWithTag("RoomsController").SetActive(false);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
