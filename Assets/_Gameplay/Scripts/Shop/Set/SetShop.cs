using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShop : Singleton<SetShop>
{
    public Player player;

    public void TrySet(SetSkinID setSkinID)
    {
        Set set = DataManager.Ins.GetSet(setSkinID);
        player.TryPant(set.pantSkinID);
        player.TryBody(set.bodyMatID);
        player.TryHat(set.hatSkinID);
        player.TryTail(set.tailSkinID);
        player.TryWing(set.wingSkinID);
    }

    public void ChooseSet()
    {
        player.ChangePant();
        player.ChangeBody();
        player.ChangeHat();
        player.ChangeTail();
        player.ChangeWing();
    }

    public void ResetSet()
    {
        player.SetItems();
    }
}
