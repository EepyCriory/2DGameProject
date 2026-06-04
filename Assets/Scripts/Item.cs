using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    #region Enums
    public enum ItemTypes
    {
        None,
        SpeedBoost,
        JumpBoost,
        DoubleJumpCharge
    }
    #endregion

    #region Properties
    [field: SerializeField] public ItemTypes Type { get; set; }
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer _sprite;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
             PlayerEventManager _playerEvent = collision.gameObject.GetComponent<PlayerEventManager>();
            switch (Type)
            {
                case ItemTypes.SpeedBoost:
                    _playerEvent.OnSpeedBoost(30);
                    _particleSystem.Play();
                    _sound.Play();
                    StartCoroutine(ParticleWait());
                    break;
                case ItemTypes.JumpBoost:
                    _playerEvent.OnJumpBoost(30);
                    _particleSystem.Play();
                    _sound.Play();
                    StartCoroutine(ParticleWait());
                    break;
                case ItemTypes.DoubleJumpCharge:
                    _playerEvent.OnDoubleJumpCharge(1);
                    _particleSystem.Play();
                    _sound.Play();
                    StartCoroutine(ParticleWait());
                    break;
            }
        }
    }
    #endregion

    #region Private Methods
    private  IEnumerator ParticleWait()
    {
        Destroy(_sprite);
        Destroy(_collider);
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
    #endregion
}
