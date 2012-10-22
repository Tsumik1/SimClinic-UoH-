//Original credit Eric Haines. 

//Modified by Blake Kendrick.
var normalCursor : Texture2D;        // The texture for when the cursor isn't near a screen edge
var leftCursor : Texture2D;          // The texture for the cursor when it's at the left edge
var rightCursor : Texture2D;         // Ditto, right edge
var upCursor : Texture2D;            // Top edge
var downCursor : Texture2D;          // ...And bottom edge
var nativeRatio = 1.3333333333333;   // Aspect ratio of the monitor used to set up GUI elements
private var lastPosition : Vector3;  // Where the mouse position was last
var normalAlpha = .5;                // Normal alpha value of the cursor ... .5 is full
var fadeTo = .2;                     // The alpha value the cursor fades to if not moved
var fadeRate = .22;                  // The rate at which the cursor fades
private var cursorIsFading = true;   // Whether we should fade the cursor
private var fadeValue : float;
 
// Scale the cursor so it should look right in any aspect ratio, and turn off the OS mouse pointer
function Start() {
    // Slightly weird but necessary way of forcing float evaluation
    var currentRatio : float = (0.0 + Screen.width) / Screen.height;
    transform.localScale.x *= nativeRatio / currentRatio;
    //Screen.showCursor = false;
    fadeValue = normalAlpha;
    lastPosition = Input.mousePosition;
}
 
function Update() {
    var mousePos = Input.mousePosition;
    // If the mouse has moved since the last update
    if (mousePos != lastPosition) {
    	lastPosition = mousePos;
        // Get mouse X and Y position as a percentage of screen width and height
        MoveMouse(mousePos.x/Screen.width, mousePos.y/Screen.height);
    }
    // Fade the alpha of the cursor
    if (cursorIsFading) {
        guiTexture.color.a = fadeValue;
        fadeValue -= fadeRate * Time.deltaTime;
        if (fadeValue < fadeTo) {
            fadeValue = fadeTo;
            cursorIsFading = false;
        }
    }
    
    MoveCamera(mousePos.x/Screen.width, mousePos.y/Screen.height);
}
 
function MoveMouse(mousePosX : float, mousePosY : float) {
    // Make the cursor solid, and set fading to start in case mouse movement stops
    guiTexture.color.a = fadeValue = normalAlpha;
    guiTexture.texture = null;
    Screen.showCursor = true;
    cursorIsFading = true;
 
    // If the mouse is on a screen edge, first make sure the cursor doesn't go off the screen, then give it the appropriate cursor
    if (mousePosX < .05) {
        mousePosX = .05;
        guiTexture.texture = leftCursor;
        Screen.showCursor = false;
    }
    if (mousePosX > .900) {
        mousePosX = .900;
        guiTexture.texture = rightCursor;
        Screen.showCursor = false;
        
    }
    if (mousePosY < .05) {
        mousePosY = .05;
        guiTexture.texture = downCursor;
        Screen.showCursor = false;
        
    }
    if (mousePosY > .890) {
        mousePosY = .890;
        guiTexture.texture = upCursor;
        Screen.showCursor = false;
        
    }
 
    transform.position.x = mousePosX;
    transform.position.y = mousePosY;
    
}


function MoveCamera(mousePosX : float, mousePosY : float)
{
	  if (mousePosX < .001) {
	  
            Camera.main.transform.Translate(-0.1f, 0, 0);
            
    }
    if (mousePosX > .900) {
			 
            Camera.main.transform.Translate(0.1f, 0, 0);
    }
    if (mousePosY < .001) {
        Camera.main.transform.Translate(0,-0.1f,0);
    }
    if (mousePosY > .900) {
    	Camera.main.transform.Translate(0,0.1f,0);
    }

}