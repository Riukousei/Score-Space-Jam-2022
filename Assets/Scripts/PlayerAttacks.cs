using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private GameObject attackArea;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject rotateObject;
    [SerializeField] public bool attacking=false;
    [SerializeField] public bool shooting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calculamos la direccion en la que esta puesto el mouse y la convertimos en una rotacion en grados
        var dir = ( Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.gameObject.transform.position ).normalized;
        var rotZ = (Mathf.Atan2(dir.y, dir.x))*Mathf.Rad2Deg;
        rotateObject.transform.rotation = Quaternion.Euler(0, 0,rotZ);

        //Usamos esa rotacion para saber si voltear el sprite del player
        if (rotZ>90 || rotZ < -90)
        {
            this.GetComponent<SpriteRenderer>().flipX=false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX=true;
        }

        //Checamos por el input del mouse para saber si atacar
        if (Input.GetMouseButtonDown(0) && attacking==false && shooting==false)
        {
            StartCoroutine(MeleeAttack());
        }
        if (Input.GetMouseButtonDown(1) && attacking == false && shooting == false)
        {
            StartCoroutine(ShootAttack(dir));
        }
    }

    //Rutina de ataque melee
    IEnumerator MeleeAttack()
    {
        attacking = true;
        attackArea.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        attackArea.SetActive(false);
        attacking = false;
    }


    //rutina de ataque disparo
    IEnumerator ShootAttack(Vector2 dir)
    {
        shooting = true;
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position,dir);
        Debug.DrawLine(attackPoint.position,new Vector2(attackPoint.position.x,attackPoint.position.y)+10*dir, Color.white, 5f);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                //Cosas cuando el rayo le pega
            }
        }
        yield return new WaitForSeconds(0.5f);

        shooting = false;
    }


}
