using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private GameObject attackArea;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject rotateObject;
    [SerializeField] public bool attacking = false;
    [SerializeField] public bool shooting = false;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject line;

    private Vector3[] pos;
    public float meleeDamage;
    public float shootDamage;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3[2];
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
        attackArea.GetComponent<AttackHitbox>().dmg = meleeDamage;
        attacking = true;
        attackArea.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        attackArea.SetActive(false);
        attacking = false;
    }


    //rutina de ataque disparo
    IEnumerator ShootAttack(Vector2 dir)
    {

       
        anim.SetTrigger("Shooting");
        yield return new WaitForSeconds(0.1f);
        var app = attackPoint.position;
        pos[0] = app;
        pos[1] = new Vector2(app.x, app.y) + 200 * dir;

        shooting = true;
        RaycastHit2D hit = Physics2D.Raycast(app,dir*20);
        Debug.DrawLine(attackPoint.position,pos[1], Color.white, 5f) ;
        if (hit.collider != null)
        {
            line.SetActive(true);

            if (hit.collider.CompareTag("Enemy"))
            {
                pos[1] = hit.collider.transform.position;
                hit.collider.GetComponent<Enemy>().UpdateHealth(shootDamage);
                Debug.Log(hit);
            }
        }
        else
        {
            line.SetActive(true);

            
        }
        line.GetComponent<LineRenderer>().SetPositions(pos);
        yield return new WaitForSeconds(0.1f);

        line.SetActive(false);

        yield return new WaitForSeconds(0.3f);

        shooting = false;
    }


}
