//using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameManager() { }

    public void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);

        Instance = this;
    }

    public GameState State { get; private set; } = GameState.Menu;
    public IManager CurrentProjectManager { get; private set; } = null;

    public void ChangeState(GameState newState){
        manageChangeStateEvents(newState);
        State = newState;
    }

    public void ChangeProject(IManager projectManager)
    {
        CurrentProjectManager = projectManager;
    }

    private void manageChangeStateEvents(GameState newState){
        switch (newState)
        {
            case GameState.Menu:
                Debug.Log("menu");
                break;
            case GameState.Game:
                Debug.Log("game");
                break;
            case GameState.PlanetMenu:
                Debug.Log("menu planet");
                break;
        }
    }
}
