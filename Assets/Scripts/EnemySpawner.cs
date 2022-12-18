using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemigos en orden , debil, fuerte, disparador")]
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float time;

    private float p1=90, p2=10, p3=0;
    private float n1 = 4;
    private float damageM;
    private float healthM;
    private float speedM;

    private Transform target;

    private void Start()
    {
        StartCoroutine(aumentarProbabilidades());
        StartCoroutine(spawneador());

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Spawnear(int i,bool b)
    {
        
        var j = Random.Range(0, spawnPoints.Length);

        damageM = 1+(Mathf.RoundToInt(Time.time)+1)/120; 
        healthM = 1 + (Mathf.RoundToInt(Time.time) + 1) / 60;
        speedM = 1 + (Mathf.RoundToInt(Time.time) + 1) / 180;

        var enemigo=Instantiate(enemigos[i], spawnPoints[j]);
        enemigo.GetComponent<Enemy>().damageM = damageM;
        enemigo.GetComponent<Enemy>().healthM = healthM;
        enemigo.GetComponent<Enemy>().speedM = speedM;
        enemigo.GetComponent<Enemy>().target = target;
        enemigo.GetComponent<Enemy>().canShoot = b;
    }

    public void Probabilidades()
    {
        var r = Random.Range(0, p1 + p2 + p3);
        if (r < p1)
        {
            Spawnear(0,false);
        }
        else if(r>p1 && r <= p1 + p2)
        {
            Spawnear(1,false);
        }
        else if (r>p1+p2 && r <= p1 + p2 + p3)
        {
            Spawnear(2,true);
        }
     
    }

    IEnumerator aumentarProbabilidades()
    {
        p2 =Mathf.RoundToInt( p2 + 2 + ((Mathf.RoundToInt(Time.time) + 1) / 60));
        p3 =Mathf.RoundToInt( p3 + 3 + ((Mathf.RoundToInt(Time.time) + 1) / 120));
        yield return new WaitForSeconds(10);
        StartCoroutine(aumentarProbabilidades());
    }

    IEnumerator spawneador()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < n1; i++)
        {
            Probabilidades();
            yield return new WaitForEndOfFrame();
        }
        n1=(n1+ ((Mathf.RoundToInt(Time.time) + 1) / 14));
        yield return new WaitForSeconds(20);
        StartCoroutine(spawneador());
    }
}
