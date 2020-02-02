using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManagerEvents : MonoBehaviour
{
    public static ManagerEvents instance;

    //GameState Events
    public event Action<GameState> Evt_GameStateEnter = delegate { };
    public void Fire_Evt_GameStateEnter(GameState _gameState)
    {
        Debug.Log("Entering " + _gameState);
        Evt_GameStateEnter(_gameState);
    }

    public event Action<GameState> Evt_GameStateExit = delegate { };
    public void Fire_Evt_GameStateExit(GameState _gameState)
    {
        Debug.Log("Exiting " + _gameState);
        Evt_GameStateExit(_gameState);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
