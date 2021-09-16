// Decompiled with JetBrains decompiler
// Type: LocationMoonAirlockR1A
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System.Collections.Generic;
using UnityEngine;

public class LocationMoonAirlockR1A : ObjectActionController
{
  public SpriteRenderer sr;
  public bool left;
  public int number;
  public AudioSource audioSource;
  public List<Sprite> sprites;

  private void Start()
  {
    this.colliderManager.setTarget(this.gameObject);
    this.characterAnimationName = "stop";
    this.animationFlip = false;
    this.useCurrentDirection = true;
    this.actionMarker = this.gameObject.transform.Find("Action_Marker").gameObject;
    this.dkvs = GameStrings.objects;
    this.objectName = "airlock_ring_" + (object) this.number + "_";
    if (this.left)
      this.objectName += "a";
    else
      this.objectName += "b";
    this.teleport = true;
    this.range = 2000f;
    this.audioSource = this.gameObject.GetComponent<AudioSource>();
  }

  public void leave()
  {
    PlayerController.pc.spawnName = "LocationMoon2_Airlock";
    CurtainController.cc.fadeOut("Moon2", WalkController.Direction.N);
  }

  public void doorop() => this.audioSource.PlayOneShot(SoundsManagerController.sm.slidedoor);

  public void unlock() => PlayerController.pc.setBusy(false);

  public override void clickAction()
  {
    int objectiveDetail = GameDataController.gd.getObjectiveDetail("airlock_ring_" + (object) this.number);
    int detail = this.left ? objectiveDetail - 1 : objectiveDetail + 1;
    if (detail < 0)
      detail = 7;
    if (detail >= 8)
      detail = 0;
    GameDataController.gd.setObjectiveDetail("airlock_ring_" + (object) this.number, detail);
    this.audioSource.pitch = Random.Range(0.9f, 1.1f);
    switch (Random.Range(1, 4))
    {
      case 1:
        this.audioSource.clip = SoundsManagerController.sm.slide_1;
        break;
      case 2:
        this.audioSource.clip = SoundsManagerController.sm.slide_2;
        break;
      default:
        this.audioSource.clip = SoundsManagerController.sm.slide_3;
        break;
    }
    this.audioSource.Play();
    PlayerController.pc.setBusy(true);
    if (GameDataController.gd.getObjectiveDetail("airlock_ring_1") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_2") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_3") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_4") == 0 && GameDataController.gd.getObjectiveDetail("airlock_ring_5") == 0)
    {
      this.audioSource.PlayOneShot(SoundsManagerController.sm.unlock);
      this.Invoke("doorop", 0.75f);
      this.Invoke("leave", 2.5f);
    }
    else
      this.Invoke("unlock", 0.3f);
    this.updateAll();
  }

  public override void updateState() => this.sr.sprite = this.sprites[GameDataController.gd.getObjectiveDetail("airlock_ring_" + (object) this.number)];

  public override void clickAction2()
  {
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
