using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatShop : Singleton<HatShop>
{
    public Player player;

    public void TryHat(HatSkinID hatSkinID)
    {
        player.TryHat(hatSkinID);
    }

    public void ChooseHat()
    {
        player.ChangeHat();
    }

    public void ResetHat()
    {
        player.SetItems();
    }
}
