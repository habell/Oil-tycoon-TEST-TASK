using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletSpawnPlace;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) InstantNewBullet();
    }

    private void InstantNewBullet()
    {
        var bullet = Instantiate(_bullet, _bulletSpawnPlace.position + new Vector3(0, 1, 0),
            _bulletSpawnPlace.rotation);
        bullet.BulletSetForward(transform.forward);
    }
}