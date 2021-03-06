﻿using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using RFID.Core.Interfaces;
using RFID.Core.Models;
using RFID.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.ViewModels
{
   public class HomeViewModel : BaseViewModel
    {

        private void EnableApps(string appAccess)
        {

            IsPierVisible = appAccess.Contains("Pier");
            IsDepartureVisible = appAccess.Contains("Departure");
            IsArrivalVisible = appAccess.Contains("Arrival");
            IsClaimVisible = appAccess.Contains("Claim");
            IsBSOVisible = appAccess.Contains("BSO");
        }

        private bool isPierVisible;

        public bool IsPierVisible
        {
            get { return isPierVisible; }
            set { isPierVisible = value; RaisePropertyChanged(() => IsPierVisible); }
        }

        private bool isDepartureVisible;

        public bool IsDepartureVisible
        {
            get { return isDepartureVisible; }
            set { isDepartureVisible = value; RaisePropertyChanged(() => IsDepartureVisible); }
        }

        private bool isArrivalVisible;

        public bool IsArrivalVisible
        {
            get { return isArrivalVisible; }
            set { isArrivalVisible = value; RaisePropertyChanged(() => IsArrivalVisible); }
        }

        private bool isClaimVisible;

        public bool IsClaimVisible
        {
            get { return isClaimVisible; }
            set { isClaimVisible = value; RaisePropertyChanged(() => IsClaimVisible); }
        }

        private bool isBSOVisible;

        public bool IsBSOVisible
        {
            get { return isBSOVisible; }
            set { isBSOVisible = value; RaisePropertyChanged(() => IsPierVisible); }
        }

        private List<string> appAccess;

        public List<string> AppAccess

        {
            get { return appAccess; }
            set { appAccess = value; }
        }

        public IMvxCommand ShowPeirCommand
        {
            get { return new MvxCommand(ShowPeirExecuted); }
        }


        private void ShowPeirExecuted()
        {
            try
            {
                //logger.Trace("ShowViewModel : PierClaimLocationViewModel")
                ShowViewModel<PierClaimLocationViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

        public IMvxCommand ShowDepartureCommand
        {
            get { return new MvxCommand(ShowDepartureExecuted); }
        }

        private void ShowDepartureExecuted()
        {
            try
            {
                //logger.Trace("ShowViewModel : FlightEntryViewModel")
                ShowViewModel<FlightEntryViewModel>();
            }
            catch (Exception e)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
        }

        public async void InitializeButton()
        {
            ProgressBarVisible = true;
            try
            {
                //logger.Trace("SqliteService<UserModel> : LoadUser")
                ISqliteService<UserModel> userRepo = new SqliteService<UserModel>();
                var user = await userRepo.Load();
                EnableApps(user.AppAccess);
            }
            catch (Exception)
            {
                Mvx.Resolve<IUserDialogs>().Toast("An error occurred!", null);
                //logger.Log(LogLevel.Info,e.ToString);
            }
            ProgressBarVisible = false;
        }

    }

}
