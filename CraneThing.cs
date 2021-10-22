// Decompiled with JetBrains decompiler
// Type: CraneThing
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class CraneThing : MonoBehaviour
{
  public float targetX = 120f;
  public float targetY = 120f;
  public float currentX = 220f;
  public float currentY = 80f;
  public Sprite closed;
  public Sprite open;
  public float yyy = 20f;
  public GameObject metal;

  private void Start()
  {
  }

  public void updateState()
  {
    if (GameDataController.gd.getObjective("cs_pack_lifted"))
    {
      this.targetX = 160f;
      this.targetY = 30f;
    }
    else
    {
      this.targetX = !GameDataController.gd.getObjective("cs_crane_left") ? 220f : 160f;
      this.targetY = !GameDataController.gd.getObjective("cs_crane_down") ? 80f : 5f;
    }
    if (GameDataController.gd.getObjective("cs_crane_closed"))
      this.GetComponent<SpriteRenderer>().sprite = this.closed;
    else
      this.GetComponent<SpriteRenderer>().sprite = this.open;
  }

  private void Update()
  {
    float num = 30f;
    if ((double) this.targetY == 30.0)
      num = 10f;
    if ((double) this.targetX - (double) this.currentX < 1.0)
      this.currentX -= Time.deltaTime * 20f;
    if ((double) this.currentX - (double) this.targetX < 1.0)
      this.currentX += Time.deltaTime * 20f;
    if ((double) Mathf.Abs(this.targetX - this.currentX) < 1.0)
      this.currentX = this.targetX;
    if ((double) this.targetY - (double) this.currentY < 1.0)
      this.currentY -= Time.deltaTime * num;
    if ((double) this.currentY - (double) this.targetY < 1.0)
      this.currentY += Time.deltaTime * num;
    if ((double) Mathf.Abs(this.targetY - this.currentY) < 1.0)
      this.currentY = this.targetY;
    Vector2 vectorToChange1 = new Vector2();
    Vector2 vectorToChange2 = new Vector2();
    float z = this.gameObject.transform.position.z;
    vectorToChange1.x = this.currentX;
    vectorToChange1.y = this.currentY;
    vectorToChange1 = ScreenControler.gameToScreen(vectorToChange1);
    vectorToChange2.x = this.currentX;
    vectorToChange2.y = this.yyy;
    Vector2 screen = ScreenControler.gameToScreen(vectorToChange2);
    Vector3 position1 = new Vector3(vectorToChange1.x, vectorToChange1.y, this.gameObject.transform.position.z);
    Vector3 position2 = new Vector3(screen.x, screen.y, this.metal.transform.position.z);
    Vector3 screenPoint1 = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
    Vector3 screenPoint2 = Camera.main.WorldToScreenPoint(this.metal.transform.position);
    position1.z = screenPoint1.z;
    position2.z = screenPoint2.z;
    this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(position1);
    this.metal.transform.position = Camera.main.ScreenToWorldPoint(position2);
  }
}
