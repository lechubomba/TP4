using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
 
    public GameObject projectilePrefab;
    public float launchForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }
    }

    void LaunchProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(transform.forward * launchForce, ForceMode.Impulse);
    }
}
