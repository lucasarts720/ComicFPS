using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //This script goes inside the Camera object, not the player.

    Vector2 mouseLook;
    Vector2 smoothV;

    public float sensibility = 5.0f;
    public float smoothness = 2.0f;

    GameObject player;

    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensibility * smoothness, sensibility * smoothness));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothness);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothness);

        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
