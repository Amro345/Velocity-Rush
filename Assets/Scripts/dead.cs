using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dead : MonoBehaviour
{
  
    public string targetTag = "Stone";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag(targetTag))
        {
         
           
            Destroy(gameObject);
        }

    }
   

}




