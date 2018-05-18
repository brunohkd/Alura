using App1.Models;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	public partial class MasterView : ContentPage
	{

        public MasterViewModel ViewModel { get; set; }

		public MasterView (/*Usuario usuario*/)
		{
			InitializeComponent ();

            //this.ViewModel = new MasterViewModel(usuario);

            //this.BindingContext = this.ViewModel;
		}
	}
}