using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPickup : MonoBehaviour
{
    private void OnDestroy()
    {
        ManagerUI.instance.inGameScreen.GetComponent<InGameScreen>().EnableBoltsUI();
        ManagerGame.instance.GetPlayerReference().m_PlayerRepair.enabled = true;
        ManagerUI.instance.popUpMessageScreen.ShowPopUpMessage("You need bolts to repair things, use them wisely");
    }
}
