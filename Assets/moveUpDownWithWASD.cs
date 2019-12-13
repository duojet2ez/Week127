using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDownWithWASD : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVect = new Vector3();
        inputVect.x = Input.GetAxis("Horizontal");
        inputVect.y = Input.GetAxis("Vertical");
        transform.position += inputVect * speed * Time.deltaTime;
        
        
    }
}
