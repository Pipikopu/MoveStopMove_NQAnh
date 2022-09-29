using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour, IHit
{
    public Character character;
    public CharacterBoundary charBound;

    protected float scale = 1;
    protected int score = 0;
    protected float range = 1;

    protected int scoreToScale = 2;

    protected new string name;

    private void Start()
    {
        scale = 1;
        score = 0;
        range = 1;
        scoreToScale = 2;
    }

    private void OnEnable()
    {
        OnInit();
    }

    private void OnInit()
    {
        scale = 1;
        charBound.transform.localScale = Vector3.one;
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

        scoreToScale -= increaseValue;

        if (scoreToScale <= 0)
        {
            IncreaseScale(1.1f);
            scoreToScale = 2;
        }
    }

    public float GetScale()
    {
        return scale;
    }

    public virtual void IncreaseRange(float increaseValue) { }

    public float GetRange()
    {
        return range;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        scoreToScale = 3;
    }

    public void SetName(string newName)
    {
        name = newName;
    }

    public string GetName()
    {
        return name;
    }

    public virtual void Move() { }

    public virtual void Attack() { }

    public virtual void Death(Character killer) { }

    public virtual void GetHit(Character killer)
    {
        Death(killer);
    }
}
