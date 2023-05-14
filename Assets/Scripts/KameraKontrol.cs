using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    [SerializeField] private Transform _ballT;

    private void LateUpdate()
    {
        if (_ballT.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, _ballT.position.y, transform.position.z);
        }
    }
}//class
