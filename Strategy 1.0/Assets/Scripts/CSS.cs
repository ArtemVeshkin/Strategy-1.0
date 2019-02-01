using UnityEngine;
using UnityEngine.UI;

public class CSS : MonoBehaviour {
    public Text ResourceText;
    public RawImage   Minimap;
    public GameObject ResourcePanel;

    public float TextFontSize;

    public float MinimapWidth;
    public float MinimapHeight;
    public float MinimapX;
    public float MinimapY;

    public float PanelWidth;
    public float PanelHeight;
    public float PanelX;
    public float PanelY;

    private int width;
    private int height;

    private void Start() {
        width  = Screen.width;
        height = Screen.height;
        Resize();
    }

    private void Update() {
        if (Screen.width == width && Screen.height == height) return;
        width  = Screen.width;
        height = Screen.height;
        Resize();
    }

    private void Resize() {
        ResourceText.fontSize = Mathf.RoundToInt(width * TextFontSize);

        Minimap.rectTransform.position = new Vector3(width * MinimapX, height * MinimapY, 0);
    }
}