using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Renderer Renderer;
    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
    }
    private void OnMouseDrag()
    {
        Renderer.sortingOrder = 2;
        transform.position = Camera.main.ScreenToWorldPoint(
                 new Vector3(Input.mousePosition.x,
                 Input.mousePosition.y)) + new Vector3(0, 0, 10);
    }
    private void OnMouseUp()
    {
       
        print(transform.position.y - 0.58395f);
        transform.position = new Vector2(
            (Mathf.Round(transform.position.x / 1.1679f - 0.58395f) * 1.1679f)+ 0.58395f,
            (Mathf.Round(transform.position.y/ 1.1679f - 0.58395f) * 1.1679f)+ 0.58395f);
        Renderer.sortingOrder = 1;
    }
}
