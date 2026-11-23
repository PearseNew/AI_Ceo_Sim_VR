using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody body;
    public AudioSource hitSfx;
    public bool isFiring = false;

    private void OnTriggerEnter(Collider other)
    {
        if(body.linearVelocity.magnitude > .5f)
        {
            hitSfx.volume = body.linearVelocity.magnitude;
            hitSfx.Play();
        }

    }
}
