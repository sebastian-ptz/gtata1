using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinGathering : MonoBehaviour
{
    public Text score;
    public Text highScore;
    private int number = 0;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Coin(Clone)")
        {
            Destroy(col.gameObject);
            number += 1;
            score.text = number.ToString();

            if (number > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", number);
                highScore.text = number.ToString();
            }
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
