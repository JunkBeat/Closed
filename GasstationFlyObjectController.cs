// Decompiled with JetBrains decompiler
// Type: GasstationFlyObjectController
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GasstationFlyObjectController : MonoBehaviour
{
  private bool flying;
  private float realX;
  private float realY;

  private void Start()
  {
    this.realX = -0.06f;
    this.realX = -0.111f;
    this.flying = false;
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
  }

  private void Update()
  {
    if (!this.flying)
      return;
    this.gameObject.transform.position = new Vector3(this.realX, this.realY, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.realX -= (float) (0.00499999988824129 * (double) Time.deltaTime * 60.0 * 1.5);
    this.realY -= (float) (0.00999999977648258 * (double) Time.deltaTime * 60.0 * 1.5);
    if ((double) this.realY >= -0.5)
      return;
    this.realX = -0.065f;
    this.realY = -0.111f;
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
  }

  public void fly(Item item)
  {
    this.gameObject.GetComponent<SpriteRenderer>().sprite = item.groundSprite;
    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    this.flying = true;
  }
}
