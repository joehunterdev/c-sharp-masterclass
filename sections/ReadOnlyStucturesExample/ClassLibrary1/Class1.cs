public readonly struct Marvel
{
    private readonly string _characterName;

    public string CharacterName {
        get { return _characterName; } 
    }

    public void PrintCharacterName()
    {

        System.Console.WriteLine(this.CharacterName);
       // this._characterName = "abx"; // You cant do this

    }

    public Marvel( string CharacterName)
    {
        this._characterName = CharacterName;
    }

}
