using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataController : Singleton<PlayerDataController>
{
    private void Awake()
    {
        SaveToJson(LoadFromJson());
    }

    public void SaveToJson(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/_Gameplay/JSonFiles/saveFile.json", json);
    }

    public PlayerData LoadFromJson()
    {
        if (File.Exists(Application.dataPath + "/_Gameplay/JSonFiles/saveFile.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/_Gameplay/JSonFiles/saveFile.json");
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            return data;
        }
        else
        {
            PlayerData data = new PlayerData
            {
                name = "Player",
                level = 1,
                setID = 0,
                pantID = 0,
                hatID = 0,
                weaponID = 0,
                shieldID = 0,
                coins = 0
            };

            return data;
        }
    }

}
