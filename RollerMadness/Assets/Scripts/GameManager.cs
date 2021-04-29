using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Coin;
    public int xPos;
    public int zPos;
    public int coinCount = 20; // this will  hold the count of our coins

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PickupDrop());
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
