using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaSpawner : MonoBehaviour
{
    public GameObject woodBlockPrefab;
    public GameObject stoneBlockPrefab;
    public GameObject glassBlockPrefab;
    //These values are implemented after research on Jenga block sizes 
    public float blockWidth = 1f;
    public float blockHeight = 0.5f; 
    public float rotationAngle = 90f;
    public float blockSpacing = 0.5f;

    public List<GradeData> blocks = new List<GradeData>();  
    private int currentLayer = 0;
    private int currentBlock = 0;

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void buildTower()
    {
        int numLayers = blocks.Count / 3;
        for (int i = 0; i < numLayers; i++)
        {
            AddLayer();
        }
    }

    void AddLayer()
    {
        float layerWidth = blockWidth * 3f;
        float offsetZ = (currentLayer % 2 == 0) ? 0f : blockWidth * 1.5f;
        float offsetX = (currentLayer % 2 == 0) ? 0f : blockWidth * 1.5f;
        float offsetY = currentLayer * blockHeight;

        for (int i = 0; i < 3; i++)
        {
            GameObject block;
            if (blocks[currentBlock].mastery == 0)
            {
                block = Instantiate(glassBlockPrefab, gameObject.transform, true);
                block.GetComponent<StandardBlock>().blockType = StandardBlock.Type.Glass;
            }
            else if (blocks[currentBlock].mastery == 1)
            {
                block = Instantiate(woodBlockPrefab, gameObject.transform, true);
                block.GetComponent<StandardBlock>().blockType = StandardBlock.Type.Wood;
            }
            else
            {
                block = Instantiate(stoneBlockPrefab, gameObject.transform, true);
                block.GetComponent<StandardBlock>().blockType = StandardBlock.Type.Stone;
            }            
            if (currentLayer % 2 == 1)
            {
                block.transform.Rotate(new Vector3(0f, rotationAngle, 0f));
                block.transform.position = transform.position + new Vector3((i-1) * blockWidth, offsetY, 0f + blockWidth);                
            }
            else
            {
                block.transform.position = transform.position + new Vector3(0f, offsetY, i * blockWidth + offsetZ+ (i - 1) * blockSpacing);
            }
            block.GetComponent<StandardBlock>().setBlockData(blocks[currentBlock]);
            currentBlock++;
        }

        currentLayer++;
    }
}
