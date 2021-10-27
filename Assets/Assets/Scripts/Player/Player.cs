using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _body;
    private bool _resetJump = true;
    private float _jumpForce = 5f;
    private PlayerAnimations _animScript;

    [SerializeField] private float _speedWalk = 1.5f;
    [SerializeField] private float _speedRun = 3f;

    public int Health { get; set; }

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _animScript = GetComponent<PlayerAnimations>();
    }


    void Update()
    {
        Movement();
        Attack();
        
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _animScript.Attack();
        }
    }
    void Movement()
    {
        float deltaX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(deltaX * _speedRun, _body.velocity.y);
        
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            movement = new Vector2(_body.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpBool());
        }

        _body.velocity = movement;
        _animScript.Move(deltaX);
        _animScript.Jump(IsGrounded());
    }

    bool IsGrounded()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        if (hitinfo.collider != null)
        {
            if(_resetJump)
            {
                return true;
            }
            
        }
        return false;     
    }

    IEnumerator ResetJumpBool()
    {
        _resetJump = false;
        yield return new WaitForSeconds(0.1f);
        _resetJump = true;
    }

    public void Damage()
    {
        Debug.Log("PlayerDamage called");
    }
}
