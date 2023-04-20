using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform selectedTarget;
    private int currentTargetIndex=0;
    private float rotateSpeed = 5f;
    private float distance = 10.0f;
    private float currentAngle = 0.0f;
    private Vector3 velocity = Vector3.zero;


    public Transform cameraRotator;
    public Transform[] allTargets;
    // Start is called before the first frame update
    public float dampTime = 0.15f;
    public float cameraMoveUpDownCenter = 0.15f;
    public float cameraMoveRightLeftCenter = 0.5f;




    private void Awake()
    {
        selectedTarget = allTargets[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentTargetIndex--;
            if (currentTargetIndex < 0)
            {
                currentTargetIndex = 0;
            }
            cameraRotator.position = allTargets[currentTargetIndex].position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentTargetIndex++;
            if (currentTargetIndex > 2)
            {
                currentTargetIndex = 2;
            }
            cameraRotator.position = allTargets[currentTargetIndex].position;
        }
        selectedTarget = allTargets[currentTargetIndex];
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (selectedTarget)
        {
            Vector3 point = gameObject.GetComponentInChildren<Camera>().WorldToViewportPoint(selectedTarget.position);
            Vector3 delta = selectedTarget.position - gameObject.GetComponentInChildren<Camera>().ViewportToWorldPoint(new Vector3(cameraMoveRightLeftCenter, cameraMoveUpDownCenter, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = cameraRotator.position + delta;
            cameraRotator.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            //transform.LookAt(selectedTarget);
        }*/

    }
}
