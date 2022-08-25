using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class QuestionScript : MonoBehaviour
{
    [HideInInspector] public List<int> qnValues = new List<int>();
    [HideInInspector] public string qnString;
    [HideInInspector] public int ansIndex;
    [HideInInspector] public List<int> optValues = new List<int>();
    [HideInInspector] public int ansValue;
    [HideInInspector] public bool attempted;
    [HideInInspector] public int finalAnsValue;

    public bool qnAttempted = false;
    public TextMeshProUGUI qnTextParse;
    public List<TextMeshProUGUI> optionFields = new List<TextMeshProUGUI>();
    public GameObject gateObject;
    public OxygenTracker oxygenTrackerRef;


    private List<int> expValues = new List<int> ();
    private float newGateYPos;


    void Start()
    {
        newGateYPos = gateObject.transform.position.y + 5;

        List<int> values = new List<int> ();
        
        for (int i = 1; i < 10; i++)
        {
            values.Add (i);
        }
        
        for (int i = 0; i <= 3; i++)
        {
            int randIndex = Random.Range (0, values.Count);
            qnValues.Add(values[randIndex]);
            values.RemoveAt (randIndex);
            qnString += qnValues[i].ToString();

            float tempNum = 3 - i;
            expValues.Add(Mathf.RoundToInt(Mathf.Pow(10, tempNum)));
        }

        ansIndex = Random.Range(0, qnValues.Count);
        ansValue = qnValues[ansIndex];
        //ansUGUI.text = ansValue.ToString();

        optValues.Add(ansValue * expValues[ansIndex]);
        finalAnsValue = ansValue * expValues[ansIndex];
        expValues.RemoveAt (ansIndex);



        int secIndex = Random.Range(0, expValues.Count);
        optValues.Add(ansValue * expValues[secIndex]);
        expValues.RemoveAt(secIndex);

        int thirdIndex = Random.Range(0, expValues.Count);
        optValues.Add(ansValue * expValues[thirdIndex]);
        expValues.RemoveAt(thirdIndex);

        optionFields[0].text = optValues[0].ToString();
        optionFields[1].text = optValues[1].ToString();
        optionFields[2].text = optValues[2].ToString();

        for (int i = 0; i < 3; i++)
        {
            int temp = optValues[i];
            int randomIndex = Random.Range(i, optValues.Count);
            optValues[i] = optValues[randomIndex];
            optValues[randomIndex] = temp;
        }


        for (int i = 0; i < 3; i++)
        {
            Debug.Log(optValues[i]);
        }

        Debug.Log("Answer is " + finalAnsValue);
        Debug.Log("Qn is " + qnString + ", ansIndex is " + ansIndex.ToString() + ", and ans value is " + qnValues[ansIndex].ToString());

        qnTextParse.text = "What is the place value of " + qnValues[ansIndex].ToString() + " in " + qnString + "?";


    }

    public void CheckForAnswer(string parsedAnswer)
    {
        if (qnAttempted != true)
        {
            qnAttempted = true;
        }
        
        Debug.Log("Selected option is " + parsedAnswer);
        if (parsedAnswer == finalAnsValue.ToString())
        {
            Debug.Log("Chosen answer is true");
            oxygenTrackerRef.RestoreOxygen();
        }
        else { Debug.Log("Chosen answer is wrong"); }
    }

    private void Update()
    {
        if (qnAttempted == true && gateObject.transform.position.y < newGateYPos)
        {
            gateObject.transform.position += transform.up * Time.deltaTime;

        }
    }


}
