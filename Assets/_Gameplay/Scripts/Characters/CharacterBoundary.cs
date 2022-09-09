using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoundary : MonoBehaviour
{
    public Transform charBoundTransform;
    public Character character;

    private List<GameObject> targetCharacters;
    public bool isPlayer;

    private void OnEnable()
    {
        OnInit();
    }

    private void OnInit()
    {
        targetCharacters = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHAR_MODEL))
        {
            ITarget newITarget = other.gameObject.GetComponent<ITarget>();
            if (newITarget != null && newITarget.CanBeTargeted())
            {
                if (!targetCharacters.Contains(other.gameObject))
                {
                    targetCharacters.Add(other.gameObject);
                }
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
            ITarget newITarget = currentChar.GetComponent<ITarget>();

            if (Vector3.Distance(charBoundTransform.position, currentChar.transform.position) >= (6.5f * character.GetScale()))
            {
                targetCharacters.Remove(currentChar);
                if (targetCharacters.Count == 0) return null;
                continue;
            }

            if (!newITarget.CanBeTargeted() || newITarget == null)
            {
                targetCharacters.Remove(currentChar);
                if (targetCharacters.Count == 0) return null;
            }
            else
            {
                newDistance = Vector3.Distance(charBoundTransform.position, targetCharacters[i].transform.position);
                if (newDistance < shortestDistance)
                {
                    shortestDistance = newDistance;
                    targetCharacter = currentChar;
                }
            }
        }
        return targetCharacter;
    }
}
