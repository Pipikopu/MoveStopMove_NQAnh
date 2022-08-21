using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoundary : MonoBehaviour
{
    public Transform characterTransform;
    public GameObject thisCharModel;
    private List<GameObject> targetCharacters = new List<GameObject>();
    public bool isPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHAR_MODEL))
        {
            ITarget newITarget = other.gameObject.GetComponent<ITarget>();
            if (newITarget != null && newITarget.CanBeTargeted())
            {
                targetCharacters.Add(other.gameObject);
                if (isPlayer)
                {
                    newITarget.EnableLockTarget();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHAR_MODEL))
        {
            ITarget newITarget = other.gameObject.GetComponent<ITarget>();
            if (newITarget != null)
            {
                targetCharacters.Remove(other.gameObject);
                if (isPlayer)
                {
                    newITarget.DisableLockTarget();
                }
            }
        }
    }

    public GameObject GetTargetCharacter()
    {
        if (targetCharacters.Count == 0) return null;
        float shortestDistance = 100f;
        float newDistance;
        GameObject targetCharacter = null;
        for (int i = targetCharacters.Count - 1; i >= 0; i--)
        {
            GameObject currentChar = targetCharacters[i];
            if (!currentChar.GetComponent<ITarget>().CanBeTargeted())
            {
                targetCharacters.Remove(currentChar);
                continue;
            }

            newDistance = Vector3.Distance(characterTransform.position, targetCharacters[i].transform.position);
            if (newDistance < shortestDistance)
            {
                shortestDistance = newDistance;
                targetCharacter = currentChar;
            }
        }
        return targetCharacter;
    }
}
