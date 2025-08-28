using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("Coin Pickup");
            PlayerManager.numberOfCoins += 1;
          //  Debug.Log("Coins:"+PlayerManager.numberOfCoins); 
            Destroy(gameObject);
        }
    }
}
 