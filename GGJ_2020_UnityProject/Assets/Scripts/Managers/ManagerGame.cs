using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance;
    public GameState currentGameState;

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
}

public enum GameState
{
    MainMenu,
    Cinematic,
    GameInProgress,
    GameOver
}
