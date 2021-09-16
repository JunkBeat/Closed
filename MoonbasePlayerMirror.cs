// Decompiled with JetBrains decompiler
// Type: MoonbasePlayerMirror
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\Don't Escape 4 Days in a Wasteland\dontescape_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MoonbasePlayerMirror : MonoBehaviour
{
  public SpriteRenderer spriteRenderer;
  public SpriteRenderer playerSprite;
  public string objectName;
  public bool doIEvenCare;

  private void Start()
  {
    this.doIEvenCare = true;
    if (this.objectName == "Ginger")
      this.doIEvenCare = GameDataController.gd.getObjective("npc1_alive") && !GameDataController.gd.getObjective("moon_cate_sleeps");
    if (this.objectName == "Npc2")
      this.doIEvenCare = GameDataController.gd.getObjective("npc2_alive") && !GameDataController.gd.getObjective("moon_barry_sleeps");
    if (this.objectName == "Npc3")
      this.doIEvenCare = GameDataController.gd.getObjective("npc3_alive") && !GameDataController.gd.getObjective("moon_cody_sleeps");
    this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
    if (!this.doIEvenCare)
      this.spriteRenderer.enabled = false;
    else
      this.spriteRenderer.enabled = true;
    if ((Object) this.playerSprite == (Object) null)
      this.playerSprite = GameObject.Find(this.objectName).GetComponent<SpriteRenderer>();
    this.spriteRenderer.sprite = this.playerSprite.sprite;
    this.spriteRenderer.flipX = this.playerSprite.flipX;
    this.spriteRenderer.flipY = true;
    this.gameObject.transform.position = new Vector3(this.playerSprite.gameObject.transform.position.x, this.playerSprite.gameObject.transform.position.y - 0.385f, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
  }
}
