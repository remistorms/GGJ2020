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
        m_FadeImage.color = new Color(0,0,0,0);
        m_FadeImage.DOFade(1.0f, fadeTime);
    }

    public void FadeIn(float fadeTime)
    {
        m_FadeImage.color = new Color(0, 0, 0, 1);
        m_FadeImage.DOFade(0.0f, fadeTime);
    }

}
