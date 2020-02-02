using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    public string textToPopUp;

    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ManagerUI.instance.popUpMessageScreen.ShowPopUpMessage(textToPopUp);
        }
    }
}
