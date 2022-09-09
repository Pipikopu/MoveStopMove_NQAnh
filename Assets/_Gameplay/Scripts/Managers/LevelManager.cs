using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    public int numOfBots;
    private int numOfBotsDie = 0;

    private Constant.GameState gameState;

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

    public void Lose()
    {
        gameState = Constant.GameState.END;
    }

    public Constant.GameState GetGameState()
    {
        return gameState;
    }

    public void SetGameState(Constant.GameState newGameState)
    {
        gameState = newGameState;
    }
}
