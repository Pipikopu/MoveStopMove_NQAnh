using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShop : Singleton<ShieldShop>
{
    public Player player;
    public List<ShieldShopItem> shieldShopItems;

    public void TryShield(ShieldSkinID shieldSkinID)
    {
        player.GetPlayerSkin().TryShield(shieldSkinID);
    }

    public void ChooseShield()
    {
        player.GetPlayerSkin().ChangeShield();
    }

    public void ResetShield()
    {
        player.GetPlayerSkin().SetItems();
    }

    public void ResetShop()
    {
        for (int i = 0; i < shieldShopItems.Count; i++)
        {
            shieldShopItems[i].OnInit();
        }
    }
}
