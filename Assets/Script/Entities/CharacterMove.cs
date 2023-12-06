using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private slow _slow;
    private CharacterController _controller;
    private Vector2 _MoveDirection = Vector2.zero; 
    public float _Speed = 1f;
    private Rigidbody2D _Rigidbody;
    public static float normalSpeed = 9.0f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _Rigidbody = GetComponent<Rigidbody2D>();
        _slow = GetComponent<slow>();

    }

    private void Start()
    {
        _controller.OnMoveEvent += ApplyMove;
      
    }

    private void FixedUpdate()
    {
        ApplyMove(_MoveDirection);
    }

    //private void Move(Vector2 direction)
    //{
    //    _MoveDirection = direction;
    //    if (_slow != null && _slow.IsPlayerStillInWater())
    //    {
    //        _Rigidbody.velocity = direction * _slow.slowdownFactor;
    //    }
    //    else
    //    {
    //        _Rigidbody.velocity = direction;
    //    }
    //}

    private void ApplyMove(Vector2 direction)
    {
        _MoveDirection = direction;
        direction = direction * normalSpeed * _Speed;
        _Rigidbody.velocity = direction;
    }
    public void ApplySlowdown(float slowdownFactor)
    {
        // �������� �ӵ� ���� ����
        _Speed = slowdownFactor; //��ȭ�Ǵ� ��Ҹ� ã�Ƽ� Ȯ���غ���.
    }

    public void ResetSpeed()
    {
        // �ӵ��� ������� ����
        _Speed = 1f;
    }
}
