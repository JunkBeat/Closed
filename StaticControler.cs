// Decompiled with JetBrains decompiler
// Type: StaticControler
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class StaticControler : MonoBehaviour
{
  public Vector3 vvv;
  private Vector3 pos;
  private Sprite sprite;
  private SpriteRenderer spriteRenderer;
  public static int static_power;
  private float time;

  private void Start()
  {
    this.pos = new Vector3(0.0f, 0.0f, -1f);
    this.sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    this.spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, (float) (0.300000011920929 * (double) PlayerPrefs.GetInt("stati") / 100.0));
    this.time = 0.0f;
    StaticControler.static_power = PlayerPrefs.GetInt("stati");
  }

  private void Update()
  {
    this.time += Time.deltaTime;
    if ((double) this.time < 0.02)
      return;
    this.time = 0.0f;
    this.spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, (float) ((double) Random.Range(0.2f, 0.3f) * (double) StaticControler.static_power / 100.0));
    int width = this.sprite.texture.width;
    int height = this.sprite.texture.height;
    this.vvv = (Vector3) new Vector2((float) Random.Range(-240, 480), (float) Random.Range(-144, 270));
    Vector2 screen = ScreenControler.gameToScreen((Vector2) this.vvv);
    this.pos.x = screen.x;
    this.pos.y = screen.y;
    this.pos = Camera.main.ScreenToWorldPoint(this.pos);
    this.pos.z = -6.25f;
    this.gameObject.transform.position = this.pos;
  }
}
