// Decompiled with JetBrains decompiler
// Type: LocationDay1WinHouse
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class LocationDay1WinHouse : MonoBehaviour
{
  public Vector2 realPosition;
  private Animator thisAnimator;
  public AudioSource aS;
  public LocationDay1WinHeli heli;

  private void Start()
  {
    this.thisAnimator = this.gameObject.GetComponent<Animator>();
    this.thisAnimator.Play("house_wait");
    this.aS = this.gameObject.GetComponent<AudioSource>();
  }

  private void Update()
  {
    this.gameObject.transform.position = new Vector3(this.realPosition.x, this.realPosition.y, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
  }

  public void startAnim()
  {
    this.heli.aS.PlayOneShot(SoundsManagerController.sm.heli_fly);
    this.Invoke("startPan", 3f);
  }

  public void startPan() => this.thisAnimator.Play("house");

  public void afterPan()
  {
    this.thisAnimator.Play(nameof (afterPan));
    this.heli.launched = true;
    this.heli.thisAnimator.Play("heli");
  }

  public void afterCrash() => this.thisAnimator.Play(nameof (afterCrash));
}
