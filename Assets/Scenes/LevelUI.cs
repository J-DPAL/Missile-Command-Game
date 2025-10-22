using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    public MissileSpawner spawner;
    public TMP_Text levelText;

    void Update()
    {
        if (spawner != null && levelText != null)
        {
            levelText.text = "Level: " + spawner.GetLevel();
        }
    }
}