using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{

    public float speed = 3;
    public GameObject bullePrefab;
    public Material flashMaterial;
    public Material defaultMaterial;
    
    Vector3 move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move += (new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move += (new Vector3(0, -1, 0));
        }
        move = move.normalized;
        if (move.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (move.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (move.magnitude > 0)
        {
            GetComponent<Animator>().SetTrigger("move");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Stop");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        void Shoot()
        {

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            worldPosition -= (transform.position + new Vector3(0, -0.5f, 0));

            GameObject newBullet = GetComponent<ObjectPool>().Get();
            if(newBullet != null)
            {
                newBullet.transform.position = transform.position + new Vector3(0,-0.5f);
                            newBullet.GetComponent<Bullet>().Direction = worldPosition;
            }
        }
    }
     private void FixedUpdate()
     {
        transform.Translate(move * speed * Time.fixedDeltaTime);
     }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (GetComponent<Character>().Hit(1))
            {
                //살아있다
                Flash();
            }
            else
            {
                //죽은상태
                Die();
            }
        }
    }
    void Flash()
    {
        GetComponent<SpriteRenderer>().material = flashMaterial;
        Invoke("AfterFlash", 0.3f);
    }

    void AfterFlash()
    {
        GetComponent<SpriteRenderer>().material = defaultMaterial;
    }


    void AfterDying()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    void Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
        Invoke("AfterDying", 0.875f);
    }
}



  