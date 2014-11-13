﻿using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces.DTO;
using Tweetinvi.Core.Interfaces.Models;

namespace Tweetinvi.Logic.Model
{
    public class AccountSettings : IAccountSettings
    {
        private IAccountSettingsDTO _accountSettingsDTO;

        public AccountSettings(IAccountSettingsDTO accountSettingsDTO)
        {
            _accountSettingsDTO = accountSettingsDTO;
        }

        public IAccountSettingsDTO AccountSettingsDTO
        {
            get { return _accountSettingsDTO; }
            set { _accountSettingsDTO = value; }
        }

        public string ScreenName
        {
            get { return _accountSettingsDTO.ScreenName; }
        }

        public PrivacyMode PrivacyMode
        {
            get { return _accountSettingsDTO.PrivacyMode; }
        }

        public Language Language
        {
            get { return _accountSettingsDTO.Language; }
        }

        public bool AlwaysUseHttps
        {
            get { return _accountSettingsDTO.AlwaysUseHttps; }
        }

        public bool DiscoverableByEmail
        {
            get { return _accountSettingsDTO.DiscoverableByEmail; }
        }

        public bool GeoEnabled
        {
            get { return _accountSettingsDTO.GeoEnabled; }
        }

        public bool ShowAllInlineMedia
        {
            get { return _accountSettingsDTO.ShowAllInlineMedia; }
        }

        public bool UseCookiePersonalization
        {
            get { return _accountSettingsDTO.UseCookiePersonalization; }
        }

        public ITimeZone TimeZone
        {
            get { return _accountSettingsDTO.TimeZone; }
        }

        public ITrendLocation[] TrendLocations
        {
            get { return _accountSettingsDTO.TrendLocations; }
        }

        public bool SleepTimeEnabled
        {
            get { return _accountSettingsDTO.SleepTimeEnabled; }
        }

        public int SleepTimeStartHour
        {
            get { return _accountSettingsDTO.SleepTimeStartHour; }
        }

        public int SleepTimeEndHour
        {
            get { return _accountSettingsDTO.SleepTimeEndHour; }
        }
    }
}