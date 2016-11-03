using UnityEngine;
using System.Collections;

public class JumpAnimationScript : MonoBehaviour
{
    public GameObject playerObject;
    private Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var aiPlayPath = playerObject.GetComponent<AIPlayPath>();
        _animator.SetBool("Jump", aiPlayPath.TriggerAnimation);
    }
}
