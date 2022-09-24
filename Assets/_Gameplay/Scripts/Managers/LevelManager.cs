using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    public int numOfBots;
    private int numOfTotalBots;
    private int numOfBotsDie = 0;

    private Character finalKiller;

    private Constant.GameState gameState;

    public Player player;

    private void Start()
    {
        numOfTotalBots = numOfBots;
    }

    public void DecreaseNumOfBots(int decreaseNum)
    {
        numOfBots -= decreaseNum;
        numOfBotsDie += decreaseNum;
    }

    public int GetRemainNumOfBots()
    {
        return numOfBots;
    }

    public int GetNumOfBotsDie()
    {
        return numOfBotsDie;
    }

    public void Win()
    {
        gameState = Constant.GameState.END;
    }

    public void Lose(Character killer)
    {
        gameState = Constant.GameState.END;
        finalKiller = killer;
    }

    public Constant.GameState GetGameState()
    {
        return gameState;
    }

    public void SetGameState(Constant.GameState newGameState)
    {
        gameState = newGameState;
    }

    public Character GetFinalKiller()
    {
        return finalKiller;
    }

    public void RestartGame()
    {
        numOfBots = numOfTotalBots;
        BotController.Ins.SpawnAllBots();
        player.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        CinemachineManager.Ins.SwitchToStartGameCam();
    }
}
