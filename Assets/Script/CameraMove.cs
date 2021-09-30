using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform       Player;                         // 카메라가 따라갈 플레이어

    private float           distance;                       // 카메라와 플레이어간의 거리
    private float           xMoveSpeed = 500;               // 카메라의 y축 회전 속도       <- 마우스가 좌/우 로 움직이면 카메라는 y축을 기점으로 회전한다.
    private float           yMoveSpeed = 250;               // 카메라의 x축 회전 속도
    private float           yMinLimit = 5;                  // 카메라의 y축 회전 최소값 
    private float           ymaxLimit = 80;                 // 카메라의 y축 회전 최대값
    private float           x, y;                           // 마우스 값을 담는 값

    private void Awake()
    {
        // 최초 설정된 타겟과 카메라의 위치를 바탕으로 거리값 초기화
        distance = Vector3.Distance(transform.position, Player.position);

        // 최초 카메라의 회전 값을 x,y에 저장
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;
    }
    // Update is called once per frame


    private void Update()
    {
        if (Player == null) return;                         // 플레이어가 존제하지 않으면 작동하지 않음.
        
        // 마우스 x,y축 움직임 방향 정보를 저장
         x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
         y += Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;
      
         y = ClampAngle(y, yMinLimit, ymaxLimit);           // 오브젝트의 위/아래 한계 범위 설정
       
         transform.rotation = Quaternion.Euler(y, x, 0);    // 카메라 회전의 정보 갱신
    }
    void LateUpdate()
    {
        if (Player == null) return;                         // 타겟이 없으면 작동하지않음.
                                                            // 플레이어의 위치를 기준으로 distance만큼 떨어져서 쫒아간다.
        transform.position = transform.rotation * new Vector3(0, 2.1f, -distance) + Player.position;
    }
    private float ClampAngle(float angle, float min, float max)         // 카메라 앵글을 일정수치 이상 넘어가면 음수값으로 수정
    {
        if (angle < -360) angle += 360;
        if (angle < 360) angle -= 360;

        return Mathf.Clamp(angle,min,max);
    }
}
