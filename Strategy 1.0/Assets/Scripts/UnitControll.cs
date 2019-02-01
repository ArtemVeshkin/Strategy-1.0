using UnityEngine;

public class UnitControll : MonoBehaviour {
    private Vector3  TargetPosition;
    public  float    Duration;
    private bool     IsRunning;
    private Animator anim;
    public  bool     IsSelected;

    private void Start() {
        anim = GetComponentInChildren<Animator>();
        GameObject  Controller = GameObject.FindGameObjectWithTag("GameController");
        ResControll Resources  = Controller.GetComponent<ResControll>();
        Resources.NewUnit(gameObject);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1) && IsSelected) {
            Ray        ray;
            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                IsRunning      = true;
                TargetPosition = hit.point;
            }
        }

        if (IsRunning && !Mathf.Approximately(transform.position.magnitude, TargetPosition.magnitude)) {
            transform.LookAt(TargetPosition);
            transform.position = Vector3.Lerp(transform.position, TargetPosition,
                                              1 / (Duration * (Vector3.Distance(transform.position, TargetPosition))));
            CheckAnimation();
        }
        else
            if (IsRunning && Mathf.Approximately(transform.position.magnitude, TargetPosition.magnitude)) {
                IsRunning = false;
                CheckAnimation();
            }
    }

    private void CheckAnimation() {
        if (IsRunning && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            anim.Play("Running");
        }
        else
            if (!IsRunning && anim.GetCurrentAnimatorStateInfo(0).IsName("Running")) {
                anim.Play("Idle");
            }
    }
}