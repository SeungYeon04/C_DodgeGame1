using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    public static MonstersManager Enemy { get; private set; }

    public int Level { get; private set; }

    [SerializeField] private GameObject _player;
    private Rigidbody2D _targetPlayer;

    string[] _monsters = { "Monster_Skelet", "Monster_MaskedOrc", "Monster_Chort" };

    private Transform[] _door = new Transform[6];

    private void Awake()
    {
        //Singleton
        if (Enemy == null)
        {
            Enemy = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _player = GameObject.FindGameObjectWithTag("Character");
        _targetPlayer = _player.GetComponent<Rigidbody2D>();
        
        Level = 1;

        for (int i = 0; i < _door.Length; i++)
        {
            _door[i] = Resources.Load<Transform>($"DoorPosition/Door{i+1}");
        }
    }

    private void Start()
    {
        InvokeRepeating("MonsterSpawn", 2f, 2f);
    }

    /// <summary>
    /// ScoreManager���� 10ų �� ������ ���� 1�� ����, �ִ� 6����
    /// �� �̻��� ���� ������ ���� ������ ��ȭ�� ��� ���ǹ���
    /// </summary>
    public void LevelUp()
    {
        // max level == 6, max door open == 6
        if (Level < 6)
        {
            Level++;
        }

        BulletTrap.BulletTrapInstance.CurrentLevel();

        // ���� �� ���� �ִϸ��̼� (���� �۾�)
    }

    // RandomIndex used for select type of monster
    private int GetRandomIndex()
    {
        // �غ�� ������ ������ 3�����̹Ƿ� ������ �ö� �ִ� 3����
        int max = (Level > 3) ? 3 : Level;
        int randomIndex = Random.Range(0, max);

        return randomIndex;
    }

    // ���͸� Ư�� ������ ����, ȣ�� �� ������ ������ ����ؼ� ���ο��� �ݺ���
    private void MonsterSpawn()
    {
        // ���� = ���Ͱ� �����Ǵ� ���� ����
        for (int i = 0; i < Level; i++)
        {
            // ���͸� instantiate �� ������ ������ Ÿ������ �����Ͽ� ������ ���� ����
            GameObject monster = Resources.Load<GameObject>($"Prefabs/{_monsters[GetRandomIndex()]}");
            Instantiate(monster, _door[i].position, Quaternion.identity, transform);

            // ���Ͱ� �߰��� �÷��̾� ĳ���� ����
            MonsterMove monsterMove = monster.GetComponent<MonsterMove>();
            if (monsterMove != null)
            {
                monsterMove.SetTargetPlayer(_targetPlayer);
            }
        }
    }
}
