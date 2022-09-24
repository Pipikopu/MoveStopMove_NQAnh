using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache : Singleton<Cache>
{
    private Dictionary<GameObject, IHit> objToIHit = new Dictionary<GameObject, IHit>();
    private Dictionary<GameObject, ITarget> objToITarget = new Dictionary<GameObject, ITarget>();


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
}
