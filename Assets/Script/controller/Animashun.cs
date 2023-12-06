using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Animashun : MonoBehaviour
{


    public Animator penguinA;
    public Animator penguinSide;
    public Animator penguinDie; 
    public GameObject player;
    

    public KeyCode key1 = KeyCode.W, S, A, D;
    public KeyCode key2 = KeyCode.Q;
    public KeyCode key3 = KeyCode.E;

    float setTime = 1; //���� ù �ð� 
    float sideTime = 1; //�����̵� ����ð� 1��
    float sideCool = 0;

    void Start()
    {
      //  rigid = GetComponent<Rigidbody2D>();
        penguinA = GetComponent<Animator>(); //�ʱ�ȭ 
        penguinSide = GetComponent<Animator>(); //����ϰ� �ϳ� �� 
    }

    void Update()
    {

        if(Input.GetKey(key1) || Input.GetKey(S) || Input.GetKey(A) || Input.GetKey(D)) 
        {
            // anim2.SetTrigger("walk"); 
            penguinA.SetBool("Walk", true);
        }
        else
        {
           // penguinA.SetTrigger("stand");
            penguinA.SetBool("Walk", false);
        }

        if(Input.GetMouseButtonDown(0)) //���콺 ����
        {
            penguinA.SetTrigger("Atack");
     
        }

        sideCool -= Time.deltaTime; //�����̵� ��Ÿ�� 
        sideTime -= Time.deltaTime; //�����̵� ���ѽð� ���� ���̳ʽ� 

        if (Input.GetKeyDown(key2)) //&& sideCool <= 0)
        {
            sideTime = 1; //��ư ������ ���ӽð� 1�� �÷��� 
            if (sideTime > 0)
            {
                penguinSide.SetTrigger("Side");
                CharacterMove.normalSpeed = 20.0f;
            }
        }
        else if (sideTime <= 0) //�ִϸ��̼� ���� ������? 
        {
            CharacterMove.normalSpeed = 9.0f;
            sideCool = 3;
        }


         setTime -= Time.deltaTime; // ���� �ð��� ���ҽ����ش�.

        if (Input.GetKeyDown(key3))
        {
            if (setTime <= 0)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                player.transform.position = mousePos;
            }
        }
        else if(setTime <= 0 && Input.GetKeyUp(key3))
        {
            setTime = 5; //����ð� 5�� ����
        }

        Debug.Log($"HP�� {Player.Instance.currentHp} ��ŭ ���Ҿ�!");

        if (Player.Instance.currentHp <= 0) //ü�� 0���� ���ų� ���� ��
        {
            penguinDie.SetBool("YouDie", true); //���� 
        }
        else if(Player.Instance.currentHp > 0)
        {
            penguinDie.SetBool("YouDie", false); //���� ��
        }
    }
}
