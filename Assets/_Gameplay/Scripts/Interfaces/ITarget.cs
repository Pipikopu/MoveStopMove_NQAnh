using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ITarget
{
    public bool CanBeTargeted();

    public void DisableLockTarget();

    public void EnableLockTarget();
}
