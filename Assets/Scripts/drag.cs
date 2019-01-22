using UnityEngine;
using System.Collections;

public class drag : MonoBehaviour {

    float distance = 10;
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }


    //float distance = 10;
    //void OnTouchDrag()
    //{
    //    Vector3 touchPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, distance);
    //    Vector3 objPosition = Camera.main.ScreenToWorldPoint(touchPosition);
    //    transform.position = objPosition;
    //}

    //void OnTouchDrag()
    //{
    //    Vector3 touchPosition = new Vector3(Input.touch.position.x, Input.touches.position.y, transform.position.z);
    //    Vector3 objPosition = Camera.main.ScreenToWorldPoint(touchPosition);
    //    transform.position = objPosition;
    //}
}
