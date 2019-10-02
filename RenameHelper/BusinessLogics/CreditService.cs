using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RenameHelper.BusinessLogics
{
    public class CreditService : ICreditService
    {
        private readonly IMessageBoxService messageBoxService;

        public CreditService(IMessageBoxService messageBoxService)
        {
            this.messageBoxService = messageBoxService;
        }

        public void ShowCredit()
        {
            string caption = "About Rename Helper";
            string message = "Rename Helper.\n"
                           + "Version 1.0.0.\n"
                           + "Made by NRC.";
            messageBoxService.Show(message, caption);
        }
    }
}
