using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatShop : Singleton<HatShop>
{
    public Player player;
    public List<HatShopItem> hatShopItems;

    public void TryHat(HatSkinID hatSkinID)
    {
        player.GetPlayerSkin().TryHat(hatSkinID);
    }

    public void ChooseHat()
    {
        player.GetPlayerSkin().ChangeHat();
    }

    public void ResetHat()
    {
        player.GetPlayerSkin().SetItems();
    }

    public void ResetShop()
    {
        for (int i = 0; i < hatShopItems.Count; i++)
        {
            hatShopItems[i].OnInit();
        }
    }
}
