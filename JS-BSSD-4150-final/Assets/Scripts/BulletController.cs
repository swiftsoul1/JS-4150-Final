using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnBecameVisible()
    {
        //rb2d.AddForce(Vector3.forward * speed);
        rb2d.velocity = transform.up * speed;
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
