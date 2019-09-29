namespace RenameHelper.BusinessLogics.Services
{
    public interface IMessageBoxService
    {
        void Show(string message, string caption = null);
    }
}
