using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraMove : MonoBehaviour
{
    public Transform Player;
    public float CamAngleSpeed;

    void Update()
    {
        LookAround();
    }

    public void LookAround()
    {
        float camAngleSpeed = CamAngleSpeed * Time.deltaTime;
        Vector3 cameraRotation = this.transform.rotation.eulerAngles;

        cameraRotation.x -= Input.GetAxis("Mouse Y") * camAngleSpeed * Time.deltaTime;
        cameraRotation.y += Input.GetAxis("Mouse X") * camAngleSpeed * Time.deltaTime;

        if (cameraRotation.x < 180f)
        {
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, -1f, 70f);
        }
        else
        {
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, 300f, 361f);
        }

        Player.transform.localEulerAngles = new Vector3(cameraRotation.x, cameraRotation.y, Player.transform.rotation.eulerAngles.z);
        // camAngle.x - mouseDelta.y << �������� ���ϰ� ���Ǵ� ���۹������ ����ڿ� ���� �ͼ����� �ٸ� �� �ִ�
        // +, - ���� �ΰ��� ������ �ξ ���ϴ� ���۹������ ������ �� �ֵ��� �ɼǿ� �߰�����
    }
}



