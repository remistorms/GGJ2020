using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FaderScreen : MonoBehaviour
{
    [SerializeField] private Image m_FadeImage;

    public void FadeOut(float fadeTime)
    {
        m_FadeImage.DOFade(1.0f, fadeTime);
    }

    public void FadeIn(float fadeTime)
    {
        m_FadeImage.DOFade(0.0f, fadeTime);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            FadeIn(0.5f);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            FadeOut(0.5f);
        }
    }
}
