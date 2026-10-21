using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public Transform T;
    
    public void GetBumped()
    {
        T.position = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 3.5f), 0);
    }
}
//This destroys the coin
//Destroy(gameObject);