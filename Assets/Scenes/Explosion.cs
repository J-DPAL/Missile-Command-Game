using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    public float maxSize = 0.5f;
    public float growSpeed = 2f;
    public float lifeTime = 1f;

    void Start()
    {
        StartCoroutine(GrowAndDie());
    }

    System.Collections.IEnumerator GrowAndDie()
    {
        float time = 0;
        while (time < lifeTime)
        {
            float scale = Mathf.Lerp(0f, maxSize, time / lifeTime);
            transform.localScale = new Vector3(scale, scale, 1);
            time += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Missile"))
        {
            Destroy(other.gameObject);
            ScoreManager.instance.AddScore(100);
        }
    }
}
