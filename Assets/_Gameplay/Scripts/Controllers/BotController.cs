using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : Singleton<BotController>
{
    [Header("PlayerInfor")]
    public Player player;

    [Header("BotSpawner")]
    public int numOfBots;
    public Transform botsHolder;
    public CharacterBoundary botPrefab;

    public float reviveTime;

    public float xRange;
    public float zRange;

    public Dictionary<CharacterBoundary, Character> boundToChar = new Dictionary<CharacterBoundary, Character>();

    private void Awake()
    {
        for (int i = 0; i < numOfBots; i++)
        {
            SimplePool.Preload(botPrefab.gameObject, numOfBots, botsHolder);
        }
    }

    private void Start()
    {
        SpawnAllBots();
    }

    private void SpawnAllBots()
    {
        for (int i = 0; i < numOfBots; i++)
        {
            SpawnBot();
        }
    }

    public void ClearBot()
    {
        LevelManager.Ins.DecreaseNumOfBots(1);
    }

    public void ReuseBot(GameObject bot)
    {
        SimplePool.Despawn(bot);
        int remainNumOfBots = LevelManager.Ins.GetRemainNumOfBots();

        if (remainNumOfBots >= numOfBots)
        {
            SpawnBot();
        }
    }

    private void SpawnBot()
    {
        Vector3 randomPos = GetRandomPos();
        Quaternion randomRot = GetRandomRot();

        GameObject botGO = SimplePool.Spawn(botPrefab.gameObject, randomPos, randomRot);
        Character botChar = botGO.GetComponent<CharacterBoundary>().character;
        botGO.transform.localScale = Vector3.one;
        botChar.IncreaseScale(player.GetScale() * Random.Range(0.8f, 1.1f));
    }

    private Vector3 GetRandomPos()
    {
        // 0 is TOP, 1 is BOT, 2 is LEFT, 3 is RIGHT
        float randomX = 0;
        float randomZ = 0;

        int randomPos = Random.Range(0, 3);
        switch (randomPos)
        {
            case 0:
                randomX = xRange;
                randomZ = Random.Range(-zRange, zRange);
                break;
            case 1:
                randomX = -xRange;
                randomZ = Random.Range(-zRange, zRange);
                break;
            case 2:
                randomZ = -zRange;
                randomX = Random.Range(-xRange, xRange);
                break;
            case 3:
                randomZ = zRange;
                randomX = Random.Range(-xRange, xRange);
                break;

            default:
                break;
        }

        return new Vector3(randomX, 0, randomZ);
    }

    private Quaternion GetRandomRot()
    {
        return Quaternion.Euler(0, 60, 0);
    }
}
