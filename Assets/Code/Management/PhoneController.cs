using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PhoneController : MonoBehaviour

{
    [SerializeField]
    private GameObject phone;

    // Start is called before the first frame update
    void Start()
    {
        phone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void active()
    {
        if(Manager.instance.canTakePhone == true)
        {
            phone.SetActive(true);
            GameObject.FindGameObjectWithTag("MessageIMG").GetComponent<Image>().sprite = Child.instance.msgIMG;
            GameObject.FindGameObjectWithTag("MessageTitle").GetComponent<TextMeshProUGUI>().text = Child.instance.msgTitle;
            GameObject.FindGameObjectWithTag("MessageDesc").GetComponent<TextMeshProUGUI>().text = Child.instance.msgDesc;
        }
    }

    public void unactive()
    {
        phone.SetActive(false);
        Manager.instance.canTakePhone = false;
    }
}
