using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed;
    public Transform tf;

    private void Update()
    {
        tf.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
