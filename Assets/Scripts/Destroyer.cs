using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private int toothArrayIndex = 0;

    [SerializeField] private GameObject collectorGameObject;
    [SerializeField] private Collector collector;
    // Start is called before the first frame update
    void Start()
    {
        collectorGameObject = GameObject.Find("Collector");
        collector = collectorGameObject.GetComponent<Collector>();
    }

    
}
