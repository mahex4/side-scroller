using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    [SerializeField] private GameObject _focusPoint;
    public float valueShift;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(_focusPoint.transform.position.x, valueShift, _focusPoint.transform.position.z);

        transform.position = newPos;
    }
}
