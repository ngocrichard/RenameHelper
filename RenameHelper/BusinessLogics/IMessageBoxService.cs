namespace RenameHelper.BusinessLogics
{
    public interface IMessageBoxService
    {
        void Show(string message, string caption = null);
    }
}
