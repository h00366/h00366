using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;                          // 카메라 각도 & 위치 정보
    private Animator animator;                                  // 케릭터 에니메이션
    private Movement3D movement3D;                              // 움직임 관리


    private void Awake()
    {
        Cursor.visible = false;                                 // 카메라 커서 숨김
        Cursor.lockState = CursorLockMode.Locked;               // 카메라 커서 움직이지 않음

        animator = GetComponent<Animator>();
        movement3D = GetComponent<Movement3D>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");         // 앞,뒤 값 입력 받음
        float vertical = Input.GetAxis("Vertical");             // 좌,우 값 입력 받음
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;   // shft키를 누르면 뛰기


        animator.SetFloat("Horizontal", horizontal * offset);   // Horizontal값에 따라 애니메이션이 움직임
        animator.SetFloat("Vertical", vertical * offset);       // Vertical값에 따라 애니메이션이 움직임

        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
                                                                // 케릭터 방향을 카메라가 보는 방향으로 설정
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(horizontal, 0, vertical) * offset);
                                                                // 케릭터가 움직이는 방향을 카메라가 보는 방향 + 키값  + 쉬프트여부)
    }
}
