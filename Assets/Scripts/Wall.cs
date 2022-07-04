using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(Vector3.back * speed * GameManager.instance.gameSpeed * Time.deltaTime);
        if(transform.position.z < -22) Destroy(gameObject);
    }
}
