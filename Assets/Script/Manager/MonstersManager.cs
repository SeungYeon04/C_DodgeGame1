using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    public static MonstersManager Enemy { get; private set; }

    public int Level { get; private set; }

    string[] _monsters = { "Monster_Skelet", "Monster_MaskedOrc", "Monster_Chort" };

    [SerializeField] private Rigidbody2D _targetPlayer;

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

        Level = 1;
        _targetPlayer = GameObject.FindGameObjectWithTag("Character").GetComponent<Rigidbody2D>();

        // monster spawn point initialize
        for(int i = 0; i < _door.Length; i++)
        _door[0] = Resources.Load<Transform>("DoorPosition/Door1");
        _door[1] = Resources.Load<Transform>("DoorPosition/Door2");
        _door[2] = Resources.Load<Transform>("DoorPosition/Door3");
        _door[3] = Resources.Load<Transform>("DoorPosition/Door4");
        _door[4] = Resources.Load<Transform>("DoorPosition/Door5");
        _door[5] = Resources.Load<Transform>("DoorPosition/Door6");
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
            //Debug.Log($"Level = {Level}");
        }

        // BulletTrap level up
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
            // ���͸� instantiate �� ������ ������ Ÿ������ �����Ͽ� ����
            GameObject monster = Resources.Load<GameObject>($"Prefabs/{_monsters[GetRandomIndex()]}");
            Instantiate(monster, _door[i].position, Quaternion.identity, transform);

            // ������ ���� ��ġ�� i��° ������ �̵�
            //monster.transform.position = _door[i].position;

            // ���Ͱ� �߰��� �÷��̾� ĳ���� ����
            MonsterMove monsterMove = monster.GetComponent<MonsterMove>();
            monsterMove.SetTargetPlayer(_targetPlayer);
        }
    }
}
