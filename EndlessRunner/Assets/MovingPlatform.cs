using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool moveRigth;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float speed = 5f;
  


    // Start is called before the first frame update
    void Start()
    {

        startPoint = transform.position;
        endPoint = startPoint + movement;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
    }
}
