using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour
{
    public float slowdownFactor = 0.5f; // �������� �ӵ� ���� ����
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character")) // �÷��̾�� �浹���� ��
        {
            CharacterMove CharacterMove = collision.GetComponent<CharacterMove>();

            if (CharacterMove != null)
            {
                // �÷��̾��� �ӵ��� ���ҽ�Ŵ
                CharacterMove.ApplySlowdown(slowdownFactor);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character")) // �÷��̾�� �浹�� ������ ��
        {
            CharacterMove CharacterMove = collision.GetComponent<CharacterMove>();

            if (CharacterMove != null)
            {
                // �÷��̾��� �ӵ��� ������� ������Ŵ
                CharacterMove.ResetSpeed();
            }
        }
    }

}

