using DryPants.Resources;
using DryPants.Settings;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace DryPants.Test.Settings
{   
    public class DryAppSettingsTest
    {
        #region Tests

        [Fact]
        public void GetBoolAppSetting_ReturnsValidBool()
        {
            Assert.True(AppSettings.Instance.BoolAppSetting);
        } 
   
        [Fact]
        public void GetDecimalAppSetting_ReturnsValidDecimal()
        {
            Assert.Equal(100.000M, AppSettings.Instance.DecimalAppSetting);
        }

        [Fact]
        public void GetColorAppSetting_ReturnsValidColor()
        {
            Assert.Equal(Color.Red, AppSettings.Instance.ColorAppSetting);
        }

        [Fact]
        public void GetCustomEnumAppSettingAppSetting_ReturnsValidEnum()
        {
            Assert.Equal(CustomEnum.Value2, AppSettings.Instance.CustomEnumAppSetting);
        }
      
        [Fact]
        public void GetFileInfoAppSetting_ReturnsValidFileInfo()
        {
            Assert.Equal("Setup.exe", AppSettings.Instance.FileInfoAppSetting.Name);
        }

        [Fact]
        public void GetFileInfoAppSetting_ReturnsExpandedPath_WhenEnvironmentVariableInAppSetting()
        {
            Assert.False(AppSettings.Instance.FileInfoAppSetting.FullName.Contains("%TEMP%"));
        }

        [Fact]
        public void GetDirectoryInfoAppSetting_ReturnsValidDirectoryInfo()
        {
            Assert.Equal("MyApp", AppSettings.Instance.DirectoryInfoAppSetting.Name);
        }

        [Fact]
        public void GetDirectoryInfoAppSetting_ReturnsExpandedPath_WhenEnvironmentVariableInAppSetting()
        {
            Assert.False(AppSettings.Instance.DirectoryInfoAppSetting.FullName.Contains("%TEMP%"));
        }

        [Fact]
        public void GetRegexAppSetting_ReturnsValidRegex()
        {
            Assert.Equal(new Regex("^*.jpg$").ToString(), AppSettings.Instance.RegexAppSetting.ToString());
        }

        [Fact]
        public void GetVersionAppSetting_ReturnsValidVersion()
        {
            Assert.Equal(new Version(1, 0, 0, 0), AppSettings.Instance.VersionAppSetting);
        }

        [Fact]
        public void GetListAppSetting_ReturnsValidStringList()
        {
            Assert.Equal(3, AppSettings.Instance.ListAppSetting.Count);
            Assert.Equal("first", AppSettings.Instance.ListAppSetting[0]);
            Assert.Equal("second", AppSettings.Instance.ListAppSetting[1]);
            Assert.Equal("third", AppSettings.Instance.ListAppSetting[2]);
        }

        [Fact]
        public void GetClassWithStringConstructorAppSetting_ReturnsValidClassInstance()
        {
            CustomClassWithStringConstructor instance =
                AppSettings.Instance.CustomClassStringConstructorAppSetting;

            Assert.Equal("CustomClassStringConstructorAppSetting", instance.StringValue);
        }

        [Fact]
        public void GetClassCustomConverterAppSetting_ReturnsValidClassInstance()
        {
            CustomClassWithExoticConstructor instance =
                AppSettings.Instance.CustomClassExoticConstructorAppSetting;

            Assert.Equal("CustomClassExoticConstructorAppSetting", instance.StringValue);
            Assert.Equal(1, instance.OtherValue);
        }

        [Fact]
        public void GetClassCustomConverterAppSetting_ReturnsValidClassInstanceFromCache_WhenInvokedMoreThanOnce()
        {
            CustomClassWithExoticConstructor instance =
                AppSettings.Instance.CustomClassExoticConstructorAppSetting;
            
            Assert.Equal("CustomClassExoticConstructorAppSetting", instance.StringValue);
            Assert.Equal(1, instance.OtherValue);
        }

        [Fact]
        public void GetNonExistentAppSetting_ThrowsAppSettingDoesNotExistException()
        {
#pragma warning disable 168
            Assert.Throws<AppSettingDoesNotExistException>(() => AppSettings.Instance.NonExistentAppSetting);
#pragma warning restore 168
        }

        [Fact]
        public void GetAppStringSetting_DecoratedAppSetting_ReturnsValidResult()
        {
            Assert.Equal("BadNameForAppSetting", AppSettings.Instance.BetterNameForAppSetting);
        }

        [Fact]
        public void GetAppSettingCustomClass_ThrowsException_WhenAppSettingCannotBeConverted_()
        {
            Assert.Throws<ConvertAppSettingToTypeException>(() => AppSettings.Instance.BadAppSetting);
        }

        [Fact]
        public void GetAppSettingString_ReturnsValidStringResult_WhenAppSettingIsNotMocked()
        {
            var appSettings = new RealAppSettings();
            Assert.Equal("TestAppSettingValue", appSettings.TestAppSetting);
        }
        
        [Fact]
        public void GetAppSettingString_ReturnsValidStringResult_WhenExecutedOnMultipleThreads()
        {
            Action test = () => Assert.Equal("Setup.exe", AppSettings.Instance.FileInfoAppSetting.Name);
            test.OnMultipleThreads(numberOfThreads: 25);
        }

        #endregion

        #region Test classes

        private sealed class AppSettings : DryAppSettings
        {
            #region Fields

            // Mock the actual appSettings collection. Only needed because of Unit Test, not necessary in 'normal' situations.
            private static readonly NameValueCollection Values
                = new NameValueCollection
                      {
                          {"DecimalAppSetting", "100.000"},
                          {"BoolAppSetting", "true"},
                          {"VersionAppSetting", "1.0.0.0"},
                          {"ColorAppSetting", "Red"},
                          {"CustomEnumAppSetting", "Value2"},
                          {"DirectoryInfoAppSetting", @"%TEMP%\MyApp"},
                          {"FileInfoAppSetting", @"%TEMP%\MyApp\Setup.exe"},
                          {"RegexAppSetting", "^*.jpg$"},
                          {"CustomClassExoticConstructorAppSetting", "CustomClassExoticConstructorAppSetting"},
                          {"CustomClassStringConstructorAppSetting", "CustomClassStringConstructorAppSetting"},
                          {"ListAppSetting", "first, second, third"},
                          {"BadNameForAppSetting", "BadNameForAppSetting"},
                          {"BadAppSetting", "BadAppSetting"}
                      };

            #endregion

            #region Singleton

            private static readonly Lazy<AppSettings> LazyInstance =
                new Lazy<AppSettings>(() => new AppSettings());

            // Only needed because of Unit Test, not necessary in 'normal' situations.
            private AppSettings() : base(Values) { }

            public static AppSettings Instance
            {
                get { return LazyInstance.Value; }
            }

            #endregion

            #region Settings

            public Version VersionAppSetting
            {
                get { return GetAppSettingFor(() => VersionAppSetting); }
            }

            public Color ColorAppSetting
            {
                get { return GetAppSettingFor(() => ColorAppSetting); }
            }

            public CustomEnum CustomEnumAppSetting
            {
                get { return GetAppSettingFor(() => CustomEnumAppSetting); }
            }

            public DirectoryInfo DirectoryInfoAppSetting
            {
                get { return GetAppSettingFor(() => DirectoryInfoAppSetting); }
            }

            public FileInfo FileInfoAppSetting
            {
                get { return GetAppSettingFor(() => FileInfoAppSetting); }
            }

            public Regex RegexAppSetting
            {
                get { return GetAppSettingFor(() => RegexAppSetting); }
            }

            public bool BoolAppSetting
            {
                get { return GetAppSettingFor(() => BoolAppSetting); }
            }

            public decimal DecimalAppSetting
            {
                get { return GetAppSettingFor(() => DecimalAppSetting); }
            }

            public CustomClassWithExoticConstructor CustomClassExoticConstructorAppSetting
            {
                get { return GetAppSettingFor(() => CustomClassExoticConstructorAppSetting); }
            }

            public CustomClassWithStringConstructor CustomClassStringConstructorAppSetting
            {
                get { return GetAppSettingFor(() => CustomClassStringConstructorAppSetting); }
            }

            public IList<string> ListAppSetting
            {
                get { return GetAppSettingFor(() => ListAppSetting); }
            }

            public string NonExistentAppSetting
            {
                get { return GetAppSettingFor(() => NonExistentAppSetting); }
            }

            private string BadNameForAppSetting
            {
                get { return GetAppSettingFor(() => BadNameForAppSetting); }
            }

            public string BetterNameForAppSetting
            {
                get { return BadNameForAppSetting; }
            }

            public CustomClassWithoutConstructor BadAppSetting
            {
                get { return GetAppSettingFor(() => BadAppSetting); }
            }

            #endregion

            #region Custom Type conversion

            protected override T TypeConvertAppSetting<T>(string appSettingValue)
            {
                object returnValue;
                if (typeof(T) == typeof(CustomClassWithExoticConstructor))
                {
                    returnValue = new CustomClassWithExoticConstructor(appSettingValue, 1);
                }
                else
                {
                    returnValue = base.TypeConvertAppSetting<T>(appSettingValue);
                }
                return (T)returnValue;
            }

            #endregion
        }

        private sealed class RealAppSettings : DryAppSettings
        {
            public string TestAppSetting
            {
                get { return GetAppSettingFor(() => TestAppSetting); }
            }
        }

        #endregion

        #region Test types

        private enum CustomEnum
        {
            Value1,
            Value2
        }

        private sealed class CustomClassWithExoticConstructor
        {
            private readonly string _stringValue;
            private readonly int _otherValue;

            public CustomClassWithExoticConstructor(string stringValue, int otherValue)
            {
                _stringValue = stringValue;
                _otherValue = otherValue;
            }

            public string StringValue
            {
                get { return _stringValue; }
            }

            public int OtherValue
            {
                get { return _otherValue; }
            }
        }

        [UsedImplicitly]
        private sealed class CustomClassWithStringConstructor
        {
            private readonly string _stringValue;

            public CustomClassWithStringConstructor(string stringValue)
            {
                _stringValue = stringValue;
            }

            public string StringValue
            {
                get { return _stringValue; }
            }
        }

        [UsedImplicitly]
        private sealed class CustomClassWithoutConstructor
        {

        }

        #endregion
    }
}