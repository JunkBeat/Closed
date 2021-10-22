// Decompiled with JetBrains decompiler
// Type: LocationBaseOutside2GreenhouseBack
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LocationBaseOutside2GreenhouseBack : ObjectActionController
{
  public Sprite sprite1;
  public Sprite sprite2;
  public Sprite sprite3;
  public Sprite sprite4;
  public Sprite sprite5;
  private SpriteRenderer sr;

  private void Start()
  {
    this.sr = this.gameObject.GetComponent<SpriteRenderer>();
    this.dkvs = GameStrings.objects;
    this.objectName = "kitchen_exit";
  }

  public override void updateState()
  {
    if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 4)
      this.sr.sprite = this.sprite1;
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 3)
      this.sr.sprite = this.sprite2;
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 2)
      this.sr.sprite = this.sprite3;
    else if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") == 1)
    {
      this.sr.sprite = this.sprite4;
    }
    else
    {
      if (GameDataController.gd.getObjectiveDetail("greenhouse_nails") != 0)
        return;
      this.sr.sprite = this.sprite5;
    }
  }

  public override void whatOnClick()
  {
  }

  public override void clickAction()
  {
  }

  public void restore()
  {
  }

  public override void clickAction2()
  {
  }

  public override void clickAction0()
  {
  }
}
