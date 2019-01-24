using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float speed;
    public bool  IsActive;

    private int ScreenWidth;
    private int ScreenHeigth;

    private void Start() {
        ScreenWidth  = Screen.width;
        ScreenHeigth = Screen.height;
    }

    private void Update() {
        Vector3 CamPos = transform.position;
        if (Input.mousePosition.x <= 20) {
            CamPos.x -= Time.deltaTime * speed;
            //CamPos.z += Time.deltaTime * speed;
        }
        else
            if (Input.mousePosition.x >= ScreenWidth - 20) {
                CamPos.x += Time.deltaTime * speed;
                //CamPos.z -= Time.deltaTime * speed;
            }
            else
                if (Input.mousePosition.y <= 20) {
                    //CamPos.x -= Time.deltaTime * speed;
                    CamPos.z -= Time.deltaTime * speed;
                }
                else
                    if (Input.mousePosition.y >= ScreenHeigth - 20) {
                        //CamPos.x += Time.deltaTime * speed;
                        CamPos.z += Time.deltaTime * speed;
                    }

        if (IsActive)
            transform.position =
                new Vector3(Mathf.Clamp(CamPos.x, -40f, 40f), CamPos.y, Mathf.Clamp(CamPos.z, -30f, 45f));
    }
}