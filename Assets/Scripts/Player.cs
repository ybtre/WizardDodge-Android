using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float acclSpeed = 300f;
    [SerializeField] private Vector2 deathKick = new Vector2(5, 5);

    private bool isAlive = true;
    private float currScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Canvas GameOverCanvas;

    private Rigidbody2D myRb;
    private float acclInput;

    private Animator myAnimator;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private GameSession _gameSession;

    // Start is called before the first frame update
    void Start() {
        _gameSession = FindObjectOfType<GameSession>();
        myRb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        scoreText.text = currScore.ToString();

        // currScore = PlayerPrefsController.GetMasterScore();
    }

    private void FixedUpdate() {
        if (!isAlive) {
            return;
        }

        Move();
    }

    // Update is called once per frame
    void Update() {
        if (!isAlive) {
            return;
        }

        FlipSprite();
        Score();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == 9) {
            PlayerDeath();
        }
    }

    private void Score() {
        currScore += Time.deltaTime;
        float seconds = Mathf.FloorToInt(currScore % 60);
        scoreText.text = string.Format("{0:00}", seconds.ToString());
    }

    private void Move() {
        float currInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        acclInput = Input.acceleration.x * acclSpeed * Time.deltaTime;

        if (currInput != 0) {
            Vector2 velocityPlayer = new Vector2(-currInput, myRb.velocity.y);
            myRb.velocity = velocityPlayer;
        }
        else if (acclInput != 0) {
            myRb.velocity = new Vector2(acclInput, myRb.velocity.y);
        }

        bool playerHasHorizontalSpeed = Mathf.Abs(myRb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            myAnimator.SetBool(IsRunning, true);
        }
        else {
            myAnimator.SetBool(IsRunning, false);
        }
    }

    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(myRb.velocity.x), 1f);
        }
    }

    private void PlayerDeath() {
        isAlive = false;
        myAnimator.SetTrigger("IsDead");
        GetComponent<Rigidbody2D>().velocity = new Vector2(
            Random.Range(-deathKick.x, deathKick.x + 1),
            Random.Range(deathKick.y, deathKick.y + 5));
        GameOverCanvas.gameObject.SetActive(true);
        // PlayerPrefsController.SetMasterScore((int)currScore);        
    }

    public void ContinueLevel() {
        isAlive = true;
        myAnimator.ResetTrigger("IsDead");
        myAnimator.Play("Idle");
        GameOverCanvas.gameObject.SetActive(false);
    }
}