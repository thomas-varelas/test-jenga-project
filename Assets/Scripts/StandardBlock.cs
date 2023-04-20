using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : MonoBehaviour
{
    public enum Type
    {
        Wood,Stone, Glass
    }
    [SerializeField] public Type blockType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void provideInfo()
    {
        Debug.Log("TEST SUCCESS OBJECT:" + gameObject.name);
    }
}
