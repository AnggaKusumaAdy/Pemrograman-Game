using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool isJump = true;
    bool isFall = true;
    bool isDead = false;
    bool isSlide = false;
    int idMove = 0;
    Animator anim;
    public float jump;
    public CapsuleCollider2D regularColl;
    public CapsuleCollider2D slideColl;
    //public CircleCollider2D attackColl;
    int health = 1;
    public GameObject flag;
    //public GameObject enemy1;
    //public GameObject enemy2;
    int enemycount = 2;
    

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        flag.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Idle();
            regularColl.enabled = true;
            slideColl.enabled = false;
            isSlide = false;
        }
        //if (Input.GetKey(KeyCode.F))
        {
            //Attack();
            //regularColl.enabled = true;
            //attackColl.enabled = false;
            //attackColl.enabled = false;
        }
        if(Data.score == 5 && enemycount == 0)
        {
           
        flag.SetActive(true);

        }
        Move();
        Dead();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isJump)
        {
            anim.ResetTrigger("jump");
            if (idMove == 0) anim.SetTrigger("idle");
            isJump = false;
        }
        if (isFall)
        {
           anim.ResetTrigger("fall");
           if (idMove == 0) anim.SetTrigger("idle");
           isFall = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetTrigger("jump");
        anim.SetTrigger("fall");
        anim.ResetTrigger("run");
        anim.ResetTrigger("idle");
        isJump = true;
        isFall = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Rune"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
            
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.tag.Equals("Enemy"))
        {
            
            if (isSlide == true)
            {
                Destroy(collision.gameObject);
                enemycount -= 1;
            }if(isSlide == false)
            {
                health -= 1;
                Dead();
            }
        }
        if (collision.transform.tag.Equals("Flag"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("WinScene");
        }
    }
    public void MoveRight()
    {
        idMove = 1;
    }

    public void MoveLeft()
    {
        idMove = 2;
    }

    public void Move()
    {
        if(idMove==1 && !isDead)
        {
            if (!isJump && !isFall) anim.SetTrigger("run");
            transform.Translate(1 * Time.deltaTime * 4f, 0, 0);
            transform.localScale = new Vector3(2, 2f, 2f);
        }

        if (idMove == 2 && !isDead)
        {
            if (!isJump && !isFall) anim.SetTrigger("run");
            transform.Translate(-1 * Time.deltaTime * 4f, 0, 0);
            transform.localScale = new Vector3(-2, 2f, 2f);
        }
    }

    public void Jump()
    {
        if (!isJump && !isDead)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump);
        }
    }
    public void Attack()
    {
        //anim.SetTrigger("attack");
        //regularColl.enabled = false;
        //attackColl.enabled = true;
        //StartCoroutine(Slash());
    }

    public void Slide()
    {
        if (isSlide = true && !isDead)
        {
            anim.SetTrigger("slide");
            regularColl.enabled = false;
            slideColl.enabled = true;
        }
    }
    public void Idle()
    {
        if (!isJump && !isFall)
        {
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.ResetTrigger("fall");
            anim.SetTrigger("idle");
        }
        idMove = 0;
    }

    
    private void Dead()
    {
        if (!isDead)
        {
            if(health == 0)
            {
                isDead = true;
                anim.SetTrigger("die");
                Destroy(this.gameObject,2.5f);
                StartCoroutine(Ending());
                //SceneManager.LoadScene("GameOver");
            }
        }
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("GameOver");
    }
}
