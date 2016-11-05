using UnityEngine;
using System.Collections;


public class JumpAnimation : MonoBehaviour
{
    private Animator _animator;
    public GameObject playerObject;
	// Use this for initialization
	void Start ()
	{
	    _animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    PlayerBounce bounceScript = playerObject.GetComponent<PlayerBounce>();
	    _animator.SetBool("Jump", bounceScript.TriggerAnimation);
	}
}
