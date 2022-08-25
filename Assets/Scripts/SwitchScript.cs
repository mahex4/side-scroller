using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchScript : MonoBehaviour
{

    public GameObject SwitchCyl;
    private Vector3 _switchPos;
    private Vector3 _newSwitchPos;

    public TextMeshProUGUI optionSlot;
    public QuestionScript questionScriptRef;

    private void Start()
    {
        _switchPos = SwitchCyl.transform.position;
        _newSwitchPos = new Vector3(_switchPos.x, _switchPos.y + 0.298f, _switchPos.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (questionScriptRef.qnAttempted != true)
            {
                SwitchCyl.transform.position = _newSwitchPos;
                questionScriptRef.CheckForAnswer(optionSlot.text);
            }
            
        }
    }
}
        
