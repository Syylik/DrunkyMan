using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * GameManager.instance.gameSpeed * Time.deltaTime);
        if(transform.position.z < -25.5f)
        {
            Instantiate(gameObject, new Vector3(0, 0, 35.1f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
