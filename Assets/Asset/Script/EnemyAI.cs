using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public bool iden = true;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }

    //Die
    void FixedUpdate()
    {
       if(Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            speed = 0;
        } else if(Vector2.Distance(transform.position, target.position) < -stoppingDistance)
        {
            speed = 0;
        }
    //Hidden
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            if (Player.rend.sortingOrder == 0 && Vector2.Distance(transform.position, target.position) < 5 )
            {
                speed = 1;
                iden = false;
            } else if(Player.rend.sortingOrder > 0 && Vector2.Distance(transform.position, target.position) < 6)
            {
                speed = 4;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } else {
                speed = 4;
            }
        }
    }
}
