using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace RubiksApp
{
    public static class HyperlinkExtensions
    {
        public static readonly DependencyProperty ShouldLaunchBrowserProperty = 
            DependencyProperty.RegisterAttached("ShouldLaunchBrowser", typeof(bool), typeof(HyperlinkExtensions),
            new UIPropertyMetadata(false, OnShouldLaunchBrowserPropertyChanged));
        
        public static bool GetShouldLaunchBrowser(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShouldLaunchBrowserProperty);
        }

        public static void SetShouldLaunchBrowser(DependencyObject obj, bool value)
        {
            obj.SetValue(ShouldLaunchBrowserProperty, value);
        }

        private static void OnShouldLaunchBrowserPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Hyperlink link = (Hyperlink)d;
            bool newValue = (bool)e.NewValue;
            
            if(newValue)
            {
                link.RequestNavigate += link_RequestNavigate;
            }
            else
            {
                link.RequestNavigate -= link_RequestNavigate;
            }
        }

        static void link_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
        }
    }


}
