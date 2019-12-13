using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cameraRotator : MonoBehaviour
{
    [SerializeField] float rotTime = 0.6f;
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
            transform.DORotate(new Vector3(0, 0, Mathf.Floor(transform.eulerAngles.z/90 + 1) * 90), rotTime, RotateMode.Fast);

        }
    }
}
