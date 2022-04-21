using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollection : MonoBehaviour
{
    [SerializeField] private Text coinCounterText;
    private int coinCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCounter++;
            coinCounterText.text = coinCounter.ToString();
        }
    }
}
