using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform       Player;                         // ī�޶� ���� �÷��̾�

    private float           distance;                       // ī�޶�� �÷��̾�� �Ÿ�
    private float           xMoveSpeed = 500;               // ī�޶��� y�� ȸ�� �ӵ�       <- ���콺�� ��/�� �� �����̸� ī�޶�� y���� �������� ȸ���Ѵ�.
    private float           yMoveSpeed = 250;               // ī�޶��� x�� ȸ�� �ӵ�
    private float           yMinLimit = 5;                  // ī�޶��� y�� ȸ�� �ּҰ� 
    private float           ymaxLimit = 80;                 // ī�޶��� y�� ȸ�� �ִ밪
    private float           x, y;                           // ���콺 ���� ��� ��

    private void Awake()
    {
        // ���� ������ Ÿ�ٰ� ī�޶��� ��ġ�� �������� �Ÿ��� �ʱ�ȭ
        distance = Vector3.Distance(transform.position, Player.position);

        // ���� ī�޶��� ȸ�� ���� x,y�� ����
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;
    }
    // Update is called once per frame


    private void Update()
    {
        if (Player == null) return;                         // �÷��̾ �������� ������ �۵����� ����.
        
        // ���콺 x,y�� ������ ���� ������ ����
         x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
         y += Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;
      
         y = ClampAngle(y, yMinLimit, ymaxLimit);           // ������Ʈ�� ��/�Ʒ� �Ѱ� ���� ����
       
         transform.rotation = Quaternion.Euler(y, x, 0);    // ī�޶� ȸ���� ���� ����
    }
    void LateUpdate()
    {
        if (Player == null) return;                         // Ÿ���� ������ �۵���������.
                                                            // �÷��̾��� ��ġ�� �������� distance��ŭ �������� �i�ư���.
        transform.position = transform.rotation * new Vector3(0, 2.1f, -distance) + Player.position;
    }
    private float ClampAngle(float angle, float min, float max)         // ī�޶� �ޱ��� ������ġ �̻� �Ѿ�� ���������� ����
    {
        if (angle < -360) angle += 360;
        if (angle < 360) angle -= 360;

        return Mathf.Clamp(angle,min,max);
    }
}
