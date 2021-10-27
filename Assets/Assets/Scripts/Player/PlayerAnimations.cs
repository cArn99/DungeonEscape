using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public GameObject sprite;

    private Animator _anim;
    private Animator _swordAnim;
    private Transform _playerTransform;
    private Transform _swordArcTransform;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _swordArcRenderer;
    void Start()
    {
        _playerTransform = sprite.GetComponent<Transform>();
        _anim = GetComponentInChildren<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordArcRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _swordArcTransform = transform.GetChild(1).GetComponent<Transform>();
    }

    public void Move(float move)
    {
        _anim.SetFloat("Speed",Mathf.Abs(move));


        if (move == 1)
        {
            _spriteRenderer.flipX = false;
            _swordArcRenderer.flipX = false;
            _swordArcRenderer.flipY = false;
            _swordArcTransform.transform.localPosition = new Vector3(0.31f,-0.13f,0);   
        }
        else if (move == -1)
        {
            _spriteRenderer.flipX = true;
            _swordArcRenderer.flipX = true;
            _swordArcRenderer.flipY = true;
            _swordArcTransform.transform.localPosition = new Vector3(-0.29f, -0.13f, 0);
        }

    }
    public void Jump(bool jump)
    {
        if (jump)
        {
            _anim.SetBool("Jump", false);
        }
        else if (jump == false)
        {
            _anim.SetBool("Jump", true);
        }
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnimation");
    }
}
