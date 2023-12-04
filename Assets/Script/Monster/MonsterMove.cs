using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public Rigidbody2D targetPlayer;

    Monster monster;
    SpriteRenderer sprite;
    Rigidbody2D monsterRigidbody;


    public void Awake()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        monster = GetComponent<Monster>();
    }

    public void FixedUpdate()
    {
        // ������ �̵� ����
        Vector2 direction = targetPlayer.position - monsterRigidbody.position;
        //monsterRigidbody.MovePosition(monsterRigidbody.position + (direction.normalized * moveSpeed * Time.fixedDeltaTime));

        transform.Translate(direction.normalized * monster.speed * Time.fixedDeltaTime);
        monsterRigidbody.velocity = Vector2.zero;
    }

    public void Update()
    {
        // �÷��̾� �������� �Ĵٺ���
        sprite.flipX = targetPlayer.position.x < 0;
        //sprite.flipX = targetPlayer.position.x < monsterRigidbody.position.x;
    }
}
