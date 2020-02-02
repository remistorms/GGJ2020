using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class InGameScreen : MonoBehaviour
{
    public CanvasGroup boltsPanelCanvasGroup;
    public IntVariable playerBolts;
    public TextMeshProUGUI boltsTextLabel;

    public void EnableBoltsUI()
    {
        boltsPanelCanvasGroup.DOFade(1.0f, 0.5f);
    }

    public void Update()
    {
        boltsTextLabel.text = playerBolts.Value.ToString();
    }
}
