using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out RaycastHit hitInfo, 15f,~0, QueryTriggerInteraction.Collide))
        {
            if (hitInfo.collider.isTrigger)
            {
                Debug.Log("Hit trigger: " + hitInfo.collider.name);
            }
        }    
    }
}

