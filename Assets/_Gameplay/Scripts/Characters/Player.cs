using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, ITarget
{

    // Player Variables
    [Header("Player Setting")]
    public Player player;
    public static Player _player;
    public Transform playerTransform;
    public Transform playerModel;
    public Rigidbody playerRb;
    public Collider playerCollider;
    public SphereCollider boundaryCollider;

    // Joystick Variables
    [Header("Joystick")]
    public Canvas joystickCanvas;
    public JoytickController joystick;
    private float inputX;
    private float inputZ;

    // Move and Rotate
    [Header("Movement and Rotate")]
    private Vector3 movement;
    public float moveSpeed;
    public float rotateSpeed;
    private float angleToRotate;

    // Animator
    [Header("Animator")]
    public Animator playerAnimator;

    // Weapon
    [Header("Weapon")]
    private Weapon weapon;
    private WeaponID weaponID;
    public Transform weaponHolder;
    private WeaponSkinID weaponSkinID;

    // Boolean Variables
    private bool canAttack;
    private bool isDead;
    private bool isWin;

    // FollowingUI
    [Header("Following UI")]
    public GameObject underUI;

    public PlayerSkin playerSkin;
    public Indicator playerIndicator;

    private void Awake()
    {
        _player = this;
    }

    private void OnEnable()
    {
        OnInit();
    }

    public override void OnInit()
    {
        // Init joystick movement
        inputX = 0;
        inputZ = 0;
        movement = Vector3.zero;

        // Init Boolean
        canAttack = true;
        isDead = false;
        isWin = false;

        // Init Skin
        InitWeapon();
        InitName();
        playerSkin.OnInit();

        // Init Animation
        playerAnimator.SetBool(Constant.ANIM_IS_WIN, false);
        playerAnimator.SetBool(Constant.ANIM_IS_DEAD, false);
        playerAnimator.SetBool(Constant.ANIM_IS_IDLE, true);

        // Init basic attribute
        playerCollider.enabled = true;
        movement = Vector3.zero;
        player.transform.rotation = Quaternion.Euler(0, 60, 0);
        charBound.transform.position = Vector3.zero;

        scale = 1;
        score = 0;
        range = 1;
        scoreToScale = 2;
    }

    private void Update()
    {
        if (LevelManager.Ins.GetGameState() == Constant.GameState.PLAY)
        {
            ActivateUI(true);
            if (!isDead && !isWin)
            {
                if (LevelManager.Ins.GetRemainNumOfBots() == 0)
                {
                    Win();
                }
                else
                {
                    Move();
                }
            }
        }
        else
        {
            ActivateUI(false);
            if (LevelManager.Ins.GetGameState() == Constant.GameState.CHOOSESKIN)
            {
                ChooseSkinAnim();
            }
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void ActivateUI(bool activate)
    {
        underUI.SetActive(activate);
        joystickCanvas.gameObject.SetActive(activate);
    }

    private void InitWeapon()
    {
        if (weapon != null)
            Destroy(weapon.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_WEAPON))
            weaponID = (WeaponID)PlayerPrefs.GetInt(Constant.SELECTED_WEAPON);
        else
            weaponID = (WeaponID)0;

        if (PlayerPrefs.HasKey(Constant.SELECTED_WEAPON_SKIN))
            weaponSkinID = (WeaponSkinID)PlayerPrefs.GetInt(Constant.SELECTED_WEAPON_SKIN);
        else
            weaponSkinID = (WeaponSkinID)0;

        weapon = ItemController.Ins.SetWeapon(weaponID, weaponSkinID, weaponHolder);
    }

    public void InitName()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            SetName(PlayerPrefs.GetString("PlayerName"));
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", "Player");
        }
        playerIndicator.SetName();
    }

    #region Move
    public override void Move()
    {
        inputX = joystick.inputHorizontal();
        inputZ = joystick.inputVertical();

        if (inputX == 0 && inputZ == 0)
        {
            Stop();
            Attack();
        }
        else
        {
            SetRotation();
            SetMovement();
        }
    }

    private void Stop()
    {
        movement = Vector3.zero;
        playerAnimator.SetBool(Constant.ANIM_IS_IDLE, true);
    }

    private void SetRotation()
    {
        angleToRotate = Mathf.Rad2Deg * Mathf.Atan2(inputX, inputZ);
        playerModel.rotation = Quaternion.RotateTowards(playerModel.rotation, Quaternion.AngleAxis(angleToRotate, Vector3.up), rotateSpeed * Time.deltaTime);
    }

    private void SetMovement()
    {
        StopAttack();
        movement = new Vector3(inputX, 0, inputZ);
        playerAnimator.SetBool(Constant.ANIM_IS_IDLE, false);
        canAttack = true;
    }

    private void MoveCharacter(Vector3 direction)
    {
        playerRb.velocity = direction * moveSpeed * Time.deltaTime * GetScale();
    }
    #endregion

    #region Attack
    public override void Attack()
    {
        if (canAttack)
        {
            GameObject targetCharacter = charBound.GetTargetCharacter();
            if (targetCharacter != null)
            {
                canAttack = false;
                playerAnimator.SetBool(Constant.ANIM_IS_ATTACK, true);

                Vector3 directToTarget = targetCharacter.transform.position - playerTransform.position;
                RotateToTargetCharacter(directToTarget);

                StartCoroutine(ThrowWeapon());
                Invoke(nameof(StopAttack), 1f);
            }
        }
    }

    IEnumerator ThrowWeapon()
    {
        yield return new WaitForSeconds(0.2f);
        if (!canAttack)
        {
            playerAnimator.SetBool(Constant.ANIM_IS_ATTACK, true);
            weapon.Attack(playerModel, player);
            weapon.gameObject.SetActive(false);
        }
    }

    private void StopAttack()
    {
        playerAnimator.SetBool(Constant.ANIM_IS_ATTACK, false);
    }

    private void RotateToTargetCharacter(Vector3 directToTarget)
    {
        float xPos = directToTarget.x;
        float zPos = directToTarget.z;

        angleToRotate = Mathf.Rad2Deg * Mathf.Atan2(xPos, zPos);
        playerModel.rotation = Quaternion.AngleAxis(angleToRotate, Vector3.up);
    }
    #endregion

    #region Death
    public override void Death(Character killer)
    {
        if (!isWin)
        {
            isDead = true;
            movement = Vector3.zero;
            playerAnimator.SetBool(Constant.ANIM_IS_DEAD, true);
            joystickCanvas.gameObject.SetActive(false);
            playerCollider.enabled = false;

            LevelManager.Ins.Lose(killer);
            UIManager.Ins.GetUI(UIID.UICGameplay).Close();
            UIManager.Ins.OpenUI(UIID.UICFail);
        }
    }

    public bool CanBeTargeted()
    {
        return !isDead;
    }

    public void DisableLockTarget() { }

    public void EnableLockTarget() { }
    #endregion

    #region Win
    public void Win()
    {
        if (!isDead)
        {
            isWin = true;
            movement = Vector3.zero;
            playerAnimator.SetBool(Constant.ANIM_IS_WIN, true);
            joystickCanvas.gameObject.SetActive(false);

            LevelManager.Ins.Win();
            UIManager.Ins.GetUI(UIID.UICGameplay).Close();
            UIManager.Ins.OpenUI(UIID.UICVictory);
        }
    }
    #endregion

    public void ChangeWeapon()
    {
        if (weapon != null)
            Destroy(weapon.gameObject);

        if (PlayerPrefs.HasKey(Constant.SELECTED_WEAPON))
            weaponID = (WeaponID)PlayerPrefs.GetInt(Constant.SELECTED_WEAPON);
        else
            weaponID = (WeaponID)0;

        if (PlayerPrefs.HasKey(Constant.SELECTED_WEAPON_SKIN))
            weaponSkinID = (WeaponSkinID)PlayerPrefs.GetInt(Constant.SELECTED_WEAPON_SKIN);
        else
            weaponSkinID = (WeaponSkinID)0;

        weapon = ItemController.Ins.SetWeapon(weaponID, weaponSkinID, weaponHolder);
    }

    public PlayerSkin GetPlayerSkin()
    {
        return playerSkin;
    }

    public override void IncreaseRange(float increaseValue)
    {
        range *= increaseValue;
        boundaryCollider.radius *= increaseValue;
        underUI.transform.localScale *= increaseValue;
    }

    public void ChooseSkinAnim()
    {
        playerAnimator.SetBool(Constant.ANIM_IS_DANCE, true);
    }

    public void ExitSkinAnim()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool(Constant.ANIM_IS_DANCE, false);
        }
    }
}
