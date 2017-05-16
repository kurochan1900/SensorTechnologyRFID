using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using RFID.Core.ViewModels;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace RFID.Droid.Views
{
    [MvxFragment(typeof(MainMenuViewModel), Resource.Id.content_frame)]
    [Register("RFID.Droid.Views.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ((MainMenuView)Activity).Title = "Home";
            ShowHamburgerMenu = true;

            var view = base.OnCreateView(inflater, container, savedInstanceState);
            ViewModel.InitializeButton();
            return view;
        }

        protected override int FragmentId => Resource.Layout.fragment_home;
        protected override ColorDrawable backcolor => new ColorDrawable(Color.ParseColor("#3E50B4"));

    }
}