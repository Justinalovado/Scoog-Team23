using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 defaultPosition;
    private void Start() {
        defaultPosition = this.transform.position;
    }

    private void Update() {
    }

    public void resetPosition() {
        transform.position = defaultPosition;
    }
    
    public void OnBeginDrag(PointerEventData eventData) {
        
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        resetPosition();
    }
}
