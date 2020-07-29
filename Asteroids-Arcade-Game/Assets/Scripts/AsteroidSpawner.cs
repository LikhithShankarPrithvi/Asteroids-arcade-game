using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Spawning Asteroids!
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject asteroidPrefab;
    void Start()
    {
        //Calculating the radius of the collider!
        GameObject asteroid = Instantiate<GameObject>(asteroidPrefab);
        CircleCollider2D collider = asteroid.GetComponent<CircleCollider2D>();
        float asteroidRadius = collider.radius;
        Destroy(asteroid);

        //calculating width and height of the screen!
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        //Spawning asteroid from four sides!
        //Right side!
        asteroid = Instantiate<GameObject>(asteroidPrefab);
        Asteroids script = asteroid.GetComponent<Asteroids>();
        script.Initialize(Direction.Left,
            new Vector2(ScreenUtils.ScreenRight + asteroidRadius,
                ScreenUtils.ScreenBottom + screenHeight / 2));
        //Left Side!
        asteroid = Instantiate<GameObject>(asteroidPrefab);
        script = asteroid.GetComponent<Asteroids>();
        script.Initialize(Direction.Right,
            new Vector2(ScreenUtils.ScreenLeft - asteroidRadius,
            ScreenUtils.ScreenBottom + screenHeight / 2));
        //Top side!
        asteroid = Instantiate<GameObject>(asteroidPrefab);
        script = asteroid.GetComponent<Asteroids>();
        script.Initialize(Direction.Down,
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
            ScreenUtils.ScreenTop + asteroidRadius));
        //Down Side!
        asteroid = Instantiate<GameObject>(asteroidPrefab);
        script = asteroid.GetComponent<Asteroids>();
        script.Initialize(Direction.Up,
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenBottom - asteroidRadius));
    }

}
