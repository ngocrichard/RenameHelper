using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RenameHelper.BusinessLogics
{
    public class MessageBoxService : IMessageBoxService
    {
        public void Show(string message, string caption = null)
        {
            if (caption == null)
                MessageBox.Show(message);
            else
                MessageBox.Show(message, caption);
        }
    }
}
