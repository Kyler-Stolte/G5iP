
using UnityEngine;


public class Gun : MonoBehaviour
{
    public Animator animator;

    public Transform Tracker;
    public float Angle;

    [SerializeField] private AudioClip[] gunSounds;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Tracker.position = transform.position;
    }

    private void Update()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //gun tracks mouse
        Vector2 direction = new Vector2(mousePosition.x - Tracker.transform.position.x, mousePosition.y - Tracker.transform.position.y);
        Tracker.transform.up = direction;

        Angle = Tracker.transform.rotation.z;
        animator.SetFloat("Angle", Angle);

        if (Input.GetMouseButtonDown(0) == true)
        {
            audioSource.clip = gunSounds[0];
            audioSource.Play();
            animator.SetBool("IsClicked", true);
            animator.SetBool("IsNotClicked", false);
        }
        else
        {
            animator.SetBool("IsNotClicked", true);
            animator.SetBool("IsClicked", false);
        }


        
    }
}

    

       