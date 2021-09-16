// Decompiled with JetBrains decompiler
// Type: SiderealPCCaptionBlack
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class SiderealPCCaptionBlack : MonoBehaviour
{
  public string nameToDisplay;
  private TextFieldController t;

  private void Start()
  {
    this.t = this.GetComponent<TextFieldController>();
    this.t.viewText(GameStrings.getString(GameStrings.world_labels, this.nameToDisplay), quick: true, instant: true, mwidth: 100, r: 0.4352941f, g: 0.4352941f, b: 0.4352941f, ba: 0.0f);
    this.t.keepAlive = true;
  }

  private void Update()
  {
  }
}
