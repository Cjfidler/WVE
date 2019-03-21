using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace WVE.DevStuff.weaponimport
{

    public class AssaultRifle : Weapon
    {
        private Vector3 _origin;
        private Vector3 _directionofCast;
        List<BulletInstance> _bullets = new List<BulletInstance>();


        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            OnEnterPrimaryMode();
            _isPrimaryMode = true;
            _currentClip = _maxClip;
            _nextFire = Time.time;
        }



        private void FixedUpdate()
        {


            for (int i = 0; i < _bullets.Count;)
            {
                Vector3 direction = _bullets[i].Direction;
                Vector3 start = _bullets[i].StartPosition;
                float distanceToTravel = _bullets[i].DistanceRemaining;

                if (distanceToTravel > 0f)
                {
                    Vector3 end;
                    direction.y -= _dropRate;
                    RaycastHit hit;
                    bool isHit = Physics.Raycast(start, direction, out hit, _speed);

                    end = isHit ? hit.point : start + direction * _speed;

                    if (_drawDebug)
                    {
                        Debug.DrawLine(start, end, isHit ? Color.red : Color.white, 50f);
                    }

                    if (isHit)
                    {
                        Debug.Log("Hit");
                        OnHit(direction * -1, hit.point, hit.collider);
                        DealDamage(5, hit.collider);
                        _bullets.Remove(_bullets[i]);
                        break;
                    }

                    direction = (end - start).normalized;
                    distanceToTravel -= _speed;
                    start = end;
                    BulletInstance instance = _bullets[i];
                    instance.Direction = direction;
                    instance.DistanceRemaining = distanceToTravel;
                    instance.StartPosition = start;
                    _bullets[i] = instance;
                    i++;
                }
                else
                {
                    _bullets.Remove(_bullets[i]);
                }

            }

        }

        public override void Shoot(Vector3 direction, Vector3 start)
        {

            if (Time.time >= _nextFire)
            {
                if (_currentClip > 0)
                {

                    Onfire();
                    Debug.Log("you shot");
                    _nextFire = Time.time + _fireRate;
                    _bullets.Add(new BulletInstance(direction, _maxDistance, start));
                    _currentClip--;
                }
            }
            else
            {
                _audio.PlayOneShot(_empty, _volume);
            }

        }

        protected override void OnEnterPrimaryMode()
        {
            _fireRate = .1f;
            _speed = 100f;
            _damage = 5;
            _maxDistance = 250f;
            _dropRate = .01f;
            _shoot = _primSound;
            _volume = .5f;

        }

        protected override void OnEnterSecondaryMode()
        {
            _fireRate = 1f;
            _speed = 300f;
            _damage = 15;
            _maxDistance = 500f;
            _dropRate = .01f;
            _shoot = _secSound;
            _volume = 1f;
        }

        private void Onfire()
        {
            _audio.PlayOneShot(_shoot, _volume);
            //Instantiate(_muzzleFlash,_particlePoint);
        }

        private void OnHit(Vector3 Direction, Vector3 HitPoint, Collider Collision)
        {

            /*  IBulletCanHit testInterface = Collision.gameObject.GetComponent<IBulletCanHit>();

              if (testInterface != null) {
                  testInterface.GetHit(Direction, HitPoint);
              }

      */
        }
        public void DealDamage(int DamagetoDeal, Collider Collision)
        {

            ITakeDamage testInterface = Collision.gameObject.GetComponent<ITakeDamage>();

            if (testInterface != null)
            {
                testInterface.TakeDamage(1, _damage);
            }

        }

    }
}