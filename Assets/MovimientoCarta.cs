using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCarta : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 changedMousePosition;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        changedMousePosition = GetMousePos();
        Vector2 aux;
        aux.x = changedMousePosition.y;
        aux.y = changedMousePosition.z;
 
        changedMousePosition.z = aux.x;

        mousePosition = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}
