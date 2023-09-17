using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 defaultPosition;
    [SerializeField] private AnimationCurve moveCurve = new AnimationCurve();

    private void Start() {
        defaultPosition = this.transform.position;
    }

    private void Update() {
    }

    public void ResetPosition() {
        transform.position = defaultPosition;
    }

    private void BounceBack() {
        StartCoroutine(MoveCoroutine(defaultPosition));
    }
    
    private IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        float duration = 0.3f; // Duration of the move
        float timePassed = 0f;
        Vector3 startPosition = transform.position;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float normalizedTime = timePassed / duration;
            float curveValue = moveCurve.Evaluate(normalizedTime);

            transform.position = Vector3.Lerp(startPosition, targetPosition, curveValue);
            yield return null;
        }

        transform.position = targetPosition; // Ensure it reaches the exact target position
    }

    
    public void OnBeginDrag(PointerEventData eventData) {
        
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        BounceBack();
    }
}
