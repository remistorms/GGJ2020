using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRig : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float followSpeed;
    [SerializeField] private float rotateSpeed;
    public Vector3 currentPivotRotation;

    private void Start()
    {
        GetTarget();
        currentPivotRotation = new Vector3( 
            cameraPivot.transform.rotation.x,
            cameraPivot.transform.rotation.y,
            cameraPivot.transform.rotation.z );
    }

    private void GetTarget()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCamera(90);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateCamera(-90);
        }

    }

    private void RotateCamera(float angle)
    {
        //  cameraPivot.transform.Rotate(Vector3.up, angle);
       currentPivotRotation = currentPivotRotation + new Vector3(0, angle, 0);
        cameraPivot.transform.DORotate(currentPivotRotation, 0.5f);
    } 

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position, Time.deltaTime * followSpeed);
    }
}
