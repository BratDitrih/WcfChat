using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WcfChatClient
{
    public static class Extensions
    {
        public static void ScrollToBottom(this ListBox listbox)
        {
            if (VisualTreeHelper.GetChildrenCount(listbox) > 0)
            {
                Border border = (Border)VisualTreeHelper.GetChild(listbox, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.ScrollToBottom();
            }
        }
    }
}
