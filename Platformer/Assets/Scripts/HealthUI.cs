using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthUI : MonoBehaviour {

    public Sprite Filled;
    public Sprite Empty;
    public int HP;
    public Image h1;
    public Image h2;
    public Image h3;
    private float waitTime;

    // Use this for initialization
    void Start() {
        HP = 3;
        h1.sprite = Filled;
        h2.sprite = Filled;
        h3.sprite = Filled;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Time.time > waitTime)
        {
            if (HP == 3 && other.gameObject.CompareTag("Enemy"))
            {
                h3.sprite = Empty;
                HP--;
                waitTime = Time.time + 1f;
            }
            else if (HP == 2 && other.gameObject.CompareTag("Enemy"))
            {
                h2.sprite = Empty;
                HP--;
                waitTime = Time.time + 1f;
            }
            else if (HP == 1 && other.gameObject.CompareTag("Enemy"))
            {
                h1.sprite = Empty;
                HP--;
                waitTime = Time.time + 1f;
                print("YOU DED.");
                Application.LoadLevel("GameOver");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            h1.sprite = h3.sprite = h2.sprite = Empty;
            print("YOU DED.");
            Application.LoadLevel("GameOver");
        }
    }




}