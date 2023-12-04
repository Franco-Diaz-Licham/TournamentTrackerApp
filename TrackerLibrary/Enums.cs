
namespace TrackerLibrary
{
    // create a special type of array called enum which contains 2 elements
    // these will be used to pass the arugments to what datasource we want
    // the app to write to
    public enum DatabaseType
    {
        Sql,
        TextFile
    }
}
