using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ManagerUI.instance.popUpMessageScreen.ShowPopUpMessage("Weapon Acquired: Shoot bolts with Y / Keyboard F");
            ManagerGame.instance.GetPlayerReference().m_PlayerWeapon.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
