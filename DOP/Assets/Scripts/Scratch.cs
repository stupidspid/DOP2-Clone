using UnityEngine;

public class Scratch : MonoBehaviour
{
    public Camera spriteCam;

    private static Scratch _scratch;
    public static Scratch I => _scratch;

    private void Awake()
    {
        _scratch = this;
    }

    public void AssignScreenAsMask() 
    {
        int height = Screen.height;
        int width = Screen.width;
        int depth = 1;

        RenderTexture renderTexture = new RenderTexture(width, height, depth);
        Rect rect = new Rect(0,0,width,height);
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);

        spriteCam.targetTexture = renderTexture;
        spriteCam.Render();

        RenderTexture currentRenderTexture = RenderTexture.active;
        RenderTexture.active = renderTexture;
        texture.ReadPixels(rect, 0, 0);
        texture.Apply();

        spriteCam.targetTexture = null;
        RenderTexture.active = currentRenderTexture;
        Destroy(renderTexture);

        Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f,0.5f), Screen.height/10);
    }

}
