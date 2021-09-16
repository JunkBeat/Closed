// Decompiled with JetBrains decompiler
// Type: CSCrowSprite
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class CSCrowSprite : MonoBehaviour
{
  public AudioSource aS;
  public Animator thug;
  public LocationCS2Start cs2;
  public bool free = true;

  private void Start()
  {
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0.0f, this.gameObject.transform.position.z);
    this.free = true;
  }

  private void Update()
  {
  }

  public void crowAttack()
  {
    this.free = true;
    if (!this.cs2.playerShot)
      this.thug.Play("thug_bird");
    this.aS.PlayOneShot(SoundsManagerController.sm.metal_thud);
  }

  public void makeCrowSound()
  {
    switch (Random.Range(0, 3))
    {
      case 0:
        this.aS.PlayOneShot(SoundsManagerController.sm.crow1);
        break;
      case 1:
        this.aS.PlayOneShot(SoundsManagerController.sm.crow2);
        break;
      default:
        this.aS.PlayOneShot(SoundsManagerController.sm.crow3);
        break;
    }
  }

  public void plask() => this.aS.PlayOneShot(ItemsManager.im.getItem("maggot").sound);

  public void makeFlappingSound() => this.aS.PlayOneShot(SoundsManagerController.sm.bird_fly);
}
