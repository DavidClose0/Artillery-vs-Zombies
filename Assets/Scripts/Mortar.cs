using System;
using UnityEngine;

public class Mortar : MonoBehaviour
{
    public GameObject projectile;
    public Transform target;
    public float muzzleVelocity = 20f;
    public Vector3 gravity = Physics.gravity;
    public float fireCooldown = 1f;

    private float timer = 1f;
    private FiringSolution firingSolution;

    void Start()
    {
        firingSolution = new FiringSolution();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer >= fireCooldown)
        {
            Fire();
            timer = 0;
        }
    }

    void Fire()
    {
        GameObject projectileGO = Instantiate(projectile, transform.position, Quaternion.identity);
        Rigidbody projectileRb = projectileGO.GetComponent<Rigidbody>(); // Get Rigidbody from the projectile

        Nullable<Vector3> fireDirectionNullable = firingSolution.Calculate(transform.position, target.position, muzzleVelocity, gravity);

        if (fireDirectionNullable.HasValue)
        {
            Vector3 launchVelocity = fireDirectionNullable.Value * muzzleVelocity;
            projectileRb.AddForce(launchVelocity, ForceMode.Impulse); // Apply force to the projectile's Rigidbody
        }

        else
        {
            Debug.LogWarning("No firing solution found!");
            Destroy(projectileGO); // Clean up if no solution
        }
    }
}