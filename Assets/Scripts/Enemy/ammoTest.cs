using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ammoTest : MonoBehaviour {

    public XRInteractionManager interactable;
    private XRSocketInteractor xrSocket;
    public GameObject projectile;

    private void Start()
    {
        xrSocket = GetComponent<XRSocketInteractor>();
    }
    public void CheckForAmmo()
    {
        GameObject localProject = Instantiate(projectile, xrSocket.transform);
        localProject.GetComponent<XRGrabInteractable>().interactionManager = interactable;
        localProject.transform.localScale = new Vector3 (200, 200, 200);
        xrSocket.StartManualInteraction(localProject.GetComponent<IXRSelectInteractable>());
    }

}
