class Armas
{
    var nombre : String = "";
    var icono : Texture2D;
    var prefab : GameObject;
    //var drawWeaponAnim : Animation;
}

public var armas : Armas[];
public var tamanoBoton : Vector2 = Vector2(50, 50);
public var propagacion : float = 100;
public var iconoEstilo : GUIStyle;
//public var pistolaActiva : bool;

private var armaSeleccionada : int;
private var guiSettingsApplied : boolean;
private var fxClamp : float;
private var curFXFloat : float;
private var buttonRect : Rect;


function Start()
{
    for(var i = 0; i < armas.Length; i++)
    {
        if(i != armaSeleccionada) armas[i].prefab.SetActive(false);
        else armas[i].prefab.SetActive(true);
    }
}

function Update()
{
    if(Input.GetKeyDown("1"))
    {
        if(fxClamp == 0) fxClamp = 1;
        else fxClamp = 0;
    }
    if(curFXFloat != fxClamp) curFXFloat = Mathf.MoveTowards(curFXFloat, fxClamp, Time.deltaTime * 5);

    /*if (armas[4].activeSelf){
        pistolaActiva = true;
    }*/
}

function OnGUI()
{
    if(curFXFloat != 0.0)
    {
        GUI.color.a = curFXFloat;
        var fxOffset = propagacion * (1.0 + (1.0 - curFXFloat));
        for(var i : float = 0; i < armas.Length; i++)
        {
            var progression = i / armas.Length;
            var angle = progression * Mathf.PI * 2 + curFXFloat;
            buttonRect = Rect(Screen.width/2.0 + (Mathf.Sin(angle) * fxOffset) - (tamanoBoton.x/2.0), Screen.height/2 + (Mathf.Cos(angle) * fxOffset) - (tamanoBoton.y/2.0), tamanoBoton.x, tamanoBoton.y);
            if(buttonRect.Contains(Event.current.mousePosition))
            {
                buttonRect.width *= 1.2;
                buttonRect.height *= 1.2;
                buttonRect.x -= (buttonRect.width - tamanoBoton.x) / 2.0;
                buttonRect.y -= (buttonRect.height - tamanoBoton.y) / 2.0;
            }
            if(armas[i].icono)
            {
                iconoEstilo.normal.background = armas[i].icono;
                if(GUI.Button(buttonRect, "", iconoEstilo))
                {
                    SwapWeapons(i);
                }
            }
            else
            {
                iconoEstilo.normal.background = null;
                if(GUI.Button(buttonRect, armas[i].nombre, iconoEstilo))
                {
                    SwapWeapons(i);
                }
            }
        }
        if(armas[armaSeleccionada].icono) GUI.DrawTexture(Rect(Screen.width/2 - (tamanoBoton.x/2.0), Screen.height/2 - (tamanoBoton.y/2.0), tamanoBoton.x, tamanoBoton.y), armas[armaSeleccionada].icono);
        else GUI.Label(Rect(Screen.width/2 - (tamanoBoton.x/2.0), Screen.height/2 - (tamanoBoton.y/2.0), tamanoBoton.x, tamanoBoton.y), armas[armaSeleccionada].Name);
    }
}

function SwapWeapons(to : int)
{
    armas[armaSeleccionada].prefab.SetActive(false);
    armas[to].prefab.SetActive(true);
    armaSeleccionada = to;
    //armas[to].animation;
}