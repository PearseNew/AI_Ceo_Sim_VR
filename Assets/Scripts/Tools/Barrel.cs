using UnityEngine;

public class Barrel : MonoBehaviour
{

    public GameObject gun;
    private Gun gunScript;
    void Start()
    {
        gunScript = gun.GetComponent<Gun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            gunScript.Reload(other.gameObject);
        }
    }
}
