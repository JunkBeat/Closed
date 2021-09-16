// Decompiled with JetBrains decompiler
// Type: SiderealCaptionNote
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SiderealCaptionNote : MonoBehaviour
{
  public string nameToDisplay;
  private TextFieldController t;

  private void Start()
  {
    this.t = this.GetComponent<TextFieldController>();
    this.t.viewText(GameStrings.getString(GameStrings.world_labels, this.nameToDisplay), quick: true, instant: true, mwidth: 200, r: 0.2196078f, g: 0.2196078f, b: 0.3960784f, ba: 0.0f);
    this.t.keepAlive = true;
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
  }

  private void Update()
  {
  }
}
