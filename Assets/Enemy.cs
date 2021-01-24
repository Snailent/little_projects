using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    
    private float Timebtwshot;
    public float startTimebtwshot;
    public Slider healthbar;

    public GameObject projectile;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Timebtwshot = startTimebtwshot;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        */

        if (Timebtwshot <= 0)
        {

            Instantiate(projectile, transform.position, Quaternion.identity);
            Timebtwshot = startTimebtwshot;

        }
        else
        {
            Timebtwshot -= Time.deltaTime;
        }
        
    }
}