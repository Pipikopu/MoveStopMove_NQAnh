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

    public Transform indicatorsHolder;
    public Indicator indicatorPrefab;

    private string[] names = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "o", "p", "q", "r", "s"};

    private void Awake()
    {
        for (int i = 0; i < numOfBots; i++)
        {
            SimplePool.Preload(botPrefab.gameObject, numOfBots, botsHolder);
            SimplePool.Preload(indicatorPrefab.gameObject, numOfBots, indicatorsHolder);
        }
    }

    private void Start()
    {
        SpawnAllBots();
    }

    public void SpawnAllBots()
    {
        SimplePool.CollectAll();
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
        SimplePool.Despawn(Cache.Ins.GetIndicatorGOFromBotGO(bot));

        int remainNumOfBots = LevelManager.Ins.GetRemainNumOfBots();
        int numActiveBots = SimplePool.GetNumOfActiveObjs(botPrefab.gameObject);

        if (remainNumOfBots >= numOfBots)
        {
            SpawnBot();
        }
        else
        {
            if (numActiveBots < remainNumOfBots)
            {
                for (int i = 0; i < remainNumOfBots - numActiveBots; i++)
                {
                    SpawnBot();
                }
            }
        }
    }

    private void SpawnBot()
    {
        Vector3 randomPos = GetRandomPos();
        Quaternion randomRot = GetRandomRot();

        GameObject botGO = SimplePool.Spawn(botPrefab.gameObject, randomPos, randomRot);
        Character botChar = botGO.GetComponent<CharacterBoundary>().character;

        GameObject indicatorGO = SimplePool.Spawn(indicatorPrefab.gameObject, randomPos, Quaternion.identity);
        Indicator indicator = Cache.Ins.GetIndicatorFromGameObj(indicatorGO);

        indicator.SetOriginCharacter(botChar);

        Cache.Ins.SetBotGOToIndicatorGO(botGO, indicatorGO);

        float botScale = Random.Range(0.9f, 1.1f);
        botGO.transform.localScale = Vector3.one;
        botChar.IncreaseScale(player.GetScale() * botScale);

        if (botScale < 1)
        {
            if (player.GetScore() <= 2)
            {
                botChar.SetScore(1);
            }
            else
            {
                botChar.SetScore(player.GetScore() - Random.Range(1, 2));
            }
        }
        else
        {
            botChar.SetScore(player.GetScore() + Random.Range(1, 2));
        }
        botChar.SetName(names[Random.Range(0, names.Length - 1)]);
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
