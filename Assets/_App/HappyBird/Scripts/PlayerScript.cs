using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private bool dead => GameManager.Instance.Heart <= 0;
    public AudioClip[] auClip;
    public GameObject fire;
    public SpriteRenderer chim;
    private bool nhapnhay;

    void Start()
    {
        GetComponent<AudioSource>().clip = auClip[1];
    }

    void JumpBird()
    {
        fire.SetActive(true);
        GetComponent<AudioSource>().Play();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!dead)
        {
            if (col.tag == "Score")
            {
                GameManager.Instance.Score++;
                Destroy(col.gameObject);
            }
            else if (col.tag == "Finish" && !nhapnhay)
            {
                GetComponent<AudioSource>().clip = auClip[0];
                GetComponent<AudioSource>().Play();
                Vacham();
                GameManager.Instance.LoseGame();
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !dead)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null)
            {
                JumpBird();
            }
        }
    }

    void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Vacham()
    {
        StartCoroutine(Nhapnhay());

        GetComponent<AudioSource>().Play();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
        var transformPosition = transform.position;
        transformPosition.y = 0;
        transform.position = transformPosition;
        nhapnhay = true;

        IEnumerator Nhapnhay()
        {
            SetA(0);
            yield return new WaitForSeconds(0.1f);SetA(256);
            yield return new WaitForSeconds(0.1f);SetA(0);
            yield return new WaitForSeconds(0.1f);SetA(256);
            yield return new WaitForSeconds(0.1f);SetA(0);
            yield return new WaitForSeconds(0.1f);SetA(256);
            nhapnhay = false;
        }
    }

    private void SetA(int value)
    {
        var chimColor = chim.color;
        chimColor.a = value;
        chim.color = chimColor;
    }
}