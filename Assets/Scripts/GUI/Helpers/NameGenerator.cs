
using UnityEngine;
using System.Collections;
using System.Text;

public class NameGenerator
{
private string[] maleFirstName;
private string[] maleMidName;
private string[] maleEndName;

private string[] femaleFirstName;
private string[] femaleMidName;
private string[] femaleEndName;

private bool isMale;

private int minRange = 0;
private int maxRange;
private int nextNum;

private string charName;
public string CharName {
get {
return this.charName;
}
set {
charName = value;
}
}

private int nameLength;
private int nameLevel;

private string nextString;

public NameGenerator()
{
maleFirstName = new string[40]{"Bjorn ", "Val ", "L'aurent ", "Joseph ", "Mica ", "Dennison ", "Blake ", 
								"Jim ", "Paul ", "Benjii ","Duane ","Andrew ","Graham ","Steven ","Lex ", "Mohammed ", 
								"Jesus ","Mario ","John ","James ","Jimmy ","Grant ", "Trevor ", "Alex ","Scott ","Richard ",
								"Mark ","Roger ","Dennis ","Patrick ","Joe ","Nathan ","Lee ","Tom ","Ben ","Lewisham ","Dave ",
								"David ","Micheal ","Mick "};
maleMidName = new string[8]{"Lasse ", "Dirk ", "Clint ", "James ", "Peter ", "Dave ", "Steve ", "Joe "};
maleEndName = new string[10]{"Bjerre", "De-Santos", "Taylor", "Smith", "Harvery", "Spence", "Davies", "Porter", "Cobb", "Gooch"};

femaleFirstName = new string[6]{"Mary ", "Jane ", "Jenna ", "Sarah ", "Val ", "Heidi "};
femaleMidName = new string[8]{"Elisabeth ", "Francis ", "Kerry ", "Carol ", "Polly ", "Clare ", "Susan ", "Louise "};
femaleEndName = new string[10]{"Bjerre", "De-Santos", "Taylor", "Smith", "Harvery", "Spence", "Davies", "Porter", "Cobb", "Gooch"};
}

public string CreateName(bool maleName, int charNameLength)
{
nameLevel = 1;

isMale = maleName;
nameLength = charNameLength;

return GenerateName();
}

public string GenerateName()
{
StringBuilder cName = new StringBuilder();

for(int i= 0; i < nameLength; i++)
{
cName.Append(PickName());
}

CharName = cName.ToString();
Debug.Log("Name: " + CharName);
		return CharName;
}

private string PickName()
{
if(nameLevel == 1)
{
if(isMale)
nextString = maleFirstName[SetRange(maleFirstName.Length)];
else
nextString = femaleFirstName[SetRange(femaleFirstName.Length)];
}

if(nameLevel >= 2 && nameLevel < nameLength)
{
if(isMale)
nextString = maleMidName[SetRange(maleMidName.Length)];
else
nextString = femaleMidName[SetRange(femaleMidName.Length)];
}

if(nameLevel == nameLength)
{
if(isMale)
nextString = maleEndName[SetRange(maleEndName.Length)];
else
nextString = femaleEndName[SetRange(femaleEndName.Length)];
}

nameLevel++;

return nextString;
}

private int SetRange(int cnt)
{
nextNum = Random.Range(minRange, cnt);
return nextNum;
}

void Update()
{
if(Input.GetKeyDown(KeyCode.F))
{
nameLength = Random.Range(2, 4);
CreateName(false, nameLength);
}
if(Input.GetKeyDown(KeyCode.M))
{
nameLength = Random.Range(2, 4);
CreateName(true, nameLength);
}
}
}