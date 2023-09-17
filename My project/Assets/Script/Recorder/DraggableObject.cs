using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 defaultPosition;
    [SerializeField] private AnimationCurve moveCurve = new AnimationCurve();
    [SerializeField] private AnimationCurve shrinkCurve = new AnimationCurve();
    private void Start() {
        defaultPosition = this.transform.position;
    }

    private void Update() {
    }

    public void ResetPosition() {
        transform.position = defaultPosition;
        transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
    }

    private void BounceBack() {
        StartCoroutine(MoveCoroutine(defaultPosition));
        StartCoroutine(ShrinkCoroutine(1));
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
    
    private IEnumerator ShrinkCoroutine(float targetScaleY)
    {
        float duration = 0.15f; // Duration of the scaling
        float timePassed = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = new Vector3(transform.localScale.x, targetScaleY, transform.localScale.z);

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float lerpValue = shrinkCurve.Evaluate(timePassed / duration);
            
            transform.localScale = Vector3.Lerp(startScale, targetScale, lerpValue);
            yield return null;
        }

        transform.localScale = targetScale; // Ensure it reaches the exact target scale
    }
    
    public void OnBeginDrag(PointerEventData eventData) {
        StartCoroutine(ShrinkCoroutine(0.2f));
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        BounceBack();
    }
}
