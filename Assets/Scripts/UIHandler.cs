using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TMP_Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOnPhysics()
    {
        StandardBlock[] allBlocks = FindObjectsOfType<StandardBlock>();
        foreach(StandardBlock sb in allBlocks)
        {
            sb.activatePhysics();
        }
    }
}
