using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScripts : MonoBehaviour
{

    public Transform _respawnPosition;
    public Transform _playerObj;
    public CharacterController _characterController;
    public OxygenTracker _oxygenTracker;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collision");
        if (other.gameObject.tag == "RespawnPoints")
        {
            _respawnPosition = other.transform;
        }

        if (other.gameObject.tag == "KillTrigger")
        {
            Debug.Log("Killtrigger");
            Respawn();
        }

    }

    private void Respawn()
    {
        //Debug.Log("Respawn");
        _characterController.enabled = false;
        _playerObj.position = new Vector3(_respawnPosition.position.x, _respawnPosition.position.y, _respawnPosition.position.z);
        _characterController.enabled = true;
        _oxygenTracker.DecrementOxygen(Random.Range(10, 25));
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(_playerObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
