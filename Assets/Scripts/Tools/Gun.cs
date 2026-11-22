using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool inChamber = false;
    public GameObject projectile;
    private float projectileMag = 750f;    
    public GameObject barrel;
    public void Reload(GameObject projectileClone)
    {
        Projectile projectileScript = projectileClone.GetComponent<Projectile>();

        if (!(inChamber) && !(projectileScript.isFiring))
        {
            inChamber = true;
            Debug.Log("reloaded");
            Destroy(projectileClone);
        }
    }

   public void Shoot()
    {
        if (inChamber)
        {
            GameObject projectileClone = Instantiate(projectile,barrel.transform.position,barrel.transform.rotation);
            Projectile projectileScript = projectileClone.GetComponent<Projectile>();
            projectileScript.isFiring = true;
            Rigidbody rb = projectileClone.transform.GetComponent<Rigidbody>();
            rb.AddForce(projectileClone.transform.up * projectileMag);
            inChamber = false;
        }
    }

}
