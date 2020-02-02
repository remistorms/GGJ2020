using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIScreen : MonoBehaviour
{
    public ScreenType screenType;
}

public enum ScreenType
{
    MainMenu,
    OptionsScreen,
    CreditsScreen,
    InGameScreen,
    GameOverScreen
}
