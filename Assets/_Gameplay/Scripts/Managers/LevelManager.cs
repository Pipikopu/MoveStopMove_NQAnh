using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public Transform planeHolder;
    public List<LevelData> levelDatas;
    private GameObject gamePlane;

    private int numOfBots;
    private int numOfTotalBots;
    private int numOfBotsDie = 0;

    private int level;

    private Character finalKiller;

    private Constant.GameState gameState;

    public Player player;

    private void Start()
    {
        level = PlayerPrefs.GetInt("CurrentLevel", 0);
        if (level >= levelDatas.Count)
        {
            level = 0;
            PlayerPrefs.SetInt("CurrentLevel", 0);
        }
        gamePlane = Instantiate(levelDatas[level].gamePlane, planeHolder);

        numOfTotalBots = levelDatas[level].numOfBots;

        numOfBots = numOfTotalBots;
        numOfBotsDie = 0;
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

    public void StartGame(int level)
    {
        PlayerPrefs.SetInt("CurrentLevel", level);
        SimplePool.ReleaseAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
