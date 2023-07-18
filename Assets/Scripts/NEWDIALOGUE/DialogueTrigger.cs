using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] public CharacterController controller;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Interaction Key")]
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    private bool playerInRange;
    public Animator animator;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerBody;
    private Quaternion initialRotationCamera;
    private Quaternion initialRotationPlayer;
    private Quaternion initialRotationPlayerBody;

    public bool isCameraStop;

    private float xRotCamera;
    private float yRotCamera;

    private float xRotPlayer;
    private float yRotPlayer;

    private float xRotPlayerBody;
    private float yRotPlayerBody;

    private void Awake()
    {
        isCameraStop = false;
        playerInRange = false;
        visualCue.SetActive(false);
    }

    // Start is called before the first frame update

    private void Start()
    {
        initialRotationCamera = mainCamera.transform.rotation; // Store the initial rotation of the camera
        initialRotationPlayer = player.transform.rotation; // Store the initial rotation of the player
        initialRotationPlayerBody = playerBody.transform.rotation; // Store the initial rotation of the player body
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(interactionKey))
            {
                isCameraStop = true;
                controller.enabled = false; // Disable CharacterController
                animator.enabled = false; // Disable Animator


                xRotCamera = mainCamera.transform.eulerAngles.x;
                yRotCamera = mainCamera.transform.eulerAngles.y;
                xRotPlayer = player.transform.eulerAngles.x;
                yRotPlayer = player.transform.eulerAngles.y;
                xRotPlayerBody = playerBody.transform.eulerAngles.x;
                yRotPlayerBody = playerBody.transform.eulerAngles.y;


                mainCamera.transform.rotation = Quaternion.Euler(xRotCamera, yRotCamera, mainCamera.transform.eulerAngles.z);
                player.transform.rotation = Quaternion.Euler(xRotPlayer, yRotPlayer, player.transform.eulerAngles.z);
                playerBody.transform.rotation = Quaternion.Euler(xRotPlayerBody, yRotPlayerBody, playerBody.transform.eulerAngles.z);

                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }

        if (isCameraStop)
        {
            mainCamera.transform.eulerAngles = new Vector3(xRotCamera, yRotCamera, mainCamera.transform.eulerAngles.z);
            player.transform.eulerAngles = new Vector3(xRotPlayer, yRotPlayer, player.transform.eulerAngles.z);
            playerBody.transform.eulerAngles = new Vector3(xRotPlayerBody, yRotPlayerBody, playerBody.transform.eulerAngles.z);

        }



    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}