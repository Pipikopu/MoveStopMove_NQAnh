using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShop : Singleton<ShieldShop>
{
    public Player player;

    public void TryShield(ShieldSkinID shieldSkinID)
    {
        player.TryShield(shieldSkinID);
    }

    public void ChooseShield()
    {
        player.ChangeShield();
    }

    public void ResetShield()
    {
        player.SetItems();
    }
}
