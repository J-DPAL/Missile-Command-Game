using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;        
    public TMP_Text scoreText;               
    public MissileSpawner spawner; 

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
