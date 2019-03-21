using UnityEngine;

namespace WVE.DevStuff.weaponimport
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] public bool _isPrimaryMode = true;
        [SerializeField] protected float _speed = 300f;
        [SerializeField] protected int _damage = 5;
        [SerializeField] protected int _damageType = 1;
        [SerializeField] protected float _maxDistance = 200f;
        [SerializeField] protected float _dropRate = .01f;
        [SerializeField] protected bool _drawDebug = false;
        [SerializeField] protected float _fireRate = 1f;
        [SerializeField] protected int _maxClip = 30;
        protected int _currentClip;
        [SerializeField] protected float _nextFire;
        [SerializeField] protected Transform _particlePoint;
        [Header("Audio")]
        [SerializeField] protected float _volume;
        [SerializeField] protected AudioClip _primSound;
        [SerializeField] protected AudioClip _secSound;
        [SerializeField] protected AudioClip _empty;
        protected AudioSource _audio;
        protected AudioClip _shoot;

        // [SerializeField] protected GameObject _muzzleFlash;
        public abstract void Shoot(Vector3 direction, Vector3 start);

        public void SwapMode()
        {
            _isPrimaryMode = !_isPrimaryMode;

            if (_isPrimaryMode)
            {
                OnEnterPrimaryMode();
            }
            else
            {
                OnEnterSecondaryMode();
            }
        }

        public void Reload()
        {
            _currentClip = _maxClip;
        }

        public struct BulletInstance
        {
            public Vector3 StartPosition;
            public Vector3 Direction;
            public float DistanceRemaining;

            public BulletInstance(Vector3 direction, float distanceRemaining, Vector3 start)
            {
                Direction = direction;
                DistanceRemaining = distanceRemaining;
                StartPosition = start;
            }
        }

        protected abstract void OnEnterPrimaryMode();

        protected abstract void OnEnterSecondaryMode();
    }
}