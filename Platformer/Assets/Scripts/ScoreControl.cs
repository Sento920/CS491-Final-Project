using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreControl : MonoBehaviour {

    public static int CoinsCollected;
    public static int Score;
    public Text ScoreText;
    public Text CoinText;

    // Use this for initialization
    void Start () {
        CoinsCollected = 0;
        Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    //Update Score text
	}

    static void CoinCollected()
    {
        CoinsCollected++;
    }

    static void EnemyDestroyed(int value)
    {
        Score += value;
    }

    void UpdateScore()
    {
        ScoreText.text = ("Score: " + Score);
        CoinText.text = ("Coins: " + CoinsCollected);
    }
}
