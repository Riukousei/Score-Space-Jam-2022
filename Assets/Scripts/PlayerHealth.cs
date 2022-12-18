using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    [Header("Se mide en ")]
    public float regenSpeed;

    private void Start()
    {
        StartCoroutine(regenerateHealth());
    }

    public void UpdateHealth(int h)
    {
        health = health - h;
        if (health <= 0)
        {
            health = 0;
            //acer cosas de matar jugador xd
            Debug.Log("Oh no he muerto");
        }

    }

    IEnumerator regenerateHealth()
    {


        yield return new WaitForSeconds(1);
    }
}
