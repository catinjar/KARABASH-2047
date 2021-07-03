using UnityEngine;

public class Aim : MonoBehaviour
{
    private void Update()
    {
        var aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPosition.z = 0;
        
        transform.position = aimPosition;
    }
}
