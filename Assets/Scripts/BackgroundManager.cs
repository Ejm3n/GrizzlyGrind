using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public float Speed;
    [SerializeField] private float xCoordToRespawn = -27f;
    // Update is called once per frame
    void Update()
    {
        if( !GameManager.Instance.GAMEOVER)
            transform.Translate(Vector2.left*Speed*0.01f);
        if (transform.position.x <= xCoordToRespawn )
            transform.position = Vector2.zero;
    }
}
