using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class CreateMonster : Monster
{

    [SerializeField] private GameObject _level1Monster;
    [SerializeField] private GameObject _level2Monster;
    [SerializeField] private GameObject _level3Monster;

    [SerializeField] private Transform _monsterLevel1MakePoint;
    [SerializeField] private Transform _monsterLevel2MakePoint;
    [SerializeField] private Transform _monsterLevel3MakePoint;

    //public int currentLevel = LevelManager.Instance.Level;

    public int currentLevel = 1; // ����� ���� ����
    
    public Rigidbody2D _targetPlayer;
    private bool spawnEnabled = false;

    private void Awake()
    {

    }
    void Start()
    {
        Invoke("LevelUp", 5f); // ����� ������ * ���߿� ���� ��

        InvokeRepeating("SpawnMonsterLevel1", 2f, 2f);
        _level1Monster.SetActive(true);

        Invoke("LevelUp2", 10f); // ����� ������ * ���߿� ���� ��
    }

    private void Update() // ���� ���� 
    {
        while (true)
        {
            if (currentLevel == 2 && spawnEnabled)
            {
                Debug.Log("2���� ���Ͱ� �����մϴ�");
                InvokeRepeating("SpawnMonsterLevel2", 4f, 4f);
                _level2Monster.SetActive(true);
                spawnEnabled = false;
                break;
            }
            if (currentLevel >= 3 && spawnEnabled)
            {
                Debug.Log("3���� ���Ͱ� �����մϴ�");
                InvokeRepeating("SpawnMonsterLevel3", 6f, 6f);
                _level3Monster.SetActive(true);
                spawnEnabled = false;
                break;
            }
            break;
        }
    }

    // ����� ������ * ���߿� ���� ��
    void LevelUp()
    {
        Debug.Log("LevelUp + 1");
        currentLevel++;
        Debug.Log(currentLevel);
        spawnEnabled = true;
    }
    void LevelUp2()
    {
        Debug.Log("LevelUp + 3");
        currentLevel++;
        currentLevel++;
        currentLevel++;
        Debug.Log(currentLevel);
        spawnEnabled = true;
    }
    // ����� ������ * ���߿� ���� ��


    void SpawnMonsterLevel1() // Level_1 Monster
    {
        MonsterMove monsterMove = _level1Monster.GetComponent<MonsterMove>();
        GameObject monster = Instantiate(_level1Monster, _monsterLevel1MakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;
        
        if(monsterMove != null)
        {
            monsterMove.SetTargetPlayer(_targetPlayer);
        }
    }

    void SpawnMonsterLevel2() // Level_2 Monster
    {
        MonsterMove monsterMove = _level2Monster.GetComponent<MonsterMove>();
        GameObject monster = Instantiate(_level2Monster, _monsterLevel2MakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;

        if (monsterMove != null)
        {
            monsterMove.SetTargetPlayer(_targetPlayer);
        }
    }

    void SpawnMonsterLevel3() // Level_3 Monster
    {
        MonsterMove monsterMove = _level3Monster.GetComponent<MonsterMove>();
        GameObject monster = Instantiate(_level3Monster, _monsterLevel3MakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;

        if (monsterMove != null)
        {
            monsterMove.SetTargetPlayer(_targetPlayer);
        }
    }
}