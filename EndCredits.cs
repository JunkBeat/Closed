// Decompiled with JetBrains decompiler
// Type: EndCredits
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EndCredits : MonoBehaviour
{
  private void Start() => this.hide();

  private void Update()
  {
  }

  public void hide() => this.GetComponent<SpriteRenderer>().enabled = false;

  public void showDontEscape()
  {
    this.GetComponent<SpriteRenderer>().enabled = true;
    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -0.625f, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel3(this.gameObject.transform.position);
  }

  public void showBlack()
  {
    this.GetComponent<SpriteRenderer>().enabled = true;
    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0.625f, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel3(this.gameObject.transform.position);
  }
}
