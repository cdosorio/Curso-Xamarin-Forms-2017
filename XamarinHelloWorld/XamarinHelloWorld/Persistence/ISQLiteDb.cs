using SQLite;

namespace XamarinHelloWorld
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

