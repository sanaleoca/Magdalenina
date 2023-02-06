using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public GameObject selectedObject;
    public Rigidbody rb;

    public bool movible =true;

    private void Update()
    {
        if (movible)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (selectedObject == null)
                {
                    RaycastHit hit = CastRay();

                    if (hit.collider != null)
                    {
                        if (!hit.collider.CompareTag("drag"))
                        {
                            return;
                        }

                        selectedObject = hit.collider.gameObject;
                        rb = selectedObject.GetComponent<Rigidbody>();
                        rb.isKinematic = true;
                        //Cursor.visible = false;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0) && selectedObject != null)
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, 0.3f, worldPosition.z);
                rb.isKinematic = false;
                selectedObject = null;
                //Cursor.visible = true;
            }

            if (selectedObject != null)
            {

                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

                selectedObject.transform.position = new Vector3(worldPosition.x, .3f, worldPosition.z);

            }

        }
        else
        {
            movible = true;
        }
        
    }

    /*
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("drag")){
            rb.isKinematic = false;
            selectedObject = null;
            movible = false;
        }

    }
    */

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePositionFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePositionNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePositionNear, worldMousePositionFar - worldMousePositionNear, out hit);

        return hit;
    }


}
