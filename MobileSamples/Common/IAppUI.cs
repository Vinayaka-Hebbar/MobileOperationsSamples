using MobileSamples.Controls;

namespace MobileSamples.Common
{
    public interface IAppUI
    {
        void OnStart(params object[] args);
        void OnResume(params object[] args);
        void OnStop();
        void OnLog(string message);
        void OnModal(Modal modal);
        void OnRestart();
    }
}
