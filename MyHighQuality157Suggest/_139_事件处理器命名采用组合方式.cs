using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    public class _139_事件处理器命名采用组合方式
    {
        public delegate void ButtonHandler(object sender,EventArgs e);
        public event ButtonHandler Click;

        public void Test01()
        {
            Click += Button_SizeChanged;
            Click += Button_Click;
            Click += MainWindow_MouseDown;
        }

        private class SizeChangedEventArgs : EventArgs
        {

        }

        private void Button_SizeChanged(object sender, EventArgs e)
        {
            if (e is SizeChangedEventArgs)
            {
                var x = e as SizeChangedEventArgs;
            }
        }

        public class RoutedEventArgs : EventArgs
        {
            
        }

        private void Button_Click(object sender, EventArgs e)
        {

        }

        public class MouseButtonEventArgs : EventArgs
        {

        }

        private void MainWindow_MouseDown(object sender, EventArgs e)
        {

        }

    }
}
