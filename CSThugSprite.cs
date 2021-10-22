// Decompiled with JetBrains decompiler
// Type: CSThugSprite
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class CSThugSprite : MonoBehaviour
{
  public AudioSource aS;
  public LocationCS2Start cs2;

  private void Start() => this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);

  private void Update()
  {
  }

  public void hide() => this.gameObject.GetComponent<Animator>().Play("thug_dead");

  public void show() => this.gameObject.GetComponent<Animator>().Play("thug_watch");

  public void getShot()
  {
    GameDataController.gd.setObjective("cs_thug_shot", true);
    this.gameObject.GetComponent<Animator>().Play("thug_shoot_dead");
  }

  public void shoot()
  {
    this.aS.PlayOneShot(SoundsManagerController.sm.rifle_shoot);
    PlayerController.pc.setBusy(true);
    PlayerController.wc.forceAnimation("shot_n", true);
  }

  public void distracted() => GameDataController.gd.setObjective("cs_guard_distracted", true);

  public void distractedEnd()
  {
    if (GameDataController.gd.getObjective("cs_thug_shot"))
      return;
    GameDataController.gd.setObjective("cs_guard_distracted", false);
  }

  public void reset() => CurtainController.cc.fadeOut(targetDir: WalkController.Direction.N, animation: "action1_e", flipX: true, actionAfterFade: new CurtainController.Delegate(this.myk), tSpeed: 0.01f);

  public void myk()
  {
    this.cs2.playerShot = false;
    this.cs2.shootArea = false;
    PlayerController.wc.currentXY.x = 55f;
    PlayerController.wc.currentXY.y = 15f;
    PlayerController.wc.clearTarget();
  }
}
