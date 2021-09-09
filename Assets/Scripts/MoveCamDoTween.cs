using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamDoTween : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] Transform collected;
    

    private void OnTriggerEnter(Collider other)
    {
        int i = 0;
        if (other.gameObject.CompareTag("camTrigger"))
        {
            Debug.Log("Çarpıştı");
            camTransform.DOLocalMove(new Vector3(1.4f, 11.58f, -11.13f), 1);
            
            collected.localPosition = new Vector3(-1.25f, -9.38f, 0);
            //collected.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            collected.DOScale(0.08f, 0);
            //collected.DOLocalMove(new Vector3(-1.25f, -9.38f, 0), 0);
            
            camTransform.DORotate(new Vector3(1.72f, 0, 0),1);
        }
    }
}
