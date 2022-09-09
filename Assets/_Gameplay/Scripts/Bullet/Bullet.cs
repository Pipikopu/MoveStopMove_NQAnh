using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bulletTransform;
    public Transform bulletRenderTransform;
    internal GameObject originWeapon;
    internal CharacterBoundary originCharBound;
    internal Character originCharacter;
    public MeshRenderer meshRend;

    internal Vector3 directionVector = Vector3.zero;
    private Vector3 originPos;

    public float range;
    public float speed;

    void Update()
    {
        if (directionVector != Vector3.zero)
        {
            if (Vector3.Distance(bulletTransform.position, originPos) <= range * originCharacter.GetScale())
            {
                bulletTransform.position += directionVector * speed * Time.deltaTime * originCharacter.GetScale();
                SpecialMove();
            }
            else
            {
                originWeapon.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }

    protected virtual void SpecialMove() { }

    public virtual void InitSkin(WeaponSkinID SkinID) { }

    public void SetOriginWeapon(GameObject weapon)
    {
        originWeapon = weapon;
    }

    public void SetOriginCharacter(Character character)
    {
        originCharacter = character;
        originPos = originCharacter.transform.position;
    }

    public void SetDirectionVector(Vector3 vector)
    {
        directionVector = vector;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHAR_MODEL))
        {
            if (other.gameObject.GetInstanceID() != originCharacter.gameObject.GetInstanceID())
            {
                originWeapon.SetActive(true);
                originCharacter.IncreaseScale(1.1f);
                originCharacter.IncreaseScore(1);
                IHit newIHit = other.gameObject.GetComponent<IHit>();
                if (newIHit != null)
                {
                    newIHit.GetHit();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
