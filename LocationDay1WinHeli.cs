// Decompiled with JetBrains decompiler
// Type: LocationDay1WinHeli
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationDay1WinHeli : MonoBehaviour
{
  public Vector2 realPosition;
  public LocationDay1WinHouse house;
  public Animator houseAnimator;
  public Animator thisAnimator;
  public AudioSource aS;
  public float targetX;
  public float targetY;
  public bool crashing;
  private int crashDel;
  public bool launched;
  private float speed;

  private void Start()
  {
    this.crashing = false;
    this.thisAnimator = this.gameObject.GetComponent<Animator>();
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    this.aS = this.gameObject.GetComponent<AudioSource>();
    this.thisAnimator.Play("heli_stop");
  }

  private void Update()
  {
    if (this.crashing)
    {
      if (this.crashDel <= 0)
      {
        this.crashDel = 3;
        if ((double) this.realPosition.y == (double) this.targetY)
        {
          this.realPosition.y = this.targetY - 0.017f;
          this.house.realPosition.y = -0.017f;
        }
        else
        {
          this.realPosition.y = this.targetY;
          this.house.realPosition.y = 0.0f;
        }
      }
      else
        --this.crashDel;
    }
    if (!this.launched)
      return;
    this.realPosition.x += this.speed * Time.deltaTime;
    this.speed += 0.23f * Time.deltaTime;
    if ((double) this.realPosition.x >= (double) this.targetX)
      this.realPosition.x = this.targetX;
    this.gameObject.transform.position = new Vector3(this.realPosition.x, this.realPosition.y, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
  }

  public void crash()
  {
    this.crashing = true;
    this.houseAnimator.Play("house_crash");
    this.house.aS.PlayOneShot(SoundsManagerController.sm.heli_crash);
    this.aS.Stop();
  }

  public void crash2()
  {
    this.crashing = false;
    this.thisAnimator.Play("heli2");
    PlayerController.pc.spawnName = "InfoExit";
    CurtainController.cc.fadeOut("LocationDream2", tSpeed: 0.01f);
  }
}
