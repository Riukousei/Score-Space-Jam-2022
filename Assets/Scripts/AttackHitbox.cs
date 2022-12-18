using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{

    public float dmg;
    public PlayerAttacks PA;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy>().UpdateHealth(dmg);
            }
        }
    }
}
