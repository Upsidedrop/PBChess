using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Renderer Renderer;
    [SerializeField]
    TileManager TileManager;
    int lastPos;
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
        if (Mathf.Abs(transform.position.x) > 4.6716 || Mathf.Abs(transform.position.y) > 4.6716||lastPos == (int)(((Mathf.Round((transform.position.x / 1.1679f) - 0.58395f) * 1.1679f) + 0.58395f) / 1.1679f + 4.5f
            + (((Mathf.Round(transform.position.y / 1.1679f - 0.58395f) * 1.1679f) + 0.58395f) / 1.1679f + 4.5f) * 8) - 8)
        {
            transform.position = new Vector2(
                (((lastPos % 8) - 5) * 1.1679f) + 0.58395f,
                ((((lastPos + 8)-(lastPos % 8))/8 - 5) * 1.1679f) + 0.58395f);
            Renderer.sortingOrder = 1;
            return;
        }
        TileManager.pieces[lastPos-1] = "None";
        transform.position = new Vector2(
             (Mathf.Round(transform.position.x / 1.1679f - 0.58395f) * 1.1679f) + 0.58395f,
            (Mathf.Round(transform.position.y/ 1.1679f - 0.58395f) * 1.1679f)+ 0.58395f);
        Renderer.sortingOrder = 1;
        print(((transform.position.x / 1.1679f + 4.5f
            + ((transform.position.y / 1.1679f + 4.5f) * 8) - 8)) - 1);
        TileManager.pieces[Mathf.RoundToInt(((transform.position.x / 1.1679f + 4.5f
            + ((transform.position.y / 1.1679f + 4.5f) * 8) - 8))-1)] = gameObject.name;
    }
    private void OnMouseDown()
    {
        lastPos = ((int)(((Mathf.Round((transform.position.x / 1.1679f) - 0.58395f) * 1.1679f) + 0.58395f) / 1.1679f + 4.5f
            + (((Mathf.Round(transform.position.y / 1.1679f - 0.58395f) * 1.1679f) + 0.58395f) / 1.1679f + 4.5f) * 8) - 8);
        print(lastPos);
    }
}
