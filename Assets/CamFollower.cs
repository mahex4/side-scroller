using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    [SerializeField] private GameObject _focusPoint;
    public float valueShift;
    [HideInInspector] public bool isInsideCameraShifter = false;
    [HideInInspector] public Vector3 midPos;
    private GameObject playerRef;

    public float CamMoveSpeed = 5.0f;

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(_focusPoint.transform.position.x, valueShift, _focusPoint.transform.position.z);

        midPos = new Vector3(midPos.x, valueShift, midPos.z);

        if (!isInsideCameraShifter)
        {
            transform.position = newPos;
        }
        else
        {
            if (playerRef.transform.position.z < midPos.z)
            {
                transform.position = Vector3.Lerp(transform.position, midPos, CamMoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = newPos;
            }
            
        }
    }
}
