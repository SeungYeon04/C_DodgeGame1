using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int atk;
    public float speed;

    float DesBullet;

    void Start()
    {
        DesBullet = GameManager.Instance.CurrentTime;
    }

    void Update()
    {
        if (GameManager.Instance.CurrentTime > 16f + DesBullet)
        {
            Destroy(gameObject);
        }
    }

    // Player�� �浹 ���� ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            
            if (player != null)
            {
                player.currentHp -= atk;
                Destroy(gameObject);
                Debug.Log($"HP�� {player.currentHp} ��ŭ ���Ҿ�!");
            }
        }
    }
}
