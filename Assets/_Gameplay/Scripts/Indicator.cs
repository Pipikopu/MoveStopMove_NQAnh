using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Transform target;
    public GameObject followImage;
    public GameObject nameText;
    public Text scoreText;
    public Character originCharacter;

    private bool nameAvailable;

    public void SetOriginCharacter(Character character)
    {
        originCharacter = character;
        SetTarget();
        SetScore();
    }

    private void SetTarget()
    {
        target = originCharacter.transform;
    }

    private void SetScore()
    {
        scoreText.text = originCharacter.GetScore().ToString();
    }

    private void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
        nameAvailable = true;

        if (screenPos.x < 0)
        {
            screenPos.x = Screen.width / 12;
            nameAvailable = false;
        }
        else if (screenPos.x > Screen.width)
        {
            screenPos.x = Screen.width * 11 / 12;
            nameAvailable = false;
        }

        if (screenPos.y < 0)
        {
            screenPos.y = Screen.height / 15;
            nameAvailable = false;
        }
        else if (screenPos.y > Screen.height)
        {
            screenPos.y = Screen.height * 14 / 15;
            nameAvailable = false;
        }

        if (nameText.activeInHierarchy == false && nameAvailable)
        {
            nameText.SetActive(true);
        }
        else if (nameText.activeInHierarchy == true && !nameAvailable)
        {
            nameText.SetActive(false);
        }

        followImage.transform.position = new Vector2(screenPos.x, screenPos.y + Screen.height / 8);

        SetScore();
    }
}
