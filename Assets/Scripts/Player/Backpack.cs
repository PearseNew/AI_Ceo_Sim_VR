using UnityEditor.Embree;
using UnityEngine;

public class Backpack : PlayerManager
{
    public PlayerManager player;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GPU"))
        {
            player.gpu++;
            Destroy(other.gameObject);
            audioSource.Play();
        }
        if (other.CompareTag("RAM"))
        {
            player.ram++;
            Destroy(other.gameObject);
            audioSource.Play();
        }
    }
    void Update()
    {
        
    }
}
