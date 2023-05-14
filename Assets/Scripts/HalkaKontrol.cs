using UnityEngine;

public class HalkaKontrol : MonoBehaviour
{
    public float donmeHizi;
    public bool solaDon = true;

    private void FixedUpdate()
    {
        if (solaDon)
        {
            transform.Rotate(0f, 0f, donmeHizi * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0f, 0f, -donmeHizi * Time.deltaTime);
        }
    }

}//class
