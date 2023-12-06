using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Player : MonoBehaviour
{
    public static Player _player;

    public int atk;
    private int maxHp;
    public int currentHp;
    private int maxMp;
    public int currentMp;


    public static Player Instance { get; private set; }

    private bool isDead;


    private void Awake()
    {
        atk = 10;
        maxHp = 100;
        currentHp = 100; //�̰� ����ҰԿ� 
        maxMp = 100;
        currentMp = 30;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

       

    }

    void Start()
    {

    }


    void Update()
    {
        if (isDead)
        {
            PlayerIsDead();
        }
    }

    // BulletTrap�� �浹���� �� �߻�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletTrap"))
        {
            if (currentHp <= 0)
            {
                isDead = true;
            }
        }
    }

    // �÷��̾� ��� ��
    private void PlayerIsDead()
    {
        GameManager.Instance.GameOver();
    }
}
