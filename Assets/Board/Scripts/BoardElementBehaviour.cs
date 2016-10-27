using UnityEngine;
using System.Collections;

public class BoardElementBehaviour : MonoBehaviour
{
    private Animator _animator;
    private bool _active;
    // Use this for initialization
    void Start ()
    {
	    _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        _animator.SetBool("Active", true);
    }
}
