using UnityEngine;
[System.Serializable]
public class ParallaxLayer
{
    [SerializeField] private Transform background;
    [SerializeField] private float ParallaxMultiplier;

    private float imageFullWidth;
    private float imageHalfWidth;

    public void CalculateImageWidth()
    {
        imageFullWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        imageHalfWidth = imageFullWidth / 2;
    }

    public void Move(float distanceToMove)
    {
        background.position += Vector3.right * (distanceToMove * ParallaxMultiplier);
    }

    public void LoopBackround(float cameraLeftEdge, float cameraRightEdge) //зачем указывать значения в скобках?
    {
        float imageRightEdge = background.position.x + imageHalfWidth;
        float imageLeftEdge = background.position.x - imageHalfWidth;

        if (imageRightEdge < cameraLeftEdge)
            background.position += Vector3.right * imageFullWidth;
        else if (imageLeftEdge > cameraRightEdge)
            background.position += Vector3.right * -imageFullWidth;
    }


}
