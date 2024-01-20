using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float moveDistance;
    [SerializeField] private float speed;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    public int health;
    public GameObject DroppedCoin;
    private void Awake()
    {
        leftEdge = transform.position.x - moveDistance;
        rightEdge = transform.position.x + moveDistance;
    }


    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
        if (health == 0)
        {
            Destroy(gameObject);
            Instantiate(DroppedCoin, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Player" && health > 0)
        //{
        //    collision.GetComponent<Health>().TakeDamage(damage);
        //}
        if (collision.tag == "Bullet")
        {
            damaged();
        }
    }
    IEnumerator Die()
    {
        animator.Play("enemy_die");
        transform.position = new Vector2(transform.position.x, yy);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        Instantiate(DroppedCoin, transform.position, transform.rotation);

        void health()
     }
}
