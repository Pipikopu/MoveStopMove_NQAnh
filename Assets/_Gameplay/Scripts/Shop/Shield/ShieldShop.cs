using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShop : Singleton<ShieldShop>
{
    public Player player;

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
}
