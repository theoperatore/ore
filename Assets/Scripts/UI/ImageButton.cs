using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ImageButton
{
    private readonly string ussClass = "image-button";

    // todo: tis should come from a scriptable object that defines the behavior of this button
    private readonly string btnName = "default button name";
    private readonly Action<string> onClicked;
    private readonly Button btn = default;

    public ImageButton(string btnName, Texture2D texture, Action<string> onClicked)
    {
        this.btnName = btnName;
        this.onClicked = onClicked;

        // texture should come from scriptable object
        var img = new Image { image = texture };
        img.style.width = 54;
        img.style.height = 54;

        btn = new Button(HandleClicked);
        btn.Add(img);
        btn.AddToClassList(ussClass);
    }

    public Button GetElement()
    {
        return btn;
    }

    private void HandleClicked()
    {
        onClicked?.Invoke(btnName);
    }
}
