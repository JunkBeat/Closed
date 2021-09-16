// Decompiled with JetBrains decompiler
// Type: MapTextController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MapTextController : MonoBehaviour
{
  private TextFieldController textfield;

  private void Start()
  {
    this.textfield = GameObject.Find("TopText").GetComponent<TextFieldController>();
    this.updateTime();
  }

  private void Update()
  {
  }

  public void updateTime()
  {
    Vector3 timeColor = ClockController.getTimeColor();
    this.textfield.viewText(ClockController.getClockTimeWithRemaining(), quick: true, instant: true, mwidth: 200, r: timeColor.x, g: timeColor.y, b: timeColor.z, ba: 0.2f);
    this.textfield.keepAlive = true;
  }
}
