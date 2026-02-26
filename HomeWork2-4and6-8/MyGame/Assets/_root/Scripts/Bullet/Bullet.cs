using System.Collections;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;

        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _lightTime;

        [SerializeField] private AudioClip[] _audioClipsImpact;


        private AudioSource _audioSource;

        private Light _lightFlash;


        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _lightFlash = GetComponent<Light>();
        }

        void FixedUpdate()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
            Destroy(gameObject, _lifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            IBulletDamage obj;

            if (other.TryGetComponent<IBulletDamage>(out obj))
            {
                if (obj != null)
                    obj.Hit(_damage);
            }

            AudioClip clip = _audioClipsImpact[Random.Range(0, _audioClipsImpact.Length)];
            _audioSource.clip = clip;
            _audioSource.Play();

            StartCoroutine(LightFlash());

            Destroy(gameObject);
        }


        private IEnumerator LightFlash()
        {
            _lightFlash.enabled = true;

            yield return new WaitForSeconds(_lightTime);

            _lightFlash.enabled = false;
        }
    }
}