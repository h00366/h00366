using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float JumpForce = 5.0f;                                 // �����Ŀ�
    private float walkSpeed = 2.0f;                                 // �ȴ¼ӵ�
    private float RunSpeed = 3.5f;                                  // �ٴ¼ӵ�
    private Vector3 moveDirection;                                  // �̵����� 


    private CharacterController characterController;                // �ɸ��� ��Ʈ�ѷ�
    

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;       // shftŰ�� ������ �ٱ�, 
        float moveSpeed = Mathf.Lerp(walkSpeed, RunSpeed, Input.GetAxis("Sprint"));
                                                                    // �ȴ¼ӵ� or �ٴ¼ӵ�, shift Ű�� �۵�Ű
        characterController.Move(moveDirection * Time.deltaTime * moveSpeed);
    }

    public void MoveTo(Vector3 direction)                           // �ܺο��� ������ ȣ��Ǿ�����
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
                                                                    // ���� ���� X,Z������ ����.
    }
}