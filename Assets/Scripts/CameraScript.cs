using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject _focusPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(_focusPoint.transform.position.x, 3.0f, _focusPoint.transform.position.z);

        transform.position = newPos;
    }
}
