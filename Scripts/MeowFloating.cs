using UnityEngine;
using UnityEngine.UI;

public class MeowFloating : MonoBehaviour //This script is used for the cat at the menu scene.
{
    public RectTransform canvasRectTransform;
    public float moveSpeed = 300.0f;

    private Image image;
    private RectTransform rectTransform;
    private Vector3 targetPosition;

    void Awake() //Call the image (Cat sprite) and make ot transformable.
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition; //Find mouse position.

        //Make the mouse position from the screen to the canvas.
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, mousePos, null, out localPoint);

        targetPosition = localPoint; //Make the position be a local point of the canvas.
        rectTransform.localPosition = Vector3.MoveTowards(rectTransform.localPosition, targetPosition, moveSpeed * Time.deltaTime); //Move sprite to mouse position.
    }
}
