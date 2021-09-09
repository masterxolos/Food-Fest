using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CamTrigger"))
        {
            camTransform.DOLocalMove(new Vector3(2.1f , 14.39f, 3.1f),3);   
        }
    }
}
