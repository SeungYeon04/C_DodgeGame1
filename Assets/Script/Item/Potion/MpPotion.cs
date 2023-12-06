using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D mpPotion)
    {
        if (mpPotion.CompareTag("Character"))
        {
            Destroy(gameObject);
            Player _player = mpPotion.GetComponent<Player>();
            if (_player != null)
            {
                _player.currentMp += 20;
                Debug.Log($"���� ȸ�� ! ���� MP {_player.currentMp}");
            }
            else
            {
                Debug.Log($"Player�� ����");
            }

        }
    }
}
