using UnityEngine;

public class ScreenTeleport
{
    private float _borderY => Camera.main.orthographicSize;
    private float _borderX => Camera.main.aspect * _borderY;

    private float _topPanelSize => _borderY * 2 / 10;
    public float RightPanelSize => _borderX * 2 * 0.15f;

    public void BorderCrossing(Transform movingObject)
    {
        var objectPosition = movingObject.position;
        if (objectPosition.x > _borderX - RightPanelSize)
        {
            movingObject.position = new Vector2(0.01f - _borderX, objectPosition.y);
        }
        else if (objectPosition.x < -_borderX)
        {
            movingObject.position = new Vector2(_borderX - RightPanelSize - 0.01f, objectPosition.y);
        }
        else if (objectPosition.y > _borderY - _topPanelSize)
        {
            movingObject.position = new Vector2(objectPosition.x, 0.01f - _borderY);
        }
        else if (objectPosition.y < -_borderY)
        {
            movingObject.position = new Vector2(objectPosition.x, _borderY - _topPanelSize - 0.01f);
        }
    }
}
