using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "RotateScreen"))
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 90);
        }
    }
}
