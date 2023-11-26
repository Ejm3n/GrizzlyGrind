using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] private int minSize;
    [SerializeField] private int maxSize;

    private void OnEnable()
    {
        transform.localScale = new Vector3(Random.Range(minSize,maxSize),transform.localScale.y,1);
    }


}
