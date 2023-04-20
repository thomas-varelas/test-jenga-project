using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using System;

public class DataHandler : MonoBehaviour
{
    public string API_URL= "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";

    public JengaSpawner[] towers;

    public TMP_Text grade1Label;
    public TMP_Text grade2Label;
    public TMP_Text grade3Label;

    GradeData[] theRealData;
    // Start is called before the first frame update
    void Awake()
    {
        //theRealData = new NoNameRootJSON();
        StartCoroutine(getJSON(API_URL));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //in order to show info of blocks
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                StandardBlock blockInstance = hit.collider.gameObject.GetComponent<StandardBlock>();
                if (blockInstance != null)
                {
                    blockInstance.provideInfo();
                    return;
                }
            }
        }
    }

    IEnumerator getJSON(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonText = www.downloadHandler.text;
                Debug.Log(jsonText);
                theRealData = JsonConvert.DeserializeObject<GradeData[]>(jsonText);
                processData();
            }
            else
            {
                Debug.Log("Network Error: " + www.error);
            }
        }
    }

    private void processData()
    {
        List<string> grades = new List<string>();
        int currentGradeCounter = 0;
        Array.Sort(theRealData, new CustomDataComparer());
        foreach(GradeData entry in theRealData)// this is to get the different names in grade field
        {
            if (!grades.Contains(entry.grade))
            {
                if (currentGradeCounter > 2)
                {
                    continue;
                }
                grades.Add(entry.grade);
                towers[currentGradeCounter].blocks.Add(entry);
                currentGradeCounter++;
            }
            else
            {
                towers[grades.IndexOf(entry.grade)].blocks.Add(entry);
            }
        }
        grade1Label.text = grades[0];
        grade2Label.text = grades[1];
        grade3Label.text = grades[2];
        foreach(JengaSpawner tower in towers)
        {
            tower.buildTower();
        }
    }

}
