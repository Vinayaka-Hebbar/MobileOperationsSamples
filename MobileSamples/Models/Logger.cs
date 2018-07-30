namespace MobileSamples.Models
{
    public abstract class Logger
    {
        public abstract void Log(string message);

        public abstract string GetLog();

        public abstract void SaveToFile(string fileName);

        public abstract void LoadFromFile(string fileName);
    }
}
