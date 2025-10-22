using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public GameObject explosionPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f;
            Instantiate(explosionPrefab, worldPos, Quaternion.identity);
        }
    }
}
