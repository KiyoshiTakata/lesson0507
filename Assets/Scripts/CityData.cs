public class CityData
{
    public CityData(string i_id, string i_name)
    {
        ID = i_id;
        Name = i_name;
    }
    public string ID
    {
        get;
        private set;
    }
    public string Name
    {
        get;
        private set;
    }
}