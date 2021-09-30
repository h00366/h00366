using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;                          // ī�޶� ���� & ��ġ ����
    private Animator animator;                                  // �ɸ��� ���ϸ��̼�
    private Movement3D movement3D;                              // ������ ����


    private void Awake()
    {
        Cursor.visible = false;                                 // ī�޶� Ŀ�� ����
        Cursor.lockState = CursorLockMode.Locked;               // ī�޶� Ŀ�� �������� ����

        animator = GetComponent<Animator>();
        movement3D = GetComponent<Movement3D>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");         // ��,�� �� �Է� ����
        float vertical = Input.GetAxis("Vertical");             // ��,�� �� �Է� ����
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;   // shftŰ�� ������ �ٱ�


        animator.SetFloat("Horizontal", horizontal * offset);   // Horizontal���� ���� �ִϸ��̼��� ������
        animator.SetFloat("Vertical", vertical * offset);       // Vertical���� ���� �ִϸ��̼��� ������

        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
                                                                // �ɸ��� ������ ī�޶� ���� �������� ����
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(horizontal, 0, vertical) * offset);
                                                                // �ɸ��Ͱ� �����̴� ������ ī�޶� ���� ���� + Ű��  + ����Ʈ����)
    }
}
