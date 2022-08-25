using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    public float shiftPos = 3.0f;
    public OxygenTracker trackerRef;

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.PingPong(Time.time , 1) + shiftPos;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trackerRef.MaskShift();
            Destroy(gameObject);
        }
    }

}
