using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraMove : MonoBehaviour
{

    public float CamAngleSpeed;

    void Update()
    {
        LookAround();
    }

    public void LookAround()
    {
        float camAngleSpeed = CamAngleSpeed * Time.deltaTime;
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * camAngleSpeed;
        

        if (mouseDelta.x < 180f)
        {
            mouseDelta.x = Mathf.Clamp(mouseDelta.x, -1f, 70f);
        }
        else
        {
            mouseDelta.x = Mathf.Clamp(mouseDelta.x, 300f, 361f);
        }

        this.transform.rotation = Quaternion.Euler(mouseDelta.x, mouseDelta.x, this.transform.rotation.eulerAngles.z);
        // camAngle.x - mouseDelta.y << �������� ���ϰ� ���Ǵ� ���۹������ ����ڿ� ���� �ͼ����� �ٸ� �� �ִ�
        // +, - ���� �ΰ��� ������ �ξ ���ϴ� ���۹������ ������ �� �ֵ��� �ɼǿ� �߰�����
    }
}
