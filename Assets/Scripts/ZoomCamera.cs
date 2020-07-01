
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private float zoomMin = 1;
    private float zoomMax = 8;
    [SerializeField] private GameObject plane;

	private Vector3 touch;

    Painter painter = new Painter();

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.touchCount == 1 &&
            (painter.hit.transform.tag == "zoom" || painter.hit.transform.parent.tag == "zoom"))
        {
            touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch toucheOne = Input.GetTouch(1);

            Vector2 toucheZeroLastPos = touchZero.position - touchZero.deltaPosition;
            Vector2 toucheOneLastPos = toucheOne.position - toucheOne.deltaPosition;

            float distTouch = (toucheZeroLastPos - toucheOneLastPos).magnitude;
            float currentDistTouch = (touchZero.position - toucheOne.position).magnitude;

            float difference = currentDistTouch - distTouch;

            Zoom(difference * 0.01f);
        }

        else if (Input.GetMouseButton(0) && Input.touchCount==1 &&
                 (painter.hit.transform.tag == "zoom" || painter.hit.transform.parent.tag == "zoom"))
        {
            Vector3 direction = touch - camera.ScreenToWorldPoint(Input.mousePosition);
            camera.transform.position += direction;
            
        }
        #region borders
        if (camera.transform.position.y > 4)
        {
            Vector3 dopVector = new Vector3(0,camera.transform.position.y-4,0);
            camera.transform.position -= dopVector;
        }
        if (camera.transform.position.y < -3.6)
        {
            Vector3 dopVector = new Vector3(0, camera.transform.position.y + (float)3.6, 0);
            camera.transform.position -= dopVector;
        }
        if (camera.transform.position.x > 5)
        {
            Vector3 dopVector = new Vector3(camera.transform.position.x - 5,0, 0);
            camera.transform.position -= dopVector;
        }
        if (camera.transform.position.x < -5)
        {
            Vector3 dopVector = new Vector3(camera.transform.position.x + 5,0, 0);
            camera.transform.position -= dopVector;
        }
        #endregion
    }

    void Zoom(float increment)
    {
        //Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomMin,zoomMax);

        Vector3 changeScale = new Vector3(increment, increment, increment);
    }
}
