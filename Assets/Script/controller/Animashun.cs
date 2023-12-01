using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animashun : MonoBehaviour
{
    public Animator penguinA;
    public Animator penguinSide; 
    public GameObject Player;
    //Rigidbody2D rigid; 
    
    public KeyCode key1 = KeyCode.W, S, A, D;
    public KeyCode key2 = KeyCode.Q;
    public KeyCode key3 = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
      //  rigid = GetComponent<Rigidbody2D>();
        penguinA = GetComponent<Animator>(); //�ʱ�ȭ 
        penguinSide = GetComponent<Animator>(); //����ϰ� �ϳ� �� 
    }

    // Update is called once per frame
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

        if (Input.GetKeyDown(key2))
        {
            penguinSide.SetTrigger("Side");
        }

        if (Input.GetKeyDown(key3))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Player.transform.position = mousePos;
        }
    }
}
