using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    public string textToPopUp;
    public int timesToDisplay;

    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timesToDisplay > 0)
        {
            if (other.tag == "Player")
            {
                ManagerUI.instance.popUpMessageScreen.ShowPopUpMessage(textToPopUp);
                timesToDisplay--;
            }
        }
       
    }
}
