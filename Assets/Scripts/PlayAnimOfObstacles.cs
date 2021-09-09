using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOfObstacles : MonoBehaviour
{
    public Obstacles obstacles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collector"))
        {
            obstacles.MoveObstacle();
        }
    }

}
