using UnityEngine;

public class EyeController : MonoBehaviour
{
    void Update()
    {
        FollowCursor();
    }

    private void FollowCursor()
    {
        if (Camera.main == null)
        {
            return;
        }

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }
}