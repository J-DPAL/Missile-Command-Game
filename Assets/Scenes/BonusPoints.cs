using UnityEngine;

public class BonusPoints : MonoBehaviour
{
    public int bonusScore = 200;
    public float baseSpeed = 5f;
    private static int bonusCount = 0; // Tracks number of spawned bonuses

    void Start()
    {
        bonusCount++; // Increment each time a bonus is created
        float newSpeed = baseSpeed + bonusCount * 0.5f; // Increase speed slightly per bonus
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * newSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        {
            Debug.Log("Bonus hit by explosion!");
            Destroy(gameObject);
            ScoreManager.instance.AddScore(bonusScore);
        }
    }
}
