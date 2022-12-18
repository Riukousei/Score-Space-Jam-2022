using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject particles;
    public float damageM;
    public float healthM;
    public float speedM;
    public Transform target;
    public float baseSpeed;
    public float baseHealth;
    public float baseDamage;

    public float health;
    public float damage;

    private float randomBaseSpeed;

    private PlayerAttacks Player;
    public bool canShoot=false;
    public int pointsWhenDie;
    private Score score;
    

    private float time=1000000;
    // Start is called before the first frame update
    void Start()
    {
        randomBaseSpeed = Random.Range(baseSpeed - baseSpeed/10, baseSpeed + baseSpeed/10);
        health = baseHealth * healthM;
        damage = (Mathf.Round(baseDamage * damageM));
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttacks>();
        score= GameObject.FindGameObjectWithTag("scoreboard").GetComponent<Score>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (canShoot == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, randomBaseSpeed * speedM * Time.deltaTime);
        }
        else
        {
            float dist = Vector3.Distance(target.position, transform.position);
            //check if it is within the range you set
            if (dist >= 6f)
            {
                //move to target(player) 
                transform.position = Vector2.MoveTowards(transform.position, target.position, randomBaseSpeed * speedM * Time.deltaTime);
            }
        }
    }
    public void UpdateHealth(float h)
    {
        health = health - h;
        if (health <= 0)
        {
            Instantiate(particles, this.transform.position,Quaternion.identity);
            Debug.Log("Particles?");
            health = 0;
            StartCoroutine(suicide());
            Player.extraAmmo();
            score.addPoints(pointsWhenDie);
        }

    }

    IEnumerator suicide()
    {
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            if (collision.collider.CompareTag("Player"))
            {
                Debug.Log("Golpee al pleyer");
                collision.collider.GetComponent<PlayerHealth>().UpdateHealth((int)damage);
                time = Time.time;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            if (collision.collider.CompareTag("Player"))
            {
                if (Time.time > time + 1)
                {
                    Debug.Log("Golpee al pleyer");
                    collision.collider.GetComponent<PlayerHealth>().UpdateHealth((int)damage);
                    time = Time.time;
                }

                
            }
        }
    }
}
