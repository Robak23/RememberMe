using UnityEngine;

public class BoardElementBehaviour : MonoBehaviour
{
    private Animator _animator;
    private bool _active;
    private int _pathStep;
    // Use this for initialization
    void Start ()
    {
	    _animator = gameObject.GetComponent<Animator>();
        _pathStep = -1;
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        _animator.SetBool("Active", true);
        if (other.CompareTag("AI"))
        {
            _pathStep = other.gameObject.GetComponent<AIPlayPath>().PathStep;
        }
        if (other.CompareTag("Player"))
        {
            var step = other.gameObject.GetComponentInParent<PlayerBounce>().PathStep;
            if (step != _pathStep)
            {
                Destroy(other.gameObject);
            }
        }

    }
}
