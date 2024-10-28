using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform A;
    [SerializeField] public Transform B;

   
    private Animator anim;
    private Vector3 currentPoint;
    public float speed;

    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        currentPoint = B.position;
    }

    private void Update()
    {
        if (transform.position == A.position)
        {
            currentPoint = B.position;
            spr.flipX = false;
        }
        else if (transform.position == B.position)
        {
            currentPoint = A.position;
            spr.flipY = true;
        }


        transform.position = Vector2.MoveTowards(transform.position, currentPoint, speed*Time.deltaTime);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().KillPlayer();
        }
    }
}
