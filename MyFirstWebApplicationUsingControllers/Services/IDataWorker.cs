namespace MyFirstWebApplicationUsingControllers.Services
{
    public interface IDataWorker
    {
        void AddData(int value);
        int GetSum(int from, int till);
    }
}
