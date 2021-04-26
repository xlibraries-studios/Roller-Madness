using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public GameObject CoinPrefab;

    public int xPos; //this will hold the maximum and minimum value of x coordinates
    public int zPos; //this will hold the maximum and minimum value of y coordinates

    public int coinCount; //this will hold the value of number if coins to be sapwned

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoinDropper()); ;
    }

    IEnumerator CoinDropper()
    {
        while (coinCount > 0)
        {
            xPos = Random.Range(-9, 9);
            zPos = Random.Range(-9, 9);
            Instantiate(CoinPrefab, new Vector3(xPos, 1,zPos), Quaternion.identity);
            coinCount -= 1;
            yield return new WaitForSeconds(1.5f);
        }
    }
}
