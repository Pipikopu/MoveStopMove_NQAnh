using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bulletTransform;
    public GameObject originWeapon;
    public GameObject originCharModel;
    public GameObject originCharacter;

    public Vector3 directionVector = Vector3.zero;
    private Vector3 targetPosition = Vector3.zero;

    public float speed;
    public float rotateSpeed;

    void Update()
    {
        if (directionVector != Vector3.zero)
        {
            if (Vector3.Distance(bulletTransform.position, targetPosition) >= 0.15f)
            {
                bulletTransform.position += directionVector * speed * Time.deltaTime;
                bulletTransform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            else
            {
                originWeapon.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }

    public void SetOriginWeapon(GameObject weapon)
    {
        originWeapon = weapon;
    }

    public void SetOriginCharModel(GameObject charModel)
    {
        originCharModel = charModel;
    }

    public void SetOriginCharacter(GameObject character)
    {
        originCharacter = character;
    }

    public void SetDirectionVector(Vector3 vector)
    {
        directionVector = vector;
        targetPosition = originCharacter.transform.position + Vector3.up * 1f + originCharacter.transform.forward * 6f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHAR_MODEL))
        {
            if (other.gameObject.GetInstanceID() != originCharModel.GetInstanceID())
            {
                originWeapon.SetActive(true);
                IHit newIHit = other.gameObject.GetComponent<IHit>();
                if (newIHit != null)
                {
                    newIHit.GetHit();
                }
                Destroy(this.gameObject);
            }
        }
    }
}
