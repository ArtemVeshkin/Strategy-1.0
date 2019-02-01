using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResControll : MonoBehaviour {
    public Text ResourseText;

    public int              iron;
    public int              wood;
    public int              stone;
    public int              gold;
    public List<GameObject> Units;

    private void Update() {
        UpdateResources();
    }

    private void UpdateResources() {
        ResourseText.text = "Iron: " + iron + " Wood: " + wood + " Stone: " + stone + " Gold: " + gold;
    }

    public void NewUnit(GameObject Unit) {
        Units.Add(Unit);
    }
}