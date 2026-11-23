using UnityEngine;

public class Barrel : MonoBehaviour
{
    public AudioSource reloadSfx;
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
            reloadSfx.Play();
            gunScript.Reload(other.gameObject);
            
        }
    }
}
