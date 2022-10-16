using UnityEngine;

public class ScreenTeleport
{
    private float _borderY => Camera.main.orthographicSize + 0.5f;
    private float _borderX => Camera.main.aspect * _borderY;

    public void BorderCrossing(Transform movingObject)
    {
        var objectPosition = movingObject.position;
        if (objectPosition.x > _borderX)
        {
            movingObject.position = new Vector2(0.01f - _borderX, objectPosition.y);
        }
        else if (objectPosition.x < -_borderX)
        {
            movingObject.position = new Vector2(_borderX - 0.01f, objectPosition.y);
        }
        else if (objectPosition.y > _borderY * 0.7f)
        {
            movingObject.position = new Vector2(objectPosition.x, 0.01f - _borderY);
        }
        else if (objectPosition.y < -_borderY)
        {
            movingObject.position = new Vector2(objectPosition.x, _borderY * 0.7f - 0.01f);
        }
    }
}
