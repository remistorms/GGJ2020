using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPickup : MonoBehaviour
{
    private void OnDestroy()
    {
        ManagerUI.instance.inGameScreen.GetComponent<InGameScreen>().EnableBoltsUI();
        ManagerGame.instance.GetPlayerReference().m_PlayerRepair.enabled = true;
    }
}
