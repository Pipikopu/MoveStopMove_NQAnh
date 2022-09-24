using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantShop : Singleton<PantShop>
{
    public Player player;

    public void TryPant(PantSkinID pantSkinID)
    {
        player.TryPant(pantSkinID);
    }

    public void ChoosePant()
    {
        player.ChangePant();
    }

    public void ResetPant()
    {
        player.SetItems();
    }
}
