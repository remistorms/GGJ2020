using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI instance;
    //GAME SCREENS
    [Header("Game Screens")]
    public GameObject mainMenuScreen;
    public GameObject storyScreen;
    public GameObject gameOverScreen;
    public GameObject creditsScreen;
    public GameObject inGameScreen;
    //HELPER SCREENS
    [Header("Helper Screens")]
    public FaderScreen faderScreen;
    public PopUpMessageScreen popUpMessageScreen;

    private ScreenType currentScreenType;

    public void SwapScren(ScreenType screenType)
    {
        faderScreen.FadeIn( 0.5f);

        DisableAllScreens();
        
        switch (screenType)
        {
            case ScreenType.None:
                break;
            case ScreenType.MainMenu:
                mainMenuScreen.SetActive(true);
                break;
            case ScreenType.StoryScreen:
                storyScreen.SetActive(true);
                break;
            case ScreenType.GameOverScreen:
                gameOverScreen.SetActive(true);
                break;
            case ScreenType.CreditsScreen:
                creditsScreen.SetActive(true);
                break;

            case ScreenType.InGameScreen:
                inGameScreen.SetActive(true);
                break;
            default:
                break;
        }

    }

    private void DisableAllScreens()
    {
        storyScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        creditsScreen.SetActive(false);
        inGameScreen.SetActive(false);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        CenterAllScreens();
        DisableAllScreens();
        faderScreen.enabled = true;

        SwapScren(ScreenType.MainMenu);
    }

    public void CenterAllScreens()
    {
        mainMenuScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        mainMenuScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        storyScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        storyScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        creditsScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        creditsScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        gameOverScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        gameOverScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        faderScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        faderScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        popUpMessageScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        popUpMessageScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        inGameScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        inGameScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Switch to Main menu");
            SwapScren(ScreenType.MainMenu);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Switch to Story menu");
            SwapScren(ScreenType.StoryScreen);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Switch to Game Over Screen");
            SwapScren(ScreenType.GameOverScreen);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Switch to Game Over Screen");
            SwapScren(ScreenType.InGameScreen);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Switch to Game Over Screen");
            SwapScren(ScreenType.CreditsScreen);
        }
    }

    public void OpenCreditsScreen()
    {
        SwapScren(ScreenType.CreditsScreen);
    }

    public void ReturnToMenuScreen()
    {
        SwapScren(ScreenType.MainMenu);
    }

    public void StartStory()
    {
        SwapScren(ScreenType.StoryScreen);
    }

}

public enum ScreenType
{
    None,
    MainMenu,
    StoryScreen,
    InGameScreen,
    GameOverScreen,
    CreditsScreen
}
