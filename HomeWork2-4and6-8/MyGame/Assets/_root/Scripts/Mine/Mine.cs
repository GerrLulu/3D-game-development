using System.Collections;
using UnityEngine;

namespace MineItem
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private int _damage = 30;
        [SerializeField] private float _lifeTime = 5f;
        [SerializeField] private float _radiusExplosion = 8f;
        [SerializeField] private float _force = 1000f;
        [SerializeField] private float _lightTime = 0.02f;
        [SerializeField] private AudioClip[] _audioClips;

        private AudioSource _audioSours;
        private ParticleSystem _particle;
        private Light _light;


        private void Awake()
        {
            _audioSours = GetComponent<AudioSource>();
            _particle = GetComponent<ParticleSystem>();
            _light = GetComponent<Light>();
        }

        private void Start ()
        {
            StartCoroutine("TimeToDie");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player" || other.tag == "Enemy")
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusExplosion);
                foreach (Collider hit in colliders)
                {
                    IMineExplosion obj;

                    if (hit.TryGetComponent<IMineExplosion>(out obj))
                    {
                        if (obj != null)
                        {
                            obj.MineHit(_damage, _force, transform.position);
                        }
                    }
                }

                AudioClip clip = _audioClips[Random.Range(0, _audioClips.Length)];
                _audioSours.clip = clip;
                _audioSours.Play();

                StartCoroutine(LightFlash());
                _particle.Play();

                Destroy(gameObject);
            }
        }


        private IEnumerator TimeToDie()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }

        private IEnumerator LightFlash()
        {
            _light.enabled = true;

            yield return new WaitForSeconds(_lightTime);

            _light.enabled = false;
        }
    }
}