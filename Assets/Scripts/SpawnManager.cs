using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController PlayerControllerScript;
    public GameObject obstaclePrefab;
  
    private Vector3 spawnPos = new Vector3(26.545f, 0f, 0.9611f);
    
    private float startDelay = 1;
    private float rebeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("SpawnObstecal", startDelay, rebeatRate);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstecal()
    {
        if(PlayerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

        }
       

    }
 
    }

