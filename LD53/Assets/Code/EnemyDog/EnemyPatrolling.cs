using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour

{
    public float speed = 2f;
    public Transform[] waypoints;
    public bool isMovingRight = true;

    private int currentWaypointIndex = 0;

    private float startPos;
    private void Awake() {
        startPos = this.transform.position.x;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            if (isMovingRight)
            {

                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 2;
                    isMovingRight = false;
                }
            }
            else 
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1;
                    isMovingRight = true;
                }
            }
        }

        if (isMovingRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}




