using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject player;
    public GameObject [] Spawns;
    public GameObject computerSpawns;
    public GameObject ammoSpawns;
    int GpuLimit;
    int RamLimit;
    int ammoLimit;
    public bool play;

    public GameObject gpuClone;
    public GameObject ramClone;
    public GameObject ammoClone;

    private float gpuTime =40;
    private float ramTime = 40;
    private float ammoTime = 40;

    public GameObject gpuParent;
    public GameObject ramParent;
    public GameObject ammoParent;

    void Start()
    {
        GpuLimit = 5;
        RamLimit = 5;
        ammoLimit = 3;
        play = false;
    }

    public void ClearGame()
    {
        player.transform.position = Spawns[1].transform.position;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void startGame()
    {
        play = true;
        player.transform.position = Spawns[0].transform.position;
    }
    void Update()
    {
        if(play)
        {
            gpuTime += Time.deltaTime;
            ramTime += Time.deltaTime;
            ammoTime += Time.deltaTime;

            if(gpuTime > 15)
            {
                gpuTime = 0;
                if (!(gpuParent.transform.childCount > 3))
                {
                    SpawnManager(computerSpawns, gpuClone).transform.SetParent(gpuParent.transform);
                }


            }
            if (ramTime > 15)
            {
                ramTime = 0;
                if (!(ramParent.transform.childCount > 3))
                {
                    
                    SpawnManager(computerSpawns, ramClone).transform.SetParent(ramParent.transform);
                }
            }

            if (ammoTime > 30)
            {
                ammoTime = 0;
                if (!(ammoParent.transform.childCount > 3))
                {
                    SpawnManager(ammoSpawns, ammoClone).transform.SetParent(ammoParent.transform);
                }
            }
        }
    }

    GameObject SpawnManager(GameObject list,GameObject type)
    {
        int randomIndex = Random.Range(0, list.transform.childCount);
        GameObject obj = Instantiate(type, list.transform.GetChild(randomIndex).position,Quaternion.identity);
        return obj;
    }
}
