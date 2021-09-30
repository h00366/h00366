using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float JumpForce = 5.0f;                                 // 점프파워
    private float walkSpeed = 2.0f;                                 // 걷는속도
    private float RunSpeed = 3.5f;                                  // 뛰는속도
    private Vector3 moveDirection;                                  // 이동방향 


    private CharacterController characterController;                // 케릭터 컨트롤러
    

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;       // shft키를 누르면 뛰기, 
        float moveSpeed = Mathf.Lerp(walkSpeed, RunSpeed, Input.GetAxis("Sprint"));
                                                                    // 걷는속도 or 뛰는속도, shift 키가 작동키
        characterController.Move(moveDirection * Time.deltaTime * moveSpeed);
    }

    public void MoveTo(Vector3 direction)                           // 외부에서 움직임 호출되었을시
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
                                                                    // 받은 값의 X,Z값으로 수정.
    }
}