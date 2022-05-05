using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawn;
    public float timeSinceLastShot = 0.5f;
    public float timeBetweenShots = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;//Update counter

    }
    public void Shoot()
    {
        //If it's been long enough to shoot again
        if(timeSinceLastShot > timeBetweenShots)
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z -= 90;//model rotation off by -90 always
            GameObject bullet = Instantiate(Resources.Load("Bullet"), bulletSpawn.transform.position, Quaternion.Euler(rotationVector)) as GameObject;
            timeSinceLastShot = 0f;//Reset the timer
        }
    }
}
