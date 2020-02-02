using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PopUpMessageScreen : MonoBehaviour
{
    [SerializeField] private RectTransform popUpRectTransform;
    [SerializeField] private TextMeshProUGUI m_PopUpTextLabel;
    public Animator animator;

    public void ShowPopUpMessage(string message)
    {
        StartCoroutine(_ShowPopUpMessage(message, false));
    }

    public void ShowPopUpMessage(string message, bool disablesPlayerMovement)
    {
        StartCoroutine(_ShowPopUpMessage(message, disablesPlayerMovement));
    }

    IEnumerator _ShowPopUpMessage(string message, bool disablesPlayerMovement)
    {
        m_PopUpTextLabel.text = message;
        animator.SetBool("isShown", true);
        yield return new WaitForSeconds(5.0f);
        HidePopUpMessage();
    }

    public void HidePopUpMessage()
    {
        animator.SetBool("isShown", false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowPopUpMessage("POP UP MESSAGE");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            HidePopUpMessage();
        }
    }
}
