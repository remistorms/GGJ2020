using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance;
    public GameState currentGameState;

    [SerializeField] private Player player;

    public bool TryEnterGameState(GameState _newGameState)
    {
        if (_newGameState != currentGameState)
        {
            currentGameState = _newGameState;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StartGame()
    {
        StartCoroutine(_StartGame());
    }

    IEnumerator _StartGame()
    {
        ManagerUI.instance.SwapScren(ScreenType.InGameScreen);
        yield return new WaitForSeconds(0.5f);
        player.m_PlayerMovement.enabled = true;
        player.m_PlayerInteractor.enabled = true;
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

    }

    public Player GetPlayerReference()
    {
        return player;
    }
}

public enum GameState
{
    MainMenu,
    Cinematic,
    GameInProgress,
    GameOver
}
