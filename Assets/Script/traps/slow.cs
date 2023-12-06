using UnityEngine;

public class slow : MonoBehaviour
{
    public float slowdownFactor = 0.5f; // �������� �ӵ� ���� ����
    public bool isInWater = false; //���ӿ��ִ��� üũ
  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character")) // �÷��̾�� �浹���� ��
        { 
            CharacterMove CharacterMove = collision.GetComponent<CharacterMove>();

            CharacterMove.ApplySlowdown(slowdownFactor);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character")) // �÷��̾�� �浹�� ������ ��
        {
            CharacterMove CharacterMove = collision.GetComponent<CharacterMove>();

            CharacterMove.ResetSpeed();
        }
    }
}

