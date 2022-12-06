using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    KeyCode up;

    [SerializeField] 
    KeyCode down;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = new Vector3(transform.position.x, Mathf.Clamp (transform.position.y, -7.31f, 7.31f), 0);
         // why is it so messed up and doesnt even stop the rocket 

        if (Input.GetKey(up))
        {
            transform.position += new Vector3(0, 15, 0) * Time.deltaTime;
        }

        if (Input.GetKey(down))
        {
            transform.position += new Vector3(0, -15, 0) * Time.deltaTime;
        }

    }
}