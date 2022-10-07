using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantShop : Singleton<PantShop>
{
    public Player player;
    public List<PantShopItem> pantShopItems;

    public void TryPant(PantSkinID pantSkinID)
    {
        player.GetPlayerSkin().TryPant(pantSkinID);
    }

    public void ChoosePant()
    {
        player.GetPlayerSkin().ChangePant();
    }

    public void ResetPant()
    {
        player.GetPlayerSkin().SetItems();
    }

    public void ResetShop()
    {
        for (int i = 0; i < pantShopItems.Count; i++)
        {
            pantShopItems[i].OnInit();
        }
    }
}
