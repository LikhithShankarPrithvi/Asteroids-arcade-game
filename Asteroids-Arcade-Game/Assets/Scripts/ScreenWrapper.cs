using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    // Start is called before the first frame update
    //declaring fields for Rigidbody Component
    public Rigidbody2D rb2d;

    //Radius of CirleCollider
    float radii;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        CircleCollider2D colli = GetComponent<CircleCollider2D>();
        radii = colli.radius;
    }
    //This method is called to detect the ships appearence in the camera
    private void OnBecameInvisible()
    {
        enabled = true;
        Vector2 position = transform.position;
        if (position.x - radii < ScreenUtils.ScreenLeft)
        {
            position.x = -position.x;
        }
        else if (position.x + radii > ScreenUtils.ScreenRight)
        {
            position.x = -position.x;
        }
        if (position.y - radii < ScreenUtils.ScreenBottom)
        {
            position.y = -position.y;
        }
        else if (position.y + radii > ScreenUtils.ScreenTop)
        {
            position.y = -position.y;
        }
        transform.position = position;
    }
}
