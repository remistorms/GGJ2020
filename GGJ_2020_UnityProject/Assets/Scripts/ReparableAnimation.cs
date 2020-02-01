using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReparableAnimation : MonoBehaviour
{
    private Reparable reparable;
    public MeshRenderer meshRenderer;
    public Color brokenColor;
    public Color repairedColor;
    public Image fillImage;
    public Text textLabel;

    private void Awake()
    {
        reparable = GetComponent<Reparable>();
        meshRenderer.material.color = brokenColor;
    }

    private void Update()
    {
        fillImage.fillAmount = reparable.repairPercentage;
        textLabel.text = reparable.boltsNeededToRepair.ToString();
        meshRenderer.material.color = Color.Lerp(brokenColor, repairedColor, reparable.repairPercentage );   
    }
}
