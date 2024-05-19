using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _lifeTime = 10f;
        [SerializeField] private AudioClip[] _audioClipsImpact;

        private AudioSource _audioSource;

        //[SerializeField] private Light lightFlash;
        //[SerializeField] private float lightTime = 0.02f;


        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
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
                {
                    obj.Hit(_damage);
                    Destroy(gameObject);
                }
            }

            AudioClip clip = _audioClipsImpact[Random.Range(0, _audioClipsImpact.Length)];
            _audioSource.clip = clip;
            Debug.Log(_audioSource.clip);
            _audioSource.Play();

            //StartCoroutine(LightFlash());
        }


        //private IEnumerator LightFlash()
        //{
        //    lightFlash.GetComponent<Light>().enabled = true;

        //    yield return new WaitForSeconds(lightTime);

        //    lightFlash.GetComponent<Light>().enabled = false;
        //}
    }
}