using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenTracker : MonoBehaviour
{

    [HideInInspector] public float oxygenLevel;
    [HideInInspector] public int reductionStage = 1;
    [HideInInspector] public bool maskOn = false;
    private float lerpTimer;
    public float maxOxygen = 100;
    public float chipSpeed = 2.0f;
    public Image frontOxygenBar;
    public Image backOxygenBar;
    public TextMeshProUGUI oxygenTextField;

    private float calcTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        oxygenLevel = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {

        //if (maskOn == true) { reductionStage = 0; } else { reductionStage = 1; }

        reductionStage = maskOn ? 0 : 1;

        oxygenTextField.text = oxygenLevel.ToString();

        oxygenLevel = Mathf.Clamp(oxygenLevel, 0, maxOxygen);
        UpdateOxygenUI();
        if (Input.GetKeyDown(KeyCode.T))
        {
            DecrementOxygen(Random.Range(5, 10));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RestoreOxygen(Random.Range(5, 10));
        }

        calcTime += Time.deltaTime;

        if (calcTime > 2.0f)
        {
            //Debug.Log("Summoned");

            if (!maskOn)
            {
                switch (reductionStage)
                {
                    case 0:
                        DecrementOxygen(0.0f);
                        break;
                    case 1:
                        DecrementOxygen(2.5f);
                        break;
                    case 2:
                        DecrementOxygen(10.0f);
                        break;
                }
            }

            calcTime = 0.0f;
        }




    }

    public void UpdateOxygenUI()
    {
        //Debug.Log(oxygenLevel);
        float fillF = frontOxygenBar.fillAmount;
        float fillB = backOxygenBar.fillAmount;
        float hFraction = oxygenLevel / maxOxygen;

        if(fillB > hFraction)
        {
            frontOxygenBar.fillAmount = hFraction;
            backOxygenBar.color = Color.red;
            lerpTimer += Time.deltaTime;

            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backOxygenBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        if (fillF < hFraction)
        {
            backOxygenBar.fillAmount = hFraction;
            backOxygenBar.color = Color.green;
            lerpTimer += Time.deltaTime;

            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontOxygenBar.fillAmount = Mathf.Lerp(fillF, backOxygenBar.fillAmount, percentComplete);
        }
    }

    public void DecrementOxygen (float oxDec)
    {
        oxygenLevel -= oxDec;
        lerpTimer = 0.0f;
    }

    public void RestoreOxygen(float oxInc)
    {
        oxygenLevel += oxInc;
        lerpTimer = 0.0f;
    }

    public void RestoreOxygen()
    {
        oxygenLevel = maxOxygen;
        lerpTimer = 0.0f;
    }

    public void MaskShift()
    {
        maskOn = true;
        Debug.Log("Started");
        StartCoroutine(MaskSwitchBack());
    }

    IEnumerator MaskSwitchBack()
    {
        yield return new WaitForSeconds(5);
        maskOn = false;
        Debug.Log("Ended");
    }


}
