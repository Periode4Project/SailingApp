using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sailing
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
        //public class MyTab : TabBar
        //{
        //    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //    {
        //        if (propertyName == "CurrentItem")
        //        {
        //            int index = this.Items.IndexOf(this.CurrentItem);
        //            if (index == 1)
        //            {
        //                Navigation.PopToRootAsync();
        //            }

        //        }
        //    }
        //}
    }
}