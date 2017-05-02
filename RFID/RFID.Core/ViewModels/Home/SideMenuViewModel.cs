﻿using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
    public class SideMenuViewModel : BaseViewModel
    {
        #region Cross Platform Commands & Handlers

        public IMvxCommand ShowHomeCommand
        {
            get { return new MvxCommand(ShowHomeExecuted); }
        }

        private void ShowHomeExecuted()
        {
            ShowViewModel<HomeViewModel>();
        }

        public IMvxCommand ShowPierCommand
        {
            get { return new MvxCommand(ShowPierExecuted); }
        }

        private void ShowPierExecuted()
        {
            ShowViewModel<PierViewModel>();
        }

        public IMvxCommand ShowDepartureCommand
        {
            get { return new MvxCommand(ShowDepartureExecuted); }
        }

        private void ShowDepartureExecuted()
        {
            ShowViewModel<DepartureViewModel>();
        }

        public IMvxCommand LogoutCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var user = await Mvx.Resolve<ISqliteService>().LoadUserAsync();
                    user.IsLoggedIn = false;
                    await Mvx.Resolve<ISqliteService>().UpdateAsync(user);
                    ShowViewModel<LoginViewModel>();
                });
            }
        }
        //public IMvxCommand ShowSettingCommand
        //{
        //    get { return new MvxCommand(ShowSettingsExecuted); }
        //}



        //public IMvxCommand ShowHelpCommand
        //{
        //    get { return new MvxCommand(ShowHelpExecuted); }
        //}

        //private void ShowHelpExecuted()
        //{
        //    ShowViewModel<HelpAndFeedbackViewModel>();
        //}

        #endregion

        #region Android Specific Demos

        //public IMvxCommand ShowRecyclerCommand
        //{
        //    get { return new MvxCommand(ShowRecyclerExecuted); }
        //}

        ////private void ShowRecyclerExecuted()
        ////{
        ////    ShowViewModel<ExampleRecyclerViewModel>();
        ////}

        //public IMvxCommand ShowViewPagerCommand
        //{
        //    get { return new MvxCommand(ShowViewPagerExecuted); }
        //}

        //private void ShowViewPagerExecuted()
        //{
        //    ShowViewModel<ExampleViewPagerViewModel>();
        //}

        #endregion
    }
}