import System.IO;

@MenuItem("Project Tools /Make Folders #&_g")

static function MakeFolder()
{
	GenerateFolders();
}

static function GenerateFolders()
{
	Debug.Log("test");
	path = Application.dataPath;
	//Models
	Directory.CreateDirectory(path + "/Models"); 
	Directory.CreateDirectory(path + "/Models/Static"); 
	Directory.CreateDirectory(path + "/Models/Animated"); 
	Directory.CreateDirectory(path + "/Models/Animations"); 
	Directory.CreateDirectory(path + "/Models/CharacterMesh"); 
	Directory.CreateDirectory(path + "/Materials"); 
	Directory.CreateDirectory(path + "/Materials/Alternative"); 
	Directory.CreateDirectory(path + "/Materials/Particles"); 
	Directory.CreateDirectory(path + "/Materials/Ground"); 
	Directory.CreateDirectory(path + "/Materials/Decals"); 
	Directory.CreateDirectory(path + "/GUI"); 
	Directory.CreateDirectory(path + "/Art"); 
	Directory.CreateDirectory(path + "/Documentation"); 
	Directory.CreateDirectory(path + "/Prefabs"); 
	Directory.CreateDirectory(path + "/Scripts"); 
	Directory.CreateDirectory(path + "/Scripts/Physics");
	Directory.CreateDirectory(path + "/Scripts/GameObjects"); 
	Directory.CreateDirectory(path + "/Scripts/Camera");
	Directory.CreateDirectory(path + "/Scripts/Levels");
	Directory.CreateDirectory(path + "/Scenes");    	
	Directory.CreateDirectory(path + "/Textures"); 
	Directory.CreateDirectory(path + "/Audio"); 
	Directory.CreateDirectory(path + "/Resources"); 
	Directory.CreateDirectory(path + "/Shaders"); 
	Directory.CreateDirectory(path + "/Packages");
	Directory.CreateDirectory(path + "/Fonts");	 
	Directory.CreateDirectory(path + "/Plugins");	 
	Directory.CreateDirectory(path + "/Packages");	 
	Directory.CreateDirectory(path + "/Misc");	 
}