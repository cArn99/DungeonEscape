using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Vector3 currentTarget;
    [SerializeField]
    protected GameObject playerObj;
    protected Transform playerPos;
    protected Transform enemyPos;
    protected bool isHit = false;
    protected float distance;

    public virtual void Init()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        playerPos = playerObj.GetComponent<Transform>();
        enemyPos =GetComponent<Transform>();
    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        distance = Vector3.Distance(playerPos.position, enemyPos.position);

        

        if (distance > 2f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        if (isHit)
        {
            FacePlayer();
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        if (isHit == false)
        {
            Movement();
        }
    }
    public virtual void FacePlayer()
    {
        Vector3 direction = playerPos.position - enemyPos.position;
        if (direction.x > 0)
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0)
        {
            sprite.flipX = true;
        }
    }
    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else if (currentTarget == pointB.position)
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);


    }
}
