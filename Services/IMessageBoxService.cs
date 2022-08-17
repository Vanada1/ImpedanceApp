namespace Services
{
    public interface IMessageBoxService
    {
        void Show(string massage, MessageBoxButton button, MessageBoxIcon icon);
    }
}