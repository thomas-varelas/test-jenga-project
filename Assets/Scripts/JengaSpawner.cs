using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public int numLayers = 6; 
    public float blockWidth = 1f;
    public float blockHeight = 0.5f; 
    public float rotationAngle = 90f;
    public float blockSpacing = 0.5f;

    private List<GameObject> blocks = new List<GameObject>();  
    private int currentLayer = 0;  

    void Start()
    {
        for (int i = 0; i < numLayers; i++)
        {
            AddLayer();
        }
    }

    private void Update()
    {
        
    }

    void AddLayer()
    {
        float layerWidth = blockWidth * 3f;
        float offsetZ = (currentLayer % 2 == 0) ? 0f : blockWidth * 1.5f;
        float offsetX = (currentLayer % 2 == 0) ? 0f : blockWidth * 1.5f;
        float offsetY = currentLayer * blockHeight;

        for (int i = 0; i < 3; i++)
        {
            GameObject block = Instantiate(blockPrefab,gameObject.transform,true);
            
            
            if (currentLayer % 2 == 1)
            {
                block.transform.Rotate(new Vector3(0f, rotationAngle, 0f));
                block.transform.position = transform.position + new Vector3((i-1) * blockWidth, offsetY, 0f + blockWidth);                
            }
            else
            {
                block.transform.position = transform.position + new Vector3(0f, offsetY, i * blockWidth + offsetZ+ (i - 1) * blockSpacing);
            }
            blocks.Add(block);
        }

        currentLayer++;
    }
}
