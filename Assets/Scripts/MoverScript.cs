using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverScript : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    public float travelDistance;
    public float travelSpeed;
    public bool vertical;

    private Vector3 _midPos;
    private Vector3 _rightPos, _leftPos;

    void Start()
    {
        _midPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        if (!vertical)
        {
            _rightPos = new Vector3(_midPos.x, _midPos.y, _midPos.z + travelDistance);
            _leftPos = new Vector3(_midPos.x, _midPos.y, _midPos.z - travelDistance);
        }
        else
        {
            _rightPos = new Vector3(_midPos.x, _midPos.y + travelDistance, _midPos.z);
            _leftPos = new Vector3(_midPos.x, _midPos.y - travelDistance, _midPos.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(_leftPos, _rightPos, Mathf.PingPong(Time.time * travelSpeed, 1.0f));
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.parent = transform;
            Debug.Log(player.transform.parent.gameObject.name);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            player.transform.parent = null;
        }

    }

}
