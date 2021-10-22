// Decompiled with JetBrains decompiler
// Type: GasstationSarge
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class GasstationSarge : MonoBehaviour
{
  public AudioSource aS;

  private void Start() => this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);

  private void Update()
  {
  }

  public void lookLeft() => this.GetComponent<SpriteRenderer>().flipX = true;

  public void lookRight() => this.GetComponent<SpriteRenderer>().flipX = false;

  public void shot()
  {
    if (!GameDataController.gd.getObjective("gasstation_sarge_canister_filled"))
      this.GetComponent<Animator>().Play("sarge_shot_back");
    else
      this.GetComponent<Animator>().Play("sarge_shot_front");
  }

  public void decideRotation()
  {
    if ((double) PlayerController.wc.currentXY.x < 120.0)
      this.GetComponent<SpriteRenderer>().flipX = true;
    else
      this.GetComponent<SpriteRenderer>().flipX = false;
  }

  public void body_slam() => this.aS.PlayOneShot(SoundsManagerController.sm.body_slam, 0.5f);

  public void body_thud() => this.aS.PlayOneShot(SoundsManagerController.sm.body_thud, 0.5f);

  public void kneel() => this.GetComponent<Animator>().Play("sarge_kneel");
}
