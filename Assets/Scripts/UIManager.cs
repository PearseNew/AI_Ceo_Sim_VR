using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerManager playerScript;
    public TextMeshPro ram;
    public TextMeshPro gpu;
    void SetText()
    {
        ram.text = "RAM: " + playerScript.ram;
        gpu.text = "RAM: " + playerScript.gpu;
    }
}
