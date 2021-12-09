using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontrolBola : MonoBehaviour
{
    Text scoreUI;
    Text livesUI;
    int lives;
    int scoreP;
    public int force;
    Rigidbody2D rigid;
    GameObject panelLevel1;
    GameObject panelGameOver;
    Text txGameOver;
    Text txSelesai;
    public AudioClip hitPaddle;
    public AudioClip hitStars;
    private AudioSource MediaPlayerPaddle;
    private AudioSource MediaPlayerStars;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, 2).normalized;
        rigid.AddForce(arah * force);
        scoreP = 0;
        lives = 3;
        scoreUI = GameObject.Find("score").GetComponent<Text>();
        livesUI = GameObject.Find("nyawa").GetComponent<Text>();

        panelLevel1 = GameObject.Find("PanelLevel1");
        panelLevel1.SetActive(false);
        panelGameOver = GameObject.Find("PanelGameOver");
        panelGameOver.SetActive(false);

        MediaPlayerPaddle = gameObject.AddComponent<AudioSource>();
        MediaPlayerPaddle.clip = hitPaddle;

        MediaPlayerStars = gameObject.AddComponent<AudioSource>();
        MediaPlayerStars.clip = hitStars;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
  
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "BatasBawah")
        {
            ResetBall();
            Vector2 arah = new Vector2(0, 2).normalized;
            rigid.AddForce(arah * force);
            lives -= 1;
            TampilkanNyawa();
            
            if(lives <= 0)
            {
                panelGameOver.SetActive(true);
                Time.timeScale = 0;
                txGameOver = GameObject.Find("GameOver").GetComponent<Text>();
                Destroy(gameObject);
                return;
            }

        }
        
        if(coll.gameObject.name == "paddle")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 30f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 1);
            MediaPlayerPaddle.Play();
        }

        if(coll.gameObject.name == "bintang")
        {
            scoreP += 4;
            TampilkanScore();
            MediaPlayerStars.Play();
        }

        if(coll.gameObject.name == "bintang2")
        {
                scoreP += 2;
                TampilkanScore();
                MediaPlayerStars.Play();
        }

        if (coll.gameObject.name == "bintang3")
        {
            scoreP += 1;
            TampilkanScore();
            MediaPlayerStars.Play();
        }

        if (scoreP >= 100)
        {
            panelLevel1.SetActive(true);
            Time.timeScale = 0;
            txSelesai = GameObject.Find("Level Selesai").GetComponent<Text>();
            return;
        }
    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0, -3);
        rigid.velocity = new Vector2(0, -3);
    }

    void TampilkanScore()
    {
        Debug.Log("Score: " + scoreP);
        scoreUI.text = "Score: " + scoreP + "";
    }

    void TampilkanNyawa()
    {
        Debug.Log("Nyawa: " + lives);
        livesUI.text = "Lives: " + lives + "";
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("lives");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        
    }
}
