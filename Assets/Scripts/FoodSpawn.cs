using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    private PlayerController PlayerControllerScript;
    public GameObject pananaPrefab;
    public GameObject MelonPrefab;
    public GameObject cheesePrefab;
    public GameObject cherryPrefab;

    private Vector3 pananaspawnPos = new Vector3(16.39f, 0, 0);
    private Vector3 MelonspawnPos = new Vector3(23.4f, 0, 0);
    private Vector3 cheesespawnPos = new Vector3(19.95f, 0, 0);
    private Vector3 cherryspawnPos = new Vector3(13.83f, 0, 0);

    private float startDelay = 2;
    private float rebeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", startDelay, rebeatRate);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnFood()
    {
        if (PlayerControllerScript.gameOver == false)
        {
            Instantiate(pananaPrefab, pananaspawnPos, pananaPrefab.transform.rotation);
            Instantiate(MelonPrefab, MelonspawnPos, MelonPrefab.transform.rotation);
            Instantiate(cheesePrefab, cheesespawnPos, cheesePrefab.transform.rotation);
            Instantiate(cherryPrefab, cherryspawnPos, cherryPrefab.transform.rotation);
        }

    }
}

