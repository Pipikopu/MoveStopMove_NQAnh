using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : Singleton<BotController>
{
    [Header("BotSpawner")]
    public int numOfBots;
    public Transform botsHolder;
    public CharacterBoundary botPrefab;
    public float nearestBotRange;
    public float farestBotRange;

    public float reviveTime;

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
        SimplePool.Spawn(botPrefab.gameObject, randomPos, randomRot);
    }

    private Vector3 GetRandomPos()
    {
        float randomYDegrees = Random.Range(0, Mathf.PI * 2);
        float randomX = Mathf.Sin(randomYDegrees) * Random.Range(nearestBotRange, farestBotRange);
        float randomZ = Mathf.Cos(randomYDegrees) * Random.Range(nearestBotRange, farestBotRange);

        return new Vector3(randomX, 0, randomZ);
    }

    private Quaternion GetRandomRot()
    {
        return Quaternion.Euler(0, 60, 0);
    }
}
