using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalRotation = 0;
    public float upDownRange = 60.0f;
    public float rotationSpeed = 2.0f;
    public InventoryManager inventoryManager;


    private Camera playerCamera;

    private float verticalVelocity = 0;


    private void Start()
    {

        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    private void Update()
    {

        CameraRotation();

        // �����������
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            verticalVelocity = -0.5f;

            // ������
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }


        // ��������� �������� ������������ � ���������
        moveDirection = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        moveDirection = transform.TransformDirection(moveDirection);
        characterController.Move(moveDirection * Time.deltaTime);
    }
    public void CameraRotation()
    {
        if (inventoryManager.isOpened == true)
        {
            return;
        }
        else
        {
            // ������� ��������� ����� � ������ (������� �� ��������)
            float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.Rotate(0, horizontalRotation, 0);

            // ������� ������ ����� � ���� (������� �� ��������)
            verticalRotation -= Input.GetAxis("Mouse Y") * rotationSpeed;
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
            playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        }
    }

}
