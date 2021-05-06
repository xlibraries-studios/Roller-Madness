using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Coin;
    public int xPos;
    public int zPos;
    public int coinCount = 20; // this will  hold the count of our coins

    private float currentTime = 0.0f; //time managed for the timer of the game
    private float startingTime = 20.0f; // maximum time for the timer of the game

    [SerializeField] TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PickupDrop());
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            //Time.timeScale = 0;
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator PickupDrop()
    {
        while (coinCount > 0)
        {
            xPos = Random.Range(-9, 9);
            zPos = Random.Range(-9, 9);
            Instantiate(Coin, new Vector3(xPos, 1, zPos), Quaternion.identity);
            coinCount--;
        }
        yield return new WaitForSeconds(0.5f);
    }

}
