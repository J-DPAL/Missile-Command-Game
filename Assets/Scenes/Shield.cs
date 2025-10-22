using UnityEngine;

public class Shield : MonoBehaviour
{
    public int hitsLeft = 2;  
    private SpriteRenderer shieldRenderer;

    void Start()
    {
        shieldRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Missile"))
        {
            hitsLeft--; 

            Destroy(other.gameObject);

            if (hitsLeft <= 0)
            {
                DeactivateShield();
            }
        }
    }


    void DeactivateShield()
    {
        shieldRenderer.enabled = false;  
        gameObject.SetActive(false);  
    }
}
