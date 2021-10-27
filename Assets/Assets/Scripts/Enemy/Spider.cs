using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Health -= 1;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);
        if (Health < 1)
        {
            Destroy(gameObject);
        }
        Debug.Log("Health " + Health);
    }
}
