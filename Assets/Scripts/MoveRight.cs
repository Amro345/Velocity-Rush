using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float rightBound = 30;
    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >rightBound)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
