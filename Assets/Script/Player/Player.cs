using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public int Atk;
    public int CurrentHp;
    public int CurrentMp;

    private int maxHp;
    private int maxMp;

    private bool isDead;
    public bool doubleShot;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Atk = 10;
        maxHp = 100;
        CurrentHp = 100;
        maxMp = 100;
        CurrentMp = 30;
        isDead = false;
    }

    // BulletTrap�� �浹���� �� �߻�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletTrap"))
        {
            if (CurrentHp <= 0)
            {
                CurrentHp = 0;
                isDead = true;
                PlayerIsDead();
            }
        }
    }

    // �÷��̾� ��� ��
    private void PlayerIsDead()
    {
        GameManager.Instance.GameOver();
    }

    public void PlusAtk()
    {
        Atk += 5;
        Debug.Log($"�÷��̾��� ���� ���ݷ� {Atk}");
    }

    public void DoubleShotOn()
    {
        doubleShot = true;
    }
}
