using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public GameObject giftGO;
    public float buffTime;
    public Constant.GiftBuff buff;

    private void OnEnable()
    {
        int randomBuff = Random.Range(0, 2);
        buff = (Constant.GiftBuff)randomBuff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GiftController.Ins.player.gameObject)
        {
            switch (buff)
            {
                case Constant.GiftBuff.SPEED:
                    GiftController.Ins.player.IncreaseSpeedInTime(buffTime);
                    break;
                case Constant.GiftBuff.RANGE:
                    GiftController.Ins.player.IncreaseRangeInTime(buffTime);
                    break;
                case Constant.GiftBuff.SCALE:
                    GiftController.Ins.player.IncreaseScaleInTime(buffTime);
                    break;
                default:
                    break;
            }
            SimplePool.Despawn(giftGO);
        }
    }
}
