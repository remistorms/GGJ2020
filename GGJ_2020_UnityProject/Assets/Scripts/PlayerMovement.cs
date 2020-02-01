using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_RotateSpeed;

    private CharacterController m_CharacterController;
    private float desiredAngle;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Gets the move direction from left stick or arrow inputs and moves the character
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection.normalized;
        m_CharacterController.SimpleMove(moveDirection * m_MoveSpeed);
        
        //Angle from character forward and world forward
        desiredAngle = Vector3.SignedAngle(Vector3.forward, moveDirection.normalized, Vector3.up);
        
        //Rotate character if the input threshold is met
        if (moveDirection.magnitude > 0.2f)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, desiredAngle, 0), Time.deltaTime * m_RotateSpeed);
    }

}
