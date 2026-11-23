using UnityEditor.Embree;
using UnityEngine;

public class Backpack : PlayerManager
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GPU"))
        {
            gpu++;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("RAM"))
        {
            ram++;
            Destroy(other.gameObject);
        }
    }
    void Update()
    {
        
    }
}
