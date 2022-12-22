using UnityEngine;

public class ScreenTeleport
{
    private float _borderY => Camera.main.orthographicSize;
    private float _borderX => Camera.main.aspect * _borderY;

    private float _topPanelSize => _borderY * 2 / 10;

    private float _offset = 0.01f;

    public void BorderCrossing(Transform movingObject)
    {
        var objectPosition = movingObject.position;
        if (objectPosition.x > _borderX)
        {
            movingObject.position = new Vector2(_offset - _borderX, objectPosition.y);
        }
        else if (objectPosition.x < -_borderX)
        {
            movingObject.position = new Vector2(_borderX - _offset, objectPosition.y);
        }
        else if (objectPosition.y > _borderY - _topPanelSize)
        {
            movingObject.position = new Vector2(objectPosition.x, _offset - _borderY);
        }
        else if (objectPosition.y < -_borderY)
        {
            movingObject.position = new Vector2(objectPosition.x, _borderY - _topPanelSize - _offset);
        }
    }
}
