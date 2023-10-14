using UnityEngine;
using UnityEngine.UI;

public class BackgroundRoll : MonoBehaviour
{
    public float speed = 0.1f; // Speed of the scrolling effect
    private RawImage rawImage;
    private Rect uvRect;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        uvRect = rawImage.uvRect;
    }

    void Update()
    {
        uvRect.x += speed * Time.deltaTime;
        rawImage.uvRect = uvRect;
    }
}
