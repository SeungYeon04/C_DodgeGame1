using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _enemy;
    public static EnemyManager Enemy { get { return _enemy; } }

    public int Level { get; private set; }

    [SerializeField] private GameObject _player;
    private Rigidbody2D _targetPlayer;
    private Transform _playerPos;

    string[] _monsters = { "Monster_Skelet", "Monster_MaskedOrc", "Monster_Chort" };

    private Transform[] _door = new Transform[6];

    private void Init()
    {
        if (_enemy == null)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("EnemyManager");
            if (gameObject == null)
            {
                gameObject = new GameObject { name = "EnemyManager" };
                gameObject.AddComponent<EnemyManager>();
            }
            DontDestroyOnLoad(gameObject);
            _enemy = gameObject.GetComponent<EnemyManager>();
        }
    }

    private void Awake()
    {
        Init();

        _player = GameObject.FindGameObjectWithTag("Character");
        _targetPlayer = _player.GetComponent<Rigidbody2D>();
        _playerPos = _player.GetComponent<Transform>();
        Level = 1;

        _door[0] = GameManager.Resource.Load<Transform>("DoorPosition/Door1");
        _door[0] = GameManager.Resource.Load<GameObject>("DoorPosition/Door1").GetComponent<Transform>();
        _door[1] = GameManager.Resource.Load<GameObject>("DoorPosition/Door2").GetComponent<Transform>();
        _door[2] = GameManager.Resource.Load<GameObject>("DoorPosition/Door3").GetComponent<Transform>();
        _door[3] = GameManager.Resource.Load<GameObject>("DoorPosition/Door4").GetComponent<Transform>();
        _door[4] = GameManager.Resource.Load<GameObject>("DoorPosition/Door5").GetComponent<Transform>();
        _door[5] = GameManager.Resource.Load<GameObject>("DoorPosition/Door6").GetComponent<Transform>();
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

        // ���� �� ���� �ִϸ��̼� (���� �۾�)
    }

    // RandomIndex used for select type of monster
    private int GetRandomIndex()
    {
        // �غ�� ������ ������ 3�����̹Ƿ� ������ �ö� �ִ� 3����
        int max = (Level > 3) ? 3 : Level;
        int randomIndex = Random.Range(1, max);

        return randomIndex;
    }

    // ���͸� Ư�� ������ ����, ȣ�� �� ������ ������ ����ؼ� ���ο��� �ݺ���
    private void MonsterSpawn()
    {
        // ���� = ���Ͱ� �����Ǵ� ���� ����
        for (int i = 0; i < Level; i++)
        {
            // ���͸� instantiate �� ������ ������ Ÿ������ �����Ͽ� ����
            GameObject monster = GameManager.Resource.Instantiate( "Prefabs", _monsters[GetRandomIndex()]);

            // ������ ���� ��ġ�� i��° ������ �̵�
            monster.transform.position = _door[i].position;

            // ���Ͱ� �߰��� �÷��̾� ĳ���� ����
            MonsterMove monsterMove = monster.GetComponent<MonsterMove>();
            if (monsterMove != null)
            {
                monsterMove.SetTargetPlayer(_targetPlayer);
            }
        }
    }
}
