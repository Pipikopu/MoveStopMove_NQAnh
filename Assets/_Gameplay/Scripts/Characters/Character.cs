using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour, IHit
{
    public CharacterBoundary charBound;
    public TextMesh scoreText;

    protected float scale = 1;
    protected int score = 0;

    private void Start()
    {
        scale = 1;
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        OnInit();
    }

    private void OnInit()
    {
    }

    public void IncreaseScale(float scaleRatio)
    {
        scale *= scaleRatio;
        if (scale >= 2)
        {
            scale = 2;
        }
        charBound.transform.localScale = Vector3.one * scale;
    }

    public void IncreaseScore(int increaseValue)
    {
        score += increaseValue;
        scoreText.text = score.ToString();
    }

    public float GetScale()
    {
        return scale;
    }

    public virtual void Move() { }

    public virtual void Attack() { }

    public virtual void Death() { }

    public virtual void GetHit()
    {
        Death();
    }
}
