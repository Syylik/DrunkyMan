using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public void StopSliding() => GetComponentInParent<Player>().isSliding = false;
}
