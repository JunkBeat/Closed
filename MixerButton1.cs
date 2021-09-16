// Decompiled with JetBrains decompiler
// Type: MixerButton1
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class MixerButton1 : ObjectActionController
{
  private SpriteRenderer sr;
  public Sprite sprite_on;
  public Sprite sprite_off;
  public Sprite sprite_wr;
  private int liczba;
  public string thisNumber;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "action_stnd_";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "mixer_button_small";
    this.range = 8000f;
    this.teleport = false;
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.updateState();
  }

  private void Update()
  {
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
    this.countThem();
    if (GameDataController.gd.getObjective("sidereal_mixer_" + this.thisNumber))
    {
      GameDataController.gd.setObjective("sidereal_mixer_" + this.thisNumber, false);
      this.updateAll();
    }
    else if ((this.thisNumber == "b1" || this.thisNumber == "b2" || this.thisNumber == "b3") && GameDataController.gd.getObjective("sidereal_components_1") || (this.thisNumber == "b4" || this.thisNumber == "b5" || this.thisNumber == "b6") && GameDataController.gd.getObjective("sidereal_components_2"))
    {
      if (this.liczba < 3)
      {
        GameDataController.gd.setObjective("sidereal_mixer_" + this.thisNumber, true);
        this.updateAll();
      }
      else
      {
        this.sr.sprite = this.sprite_wr;
        this.setCollider(-1);
        this.Invoke("updateAll", 0.1f);
      }
    }
    else
    {
      this.sr.sprite = this.sprite_wr;
      this.setCollider(-1);
      this.Invoke("updateAll", 0.1f);
    }
    PlayerController.pc.aS.PlayOneShot(SoundsManagerController.sm.button_click);
  }

  private void countThem()
  {
    this.liczba = 0;
    if (GameDataController.gd.getObjective("sidereal_mixer_b1"))
      ++this.liczba;
    if (GameDataController.gd.getObjective("sidereal_mixer_b2"))
      ++this.liczba;
    if (GameDataController.gd.getObjective("sidereal_mixer_b3"))
      ++this.liczba;
    if (GameDataController.gd.getObjective("sidereal_mixer_b4"))
      ++this.liczba;
    if (GameDataController.gd.getObjective("sidereal_mixer_b5"))
      ++this.liczba;
    if (!GameDataController.gd.getObjective("sidereal_mixer_b6"))
      return;
    ++this.liczba;
  }

  public override void updateState()
  {
    this.setCollider(0);
    if (GameDataController.gd.getObjective("sidereal_mixer_" + this.thisNumber))
      this.sr.sprite = this.sprite_on;
    else
      this.sr.sprite = this.sprite_off;
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
