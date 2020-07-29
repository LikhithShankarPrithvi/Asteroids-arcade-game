using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// This is a  Thrust applying class
/// </summary>
public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject hud;

    //Applying Thrust
    #region field
    // Direction is always right side
    Vector2 thrustDirection = new Vector2(1, 0);

    //Constant force of 5 units
    const float ThrustForce = 10;

    //declaring fields for Rigidbody Component
    public Rigidbody2D rb2d;

    //Radius of CirleCollider
    float radii;

    //rotation const
    const float RotationDegreePerSecond = 120;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        CircleCollider2D colli = GetComponent<CircleCollider2D>();
        radii = colli.radius;
    }
    // Fixed Update is called more often than an update method 
    void FixedUpdate()
    {
        //getting the keybutton and proccesing.
        if (Input.GetAxis("Thrust") > 0)
        {
            rb2d.AddForce(ThrustForce * thrustDirection,
                ForceMode2D.Force);
        }
        if (Input.GetAxis("Brakes") > 0)
        {
            rb2d.AddForce(-1 * rb2d.velocity,
                ForceMode2D.Force);
        }
    }

    void Update()
    {
        //For rotation Processing
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput!=0)
        {
            float rotationAmount = RotationDegreePerSecond * Time.deltaTime;
            if (rotationInput < 0) { rotationAmount *= -1; }
            transform.Rotate(Vector3.forward, rotationAmount);
            Vector3 eulerAngle = transform.eulerAngles;
            float requiredAngle = eulerAngle.z;
            float angle = Mathf.Deg2Rad * requiredAngle;
            thrustDirection.x = -Mathf.Sin(angle);
            thrustDirection.y = Mathf.Cos(angle);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bullet = Instantiate<GameObject>(
                bulletPrefab, transform.position, Quaternion.identity);
            Bullet script = bullet.GetComponent<Bullet>();
            script.ApplyForce(thrustDirection);
            AudioManager.Play(AudioClipName.PlayerShot);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            hud.GetComponent<HUD>().StopGameTimer();
            AudioManager.Play(AudioClipName.PlayerDeath);
        }
    }
}
