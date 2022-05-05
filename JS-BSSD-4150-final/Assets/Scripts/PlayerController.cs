using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject gun;
    Rigidbody2D m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if click, shoot gun
        if (Input.GetMouseButtonDown(0))
        {
            //find current gun
            if (GetComponentInChildren<PistolController>() != null)
            {
                //shoot
                GetComponentInChildren<PistolController>().Shoot();
            }
        }
        //find mouse xy, turn towards it
        //https://oxmond.com/how-to-make-a-character-look-at-the-mouse/
        //changed angle to mtch my misritation
        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) - 270f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }
    void FixedUpdate()
    {
        //Store user input as a movement vector
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 m_Input = new Vector3(h, v, 0);
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * 5.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            FindObjectOfType<LevelController>().ResetLevel();
        }
        if (collision.gameObject.tag == "Exit")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            FindObjectOfType<LevelController>().NextLevel();
        }
    }
}
