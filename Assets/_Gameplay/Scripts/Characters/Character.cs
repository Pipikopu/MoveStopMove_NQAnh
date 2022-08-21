using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IHit
{
    protected virtual void Move() { }

    protected virtual void Attack() { }

    public virtual void Death() { }

    public virtual void GetHit()
    {
        Death();
    }
}
