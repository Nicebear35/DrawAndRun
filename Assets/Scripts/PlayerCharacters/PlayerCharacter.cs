using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : MonoBehaviour
{
    private const string IsRunning = "IsRunning";
    private const string IsWon = "IsWon";
    private const string IsDead = "IsDead";

    public event UnityAction<PlayerCharacter> PlayerCharacterDied;

    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _dieParticles;
    [SerializeField] private GameObject _body;

    private bool _isRunning;
    private bool _isWon;
    private bool _isDead;

    private void Start()
    {
        _isRunning = true;
        _animator.SetBool(IsRunning, _isRunning);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Obstacle obstacle))
        {
            _isDead = true;
            Die();
        }
    }

    public void Die()
    {
        transform.SetParent(null);
        _body.gameObject.SetActive(false);
        _dieParticles.Play();
        Destroy(gameObject, 3f);
        PlayerCharacterDied?.Invoke(this);
    }

    public void Finish()
    {
        _isRunning = false;
        _animator.SetBool(IsRunning, _isRunning);    
        _isWon = true;
        _animator.SetBool(IsWon, _isWon);    

    }
}
