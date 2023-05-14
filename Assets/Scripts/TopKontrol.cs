using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float ziplamaKuvveti = 3f;
    private bool _isTouched = false;

    public string mevcutRenk;
    public Color topunRengi;
    public Color turkuaz, sari, pembe, mor;
    private static string _colorBefore;

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private GameObject _warningText;

    public static bool isStart = false;
    public static int score = 0;
    private int _highScore;

    public GameObject halka, renkTekeri;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreText.text = "Best: " + _highScore;
        _scoreText.text = "Score: " + score;
        RastgeleRenkBelirle();
        Time.timeScale = 0f;
        isStart = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isStart)
        {
            StartGame();
        }
        if (!isStart)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            _isTouched = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isTouched = false;
        }
        FallCheck();
    }
    private void FixedUpdate()
    {
        if (!isStart)
            return;

        if (_isTouched)
        {
            _rb.velocity = Vector2.up * ziplamaKuvveti;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RenkTekeri")
        {
            RastgeleRenkBelirle();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != mevcutRenk && collision.tag != "PuanArttirici" && collision.tag != "RenkTekeri")
        {
            GameOver();
        }
        if (collision.tag == "PuanArttirici")
        {
            score += 5;
            _scoreText.text = "Score: " + score;
            Destroy(collision.gameObject);

            Instantiate(halka, new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), Quaternion.identity);
            Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 11.5f, transform.position.z), Quaternion.identity);
        }
    }
    void RastgeleRenkBelirle()
    {
        while (true)
        {
            int rastgeleSayi = Random.Range(0, 4);

            switch (rastgeleSayi)
            {
                case 0:
                    mevcutRenk = "Turkuaz";
                    topunRengi = turkuaz;
                    break;

                case 1:
                    mevcutRenk = "Sari";
                    topunRengi = sari;
                    break;

                case 2:
                    mevcutRenk = "Pembe";
                    topunRengi = pembe;
                    break;

                case 3:
                    mevcutRenk = "Mor";
                    topunRengi = mor;
                    break;
            }

            if(_colorBefore != mevcutRenk)
            {
                _colorBefore = mevcutRenk;
                break;
            }
        }

        GetComponent<SpriteRenderer>().color = topunRengi;
    }

    private void FallCheck()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.y > Screen.height || screenPosition.y < 0)
            GameOver();
    }

    private void GameOver()
    {
        if (score > _highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StartGame()
    {
        isStart = true;
        Time.timeScale = 1f;
        _warningText.SetActive(false);
    }

}//class
