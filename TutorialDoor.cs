// Decompiled with JetBrains decompiler
// Type: TutorialDoor
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TutorialDoor : ObjectActionController
{
  public Sprite painting;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "open_n";
    this.animationFlip = true;
    this.useCurrentDirection = false;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "tutorial_door";
    this.range = 1f;
  }

  public void creak1() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.door_creak_1);

  public void creak2() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.door_creak_2);

  public void creak3() => this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.door_creak_3);

  public override void clickAction()
  {
    if (GameDataController.gd.getObjective("tutorial_door_opened"))
      return;
    PlayerController.pc.GetComponent<Animator>().speed = 0.5f;
    GameDataController.gd.setObjective("tutorial_door_opened", true);
    this.gameObject.GetComponent<Animator>().Play("fence_door_open");
    this.GetComponent<AudioSource>().PlayOneShot(SoundsManagerController.sm.door_creak_open);
    this.setCollider(-1);
    GameObject.Find("Location").transform.Find("OtherPath").GetComponent<PolygonCollider2D>().enabled = true;
    GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = false;
    GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
  }

  public override void updateState()
  {
    if (!GameDataController.gd.getObjective("tutorial_door_opened"))
    {
      this.setCollider(0);
      this.gameObject.GetComponent<Animator>().Play("fence_door_creak");
      GameObject.Find("Location").transform.Find("OtherPath").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
    else
    {
      this.setCollider(-1);
      this.gameObject.GetComponent<Animator>().Play("fence_door_opened");
      GameObject.Find("Location").transform.Find("OtherPath").GetComponent<PolygonCollider2D>().enabled = true;
      GameObject.Find("Location").GetComponent<PolygonCollider2D>().enabled = false;
      GameObject.Find("Location").GetComponent<LocationManager>().initNodes();
    }
  }

  public override void clickAction2()
  {
    PlayerController.pc.GetComponent<Animator>().speed = 1f;
    GameObject.Find("tutorial_sledgehammer").GetComponent<TutorialHammer>().updateState();
  }

  public override void clickAction0()
  {
  }

  public override void whatOnClick0()
  {
  }

  public override void whatOnClick()
  {
  }
}
