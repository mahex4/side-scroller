using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject _focusPoint;
    [HideInInspector] public bool isInsideCameraShifter = false;
    [HideInInspector] public Vector3 midPos;


    public float CamMoveSpeed = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(_focusPoint.transform.position.x, 3.0f, _focusPoint.transform.position.z);

        if (!isInsideCameraShifter)
        {
            transform.position = newPos;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, midPos, CamMoveSpeed);
        }


        
    }
}
