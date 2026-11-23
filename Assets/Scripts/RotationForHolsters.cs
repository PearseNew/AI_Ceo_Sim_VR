using UnityEngine;

public class RotationForHolsters : MonoBehaviour
{
    public GameObject cam;
    private Vector3 offset = new Vector3(0f, -2.55f, 0.07f);
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
        transform.position = cam.transform.position + (transform.rotation * offset);
    }
}
