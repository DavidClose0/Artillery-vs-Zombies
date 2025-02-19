using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour
{
    public GameObject explosionPrefab;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Shell collided.");
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Zombie"))
        {
            Explode();
        }
    }

    void Explode()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject); // Destroy the shell itself
    }
}