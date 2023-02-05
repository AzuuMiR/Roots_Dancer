using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("System")]
    public int TargetFramerate = 60;
    private bool gameOver = false;
    //private bool win = false;
    public Animator endingAnim;

    [Header("Music & Beat")]
    public float BeatTempo = 120f;
    private AudioSource Music;
    [SerializeField] bool startPlaying = false;
    [SerializeField] BeatScroller beatScrollerLeft;
    [SerializeField] BeatScroller beatScrollerRight;

    [Header("Lives and score")]
    public int Lives = 3;
    public MeshRenderer[] lifeIcon;
    public Material RemovedLifeColor;
    [SerializeField] int currentScore = 0;
    [SerializeField] int scorePerNote = 1;
    [SerializeField] int scorePerGrowth = 3;

    [Header("Tree")]
    public GameObject[] treeParts;
    [SerializeField] int treeState = 0;

    [Header("Particle Systems")]
    public ParticleSystem[] particleSystems;

    [Header("UI")]
    public GameObject StartButton;
    public GameObject RestartButton;

    void Awake()
    {
        Instance = this;
        BeatTempo = BeatTempo / 60f;
    }

    void Start()
    {
        Music = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                StartButton.SetActive(false);
                startPlaying = true;
                beatScrollerLeft.hasStarted = true;
                beatScrollerRight.hasStarted = true;
                beatScrollerLeft.StartScrolling();
                beatScrollerRight.StartScrolling();

                Music.Play();
            }
        }
    }

    public void NoteHit(int directionId)
    {
        if (!gameOver)
        {
            particleSystems[directionId].Play();
            currentScore += scorePerNote;
            GrowTree();
        }
    }

    public void NoteMissed()
    {
        if (!gameOver) Lives--;
        
        if (Lives == 2)
        {
            lifeIcon[2].material = RemovedLifeColor;
        }
        else if (Lives == 1)
        {
            lifeIcon[1].material = RemovedLifeColor;
        }
        else if (Lives <= 0)
        {
            lifeIcon[0].material = RemovedLifeColor;
            GameOver();
        }
    }

    public void GrowTree()
    {
        if (currentScore % scorePerGrowth == 0)
        {
            if (treeState < treeParts.Length -1)
            {
                treeState++;
                treeParts[treeState].SetActive(true);
            }
            else
            {
                EndGame();
            }
        }
        /*else
        {
            Debug.Log(scorePerGrowth - (currentScore % 3) + " more for the next growth");
        }*/
    }

    void GameOver()
    {
        EndGame();
    }

    void EndGame()
    {
        gameOver = true;
        beatScrollerLeft.StopScrolling();
        beatScrollerRight.StopScrolling();

        endingAnim.enabled = true;
    }
}
