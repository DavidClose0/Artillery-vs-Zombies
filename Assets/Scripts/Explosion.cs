using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public float explosionDuration = 0.5f;

    void Start()
    {
        StartCoroutine(DestroyExplosion());
    }

    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(explosionDuration);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Destroy(other.gameObject);
        }
    }
}