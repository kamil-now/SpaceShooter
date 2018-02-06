using UnityEngine;

public static class Constants
{
    public const int MainMenuIndex = 1;
    public const int MainSceneIndex = 2;

    public const float DefaultPlayerSpeed = 1000;
    public const int DefaultAsteroidSpeed = 7;
    public const int DefaultEnemyShipSpeed = 10;
    public const float DefaultBulletSpeed = 25;
    public const float DefaultRateOfFire = 0.3f;

    public const float SlowRateOfFire = 0.4f;
    public const float MediumRateOfFire = 0.3f;
    public const float FastRateOfFire = 0.2f;


    public const float BackgroundLength = 80;

    public const float AsteroidSpawnWait = 0.75f;
    public const float AsteroidStartWait = 2;
    public const float AsteroidWaveWait = 2;
    public const int InitAsteroidWaveCount = 3;

    public const int InitPlayerHp = 10;
    public const int InitEnemyHp = 3;
    public const int RestartTime = 5;

    public static readonly Quaternion DefaultCameraRotation = new Quaternion(0.7071068f, 0,0, 0.7071068f);
    public static readonly Vector3 DefaultCameraPosition = new Vector3(0, 10, 5);

    public static readonly Vector3 InitPlayerPosition = new Vector3(0, 0, 0);
    public static readonly Vector3 InitStarfieldPosition = new Vector3(0, -5, 15);
    public static readonly Vector3 StarfieldBackgroundRatio= new Vector3(BackgroundLength/2, BackgroundLength, 1);
    public static readonly Vector3 AsteroidSpawnPosition = new Vector3(0, 0, 15);
    public static readonly Vector3 EnemySpawnPosition = new Vector3(0, 0, 20);

}

