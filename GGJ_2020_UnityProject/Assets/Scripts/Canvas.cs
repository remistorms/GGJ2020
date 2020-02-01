using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField] private Text boltsTextLabel;
    [SerializeField] private IntVariable playerBolts;

    private void Update()
    {
        boltsTextLabel.text = playerBolts.Value.ToString();
    }
}
