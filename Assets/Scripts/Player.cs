using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text lifeText;
    public Text scoreText;
    public int life = 30;
    public int score = 0;

    private void Awake()
    {
        life = 30;
        score = 0;
        lifeText.text = "Life: " + life;
        scoreText.text = "Score: " + score;
    }

    private void OnEnable()
    {
        life = 30;
        score = 0;
    }

    public void reduceLife()
    {
        life -= 1;
        lifeText.text = "Life: " + life;
    }

    public void addLife(int _life)
    {
        life += _life;
        lifeText.text = "Life: " + life;
    }

    public void addScore(int _score)
    {
        score += _score;
        scoreText.text = "Score: " + score;
    }
}
