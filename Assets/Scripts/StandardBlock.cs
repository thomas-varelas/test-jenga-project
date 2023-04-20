using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
using TMPro;

public class StandardBlock : MonoBehaviour
{
    public enum Type
    {
        Wood,Stone, Glass
    }
    [SerializeField] public Type blockType;
    public TMP_Text label;
    public Outlinable outlier;
    public GameObject effect;

    private GradeData blockData;
    // Start is called before the first frame update
    void Start()
    {
        outlier.enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            outlier.enabled = false;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.collider.gameObject == gameObject)
                outlier.enabled = true;
            }
        }
    }

    public void provideInfo()
    {
        string info = blockData.grade + " : " + blockData.domain +
            "\n" + blockData.cluster +
            "\n" + blockData.standarddescription;
        UIHandler uiHandler = GameObject.FindObjectOfType<UIHandler>();
        uiHandler.infoText.SetText(info);
        outlier.enabled = true;
    }

    public void setBlockData(GradeData data)
    {
        blockData = data;
        label.SetText(data.subject);
    }

    public void activatePhysics()
    {
        if (blockType == Type.Glass)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
