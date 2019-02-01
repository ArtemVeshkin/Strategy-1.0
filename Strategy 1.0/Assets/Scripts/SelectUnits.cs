using UnityEngine;

public class SelectUnits : MonoBehaviour {
    public Texture SelectTexture;

    private Ray         ray;
    private RaycastHit  hit;
    private Vector3     MouseStartPosition, SelectionStartPoint, SelectionEndPoint;
    private float       MouseX,             MouseY,              SelectionHeight, SelectWidth;
    private bool        Selecting;
    private ResControll Resources;

    private void Start() {
        Resources = GetComponent<ResControll>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Selecting          = true;
            MouseStartPosition = Input.mousePosition;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                SelectionStartPoint = hit.point;
            }
        }

        MouseX          = Input.mousePosition.x;
        MouseY          = Screen.height         - Input.mousePosition.y;
        SelectWidth     = MouseStartPosition.x  - MouseX;
        SelectionHeight = Input.mousePosition.y - MouseStartPosition.y;

        if (Input.GetMouseButtonUp(0)) {
            Selecting = false;
            DeselectAll();

            if (MouseStartPosition == Input.mousePosition) { //Одиночный выбор(клик)
                SingleSelect();
            }
            else { //Выделение
                MultiSelect();
            }
        }
    }

    private void OnGUI() {
        if (Selecting) {
            GUI.DrawTexture(new Rect(MouseX, MouseY, SelectWidth, SelectionHeight), SelectTexture);
        }
    }

    private void DeselectAll() {
        foreach (GameObject Unit in Resources.Units) {
            Unit.GetComponent<UnitControll>().IsSelected = false;
        }
    }

    private void SingleSelect() {
        if (hit.collider.gameObject.tag == "Player") {
            hit.collider.gameObject.GetComponentInParent<UnitControll>().IsSelected = true;
        }
    }

    private void MultiSelect() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            SelectionEndPoint = hit.point;
        }

        SelectHightlighted();
    }

    private void SelectHightlighted() {
        foreach (GameObject Unit in Resources.Units) {
            float x = Unit.transform.position.x;
            float z = Unit.transform.position.z;

            if ((x > SelectionStartPoint.x && x < SelectionEndPoint.x) ||
                (x < SelectionStartPoint.x && x > SelectionEndPoint.x)) {
                if ((z > SelectionStartPoint.z && z < SelectionEndPoint.z) ||
                    (z < SelectionStartPoint.z && z > SelectionEndPoint.z)) {
                    Unit.GetComponent<UnitControll>().IsSelected = true;
                }
            }
        }
    }
}