namespace AopSample.ApplicationServices
{
    public interface ILog
    {
        void Debug(string message);

        void Error(string message);
    }
}