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
    public bool canRotate = false;

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
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("LeftBumper"))
        {
            Debug.Log("Bumper Pressed");
            RotateCamera(90);
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("RightBumper"))
        {
            Debug.Log("Bumper Pressed");
            RotateCamera(-90);
        }

    }

    private void RotateCamera(float angle)
    {
        //  cameraPivot.transform.Rotate(Vector3.up, angle);
        if (canRotate)
        {
            StartCoroutine(_RotateCamera(angle));
        }

    }

    IEnumerator _RotateCamera(float angle)
    {
        canRotate = false;
        currentPivotRotation = currentPivotRotation + new Vector3(0, angle, 0);
        cameraPivot.transform.DORotate(currentPivotRotation, 0.5f);
        yield return new WaitForSeconds(0.5f);
        canRotate = true;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position, Time.deltaTime * followSpeed);
    }

    public Transform GetCameraPivot()
    {
        return cameraPivot;
    }
}
