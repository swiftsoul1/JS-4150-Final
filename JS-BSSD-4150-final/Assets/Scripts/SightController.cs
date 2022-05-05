using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //find current gun
            if (transform.parent.GetComponentInChildren<PistolController>() != null)
            {
                //shoot
                transform.parent.GetComponentInChildren<PistolController>().Shoot();
            }
        }
    }
    
}
