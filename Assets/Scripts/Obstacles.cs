using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacles : MonoBehaviour
{
    public Animator ObstacleAnimator;
    public Transform obstacleTransform;
    public float targetPosZ;

    public void Start()
    {
        targetPosZ = transform.localPosition.z - 2;
    }

    public void MoveObstacle()
    {
        
        ObstacleAnimator.enabled = true;
        obstacleTransform.DOLocalMoveZ(targetPosZ, 1);

    }
    
}
