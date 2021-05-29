using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour
{

    public Material mat;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // src is the full rendered scene that you would normally send directly to the moniter.
        // We are intercepting this so we can do a bit more work, before passing it on.

        Graphics.Blit(source, destination, mat);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
