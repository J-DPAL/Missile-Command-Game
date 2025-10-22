using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject[] bonusObjects; 
    public float spawnRate = 10f;     

    void Start()
    {
        InvokeRepeating(nameof(SpawnBonus), 5f, spawnRate);
    }

    void SpawnBonus()
    {
        int index = Random.Range(0, bonusObjects.Length);
        Vector3 pos = new Vector3(-9f, Random.Range(2f, 4f), 0); 
        GameObject bonus = Instantiate(bonusObjects[index], pos, Quaternion.identity);
        bonus.GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * 2f;
    }
}
