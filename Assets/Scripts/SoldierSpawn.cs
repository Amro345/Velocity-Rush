using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawn : MonoBehaviour
{
    private PlayerController PlayerControllerScript;
   
    public GameObject soldierPrefab;

    private Vector3 soldierpos = new Vector3(29.4300003f, 0f, 1.20856667f);
    private float startDelay = 1;
    private float rebeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSoldier", startDelay, rebeatRate);
       
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnSoldier()
    {

        if (PlayerControllerScript.gameOver == false)
        {
            Instantiate(soldierPrefab, soldierpos, soldierPrefab.transform.rotation);

        }
    }

}
