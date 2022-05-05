using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    void Update()
    {
        //transform.LookAt(GameObject.FindWithTag("Player").transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            FindObjectOfType<LevelController>().Scored();
        }
    }
}
