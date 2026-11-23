using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerManager playerScript;
    public TextMeshProUGUI ram;
    public TextMeshProUGUI gpu;
    public void SetText()
    {
        ram.text = "RAM: " + playerScript.ram;
        gpu.text = "GPU: " + playerScript.gpu;
    }
}
