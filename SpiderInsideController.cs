// Decompiled with JetBrains decompiler
// Type: SpiderInsideController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpiderInsideController : ObjectActionController
{
  private float realX = -0.825f;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.animationFlip = false;
    this.characterAnimationName = "stop";
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "nasty_spider";
    this.teleport = true;
    this.updateState();
    this.gameObject.GetComponent<Animator>().Play("walk");
    this.setCollider(0);
  }

  private void Update()
  {
    this.gameObject.transform.position = new Vector3(this.realX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    if (GameDataController.gd.getCurrentDay() != 1 || !GameDataController.gd.getObjective("gasstation_spider_baited") || GameDataController.gd.getObjective("gasstation_spider_shot"))
      return;
    this.realX += (float) (0.00400000018998981 * (double) Time.deltaTime * 60.0);
    if ((double) this.realX > -0.256000012159348)
    {
      this.realX = -0.256f;
      this.gameObject.GetComponent<Animator>().Play("tease");
    }
    else
      this.gameObject.GetComponent<Animator>().Play("walk");
    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
  }

  public override void clickAction()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void updateState()
  {
    if (GameDataController.gd.getCurrentDay() == 1 && GameDataController.gd.getObjective("gasstation_spider_baited") && !GameDataController.gd.getObjective("gasstation_spider_shot"))
      this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    else
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
