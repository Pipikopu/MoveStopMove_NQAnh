using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache : Singleton<Cache>
{
    private Dictionary<GameObject, IHit> objToIHit = new Dictionary<GameObject, IHit>();
    private Dictionary<GameObject, ITarget> objToITarget = new Dictionary<GameObject, ITarget>();
    private Dictionary<GameObject, Indicator> objToIndicator = new Dictionary<GameObject, Indicator>();
    public Dictionary<GameObject, GameObject> botGOToIndicatorGO = new Dictionary<GameObject, GameObject>();


    #region Interface: IHit, ITarget
    public IHit GetIHitFromGameObj(GameObject obj)
    {
        if (!objToIHit.ContainsKey(obj))
        {
            IHit newIHit = obj.GetComponent<IHit>();
            if (newIHit == null) return null;
            else
                objToIHit[obj] = newIHit;
        }

        return objToIHit[obj];
    }

    public ITarget GetITargetFromGameObj(GameObject obj)
    {
        if (!objToITarget.ContainsKey(obj))
        {
            ITarget newITarget = obj.GetComponent<ITarget>();
            if (newITarget == null) return null;
            else
                objToITarget[obj] = newITarget;
        }

        return objToITarget[obj];
    }
    #endregion

    #region Indicator
    public void SetBotGOToIndicatorGO(GameObject botGO, GameObject indicatorGO)
    {
        botGOToIndicatorGO[botGO] = indicatorGO;
    }

    public GameObject GetIndicatorGOFromBotGO(GameObject botGO)
    {
        return botGOToIndicatorGO[botGO];
    }

    public Indicator GetIndicatorFromGameObj(GameObject obj)
    {
        if (!objToIndicator.ContainsKey(obj) || objToIndicator[obj] == null)
        {
            Indicator newIndicator = obj.GetComponent<Indicator>();
            if (newIndicator == null)
            {
                return null;
            }
            else
                objToIndicator[obj] = newIndicator;
        }
        return objToIndicator[obj];
    }
    #endregion
}
