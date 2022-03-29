using UnityEngine;

namespace Learning.Scripts.DamageSystem
{
    public class ShootScript : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _bulletSpawnPlace;
        [SerializeField] private Vector3 _bulletShotPositionCorrect = new Vector3(0, 0, 0);
        
        public void Shot() // I would like to use a delegate here, but I don't know enough about them yet
        {
            if (!_bullet)
            {
                Debug.LogError("Not have _bullet object! Bullet type! ShootScript.cs please fix it!");
                _bullet = (Bullet)FindObjectOfType(typeof(Bullet)); // it is not good! Please, fix it if you have this error
                //return;
            }
            if (!_bulletSpawnPlace) _bulletSpawnPlace = transform; 
            InstantNewBullet();
        }
        
        private void InstantNewBullet()
        {
            var bullet = Instantiate(_bullet, _bulletSpawnPlace.position + _bulletShotPositionCorrect + gameObject.transform.forward,
                _bulletSpawnPlace.rotation);
            bullet.tag = gameObject.tag; // only offline gaming! If you want to make a multiplayer, this system want to refactor.
            bullet.BulletSetForward(transform.forward);
        }
    }
}