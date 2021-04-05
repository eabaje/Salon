using Salon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Application.Interfaces
{
    public interface ISettingService
    {
        Setting GetSettingById(int settingId);

        string GetSettingByKey(string key, string defaultValue);

        T GetSettingByKey<T>(string key, T defaultValue);

        IList<Setting> GetAllSettings();

        void UpdateSetting(Setting setting);
    }
}
