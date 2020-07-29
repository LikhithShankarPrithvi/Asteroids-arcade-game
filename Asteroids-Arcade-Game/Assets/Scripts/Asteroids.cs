using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    #region fields

    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;
    [SerializeField]
    Sprite asteroidSprite3;

    #endregion

    // Start is called before the first frame update
    void Start()
    {

        //creating Sprites
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = asteroidSprite1;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = asteroidSprite2;
        }
        else
        {
            spriteRenderer.sprite = asteroidSprite3;
        }
    }
    public void Initialize(Direction direction,Vector3 position)
    {
        transform.position = position;
        float angle;
        float randomAngle = Random.value * 30f * Mathf.Deg2Rad;
        if (direction == Direction.Up)
        {
            angle = 75f * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Left)
        {
            angle = 165f * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Down)
        {
            angle = 255f * Mathf.Deg2Rad + randomAngle;
        }
        else
        {
            angle = -15f * Mathf.Deg2Rad + randomAngle;
        }
        StartMoving(angle);
    }
    void StartMoving(float angle)
    {
        const float MinImpulseForce = 0.2f;
        const float MaxImpulseForce = 2f;
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            AudioManager.Play(AudioClipName.AsteroidHit);
            Vector3 asteroidScale = transform.localScale ;
            //if asteroid is lesser in size
            if (asteroidScale.x < 0.5f)
            {
                Destroy(gameObject);
            }
            //the other way!
            else
            {
                asteroidScale.x = (asteroidScale.x) / 2;
                asteroidScale.y = (asteroidScale.y) / 2;
                transform.localScale = asteroidScale;
                CircleCollider2D collider = GetComponent<CircleCollider2D>();
                collider.radius = (collider.radius) / 2;
                GameObject newAsteroid = Instantiate<GameObject>(gameObject,
                    transform.position,
                    Quaternion.identity);
                newAsteroid.GetComponent<Asteroids>().StartMoving(
                        Random.Range(0, 2 * Mathf.PI));
                newAsteroid = Instantiate<GameObject>(gameObject,
                    transform.position, Quaternion.identity);
                newAsteroid.GetComponent<Asteroids>().StartMoving(
                        Random.Range(0, 2 * Mathf.PI));
                Destroy(gameObject);
            }
        }
    }


}
