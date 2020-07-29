using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// about Bullets 
/// </summary>
public class Bullet : MonoBehaviour
{
    const float LifeSeconds = 2;
    Timer deathTimer;
    private void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = LifeSeconds;
        deathTimer.Run();
    }
    private void Update()
    {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Method for applying force to the bullet!
    /// </summary>
    /// <param name="forceDirection"></param>
    public void ApplyForce(Vector2 forceDirection)
    {
        const float BulletForce = 3f;
        GetComponent<Rigidbody2D>().AddForce(
            BulletForce * forceDirection,
            ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
}
