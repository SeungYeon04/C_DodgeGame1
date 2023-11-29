using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // ����ٴ� ��� ĳ����

    void LateUpdate()
    {
        if (target != null)
        {
            // ĳ������ ��ġ�� ���󰡰� ����
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
