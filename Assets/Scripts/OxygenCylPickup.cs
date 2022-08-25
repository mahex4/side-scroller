using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCylPickup : MonoBehaviour
{
    public OxygenTracker oxygenTrackerRef;
    private Vector3 _pivotPoint;

    private void Start()
    {
        _pivotPoint = transform.localPosition;
    }

    private void Update()
    {
        transform.RotateAround(_pivotPoint, Vector3.up, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            oxygenTrackerRef.RestoreOxygen();
            Destroy(this.gameObject);
        }
    }

}
