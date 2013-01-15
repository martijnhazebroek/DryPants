using DryPants.Resources;
using DryPants.Settings;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace DryPants.Test.Settings
{
    [TestClass]
    public class DryAppSettingsTest
    {
        #region Tests

        [TestMethod]
        public void GetBoolAppSetting_ReturnsValidBool()
        {
            Assert.IsTrue(AppSettings.Instance.BoolAppSetting);
        } 
   
        [TestMethod]
        public void GetDecimalAppSetting_ReturnsValidDecimal()
        {
            Assert.AreEqual(100.000M, AppSettings.Instance.DecimalAppSetting);
        }

        [TestMethod]
        public void GetColorAppSetting_ReturnsValidColor()
        {
            Assert.AreEqual(Color.Red, AppSettings.Instance.ColorAppSetting);
        }

        [TestMethod]
        public void GetCustomEnumAppSettingAppSetting_ReturnsValidEnum()
        {
            Assert.AreEqual(CustomEnum.Value2, AppSettings.Instance.CustomEnumAppSetting);
        }
      
        [TestMethod]
        public void GetFileInfoAppSetting_ReturnsValidFileInfo()
        {
            Assert.AreEqual("Setup.exe", AppSettings.Instance.FileInfoAppSetting.Name);
        }

        [TestMethod]
        public void GetFileInfoAppSetting_ReturnsExpandedPath_WhenEnvironmentVariableInAppSetting()
        {
            Assert.IsFalse(AppSettings.Instance.FileInfoAppSetting.FullName.Contains("%TEMP%"));
        }

        [TestMethod]
        public void GetDirectoryInfoAppSetting_ReturnsValidDirectoryInfo()
        {
            Assert.AreEqual("MyApp", AppSettings.Instance.DirectoryInfoAppSetting.Name);
        }

        [TestMethod]
        public void GetDirectoryInfoAppSetting_ReturnsExpandedPath_WhenEnvironmentVariableInAppSetting()
        {
            Assert.IsFalse(AppSettings.Instance.DirectoryInfoAppSetting.FullName.Contains("%TEMP%"));
        }

        [TestMethod]
        public void GetRegexAppSetting_ReturnsValidRegex()
        {
            Assert.AreEqual(new Regex("^*.jpg$").ToString(), AppSettings.Instance.RegexAppSetting.ToString());
        }

        [TestMethod]
        public void GetVersionAppSetting_ReturnsValidVersion()
        {
            Assert.AreEqual(new Version(1, 0, 0, 0), AppSettings.Instance.VersionAppSetting);
        }

        [TestMethod]
        public void GetListAppSetting_ReturnsValidStringList()
        {
            Assert.AreEqual(3, AppSettings.Instance.ListAppSetting.Count);
            Assert.AreEqual("first", AppSettings.Instance.ListAppSetting[0]);
            Assert.AreEqual("second", AppSettings.Instance.ListAppSetting[1]);
            Assert.AreEqual("third", AppSettings.Instance.ListAppSetting[2]);
        }

        [TestMethod]
        public void GetClassWithStringConstructorAppSetting_ReturnsValidClassInstance()
        {
            CustomClassWithStringConstructor instance =
                AppSettings.Instance.CustomClassStringConstructorAppSetting;

            Assert.AreEqual("CustomClassStringConstructorAppSetting", instance.StringValue);
        }

        [TestMethod]
        public void GetClassCustomConverterAppSetting_ReturnsValidClassInstance()
        {
            CustomClassWithExoticConstructor instance =
                AppSettings.Instance.CustomClassExoticConstructorAppSetting;

            Assert.AreEqual("CustomClassExoticConstructorAppSetting", instance.StringValue);
            Assert.AreEqual(1, instance.OtherValue);
        }

        [TestMethod]
        public void GetClassCustomConverterAppSetting_ReturnsValidClassInstanceFromCache_WhenInvokedMoreThanOnce()
        {
            CustomClassWithExoticConstructor instance =
                AppSettings.Instance.CustomClassExoticConstructorAppSetting;

            instance = AppSettings.Instance.CustomClassExoticConstructorAppSetting;

            Assert.AreEqual("CustomClassExoticConstructorAppSetting", instance.StringValue);
            Assert.AreEqual(1, instance.OtherValue);
        }

        [TestMethod, ExpectedException(typeof (AppSettingDoesNotExistException))]
        public void GetNonExistentAppSetting_ThrowsAppSettingDoesNotExistException()
        {
#pragma warning disable 168
            string nonExistentAppSetting = AppSettings.Instance.NonExistentAppSetting;
#pragma warning restore 168
        }

        [TestMethod]
        public void GetAppStringSetting_DecoratedAppSetting_ReturnsValidResult()
        {
            Assert.AreEqual("BadNameForAppSetting", AppSettings.Instance.BetterNameForAppSetting);
        }

        [TestMethod, ExpectedException(typeof(ConvertAppSettingToTypeException))]
        public void GetAppSettingCustomClass_ThrowsException_WhenAppSettingCannotBeConverted_()
        {
#pragma warning disable 168
            try
            {
                CustomClassWithoutConstructor value = AppSettings.Instance.BadAppSetting;
            }
            catch (ConvertAppSettingToTypeException ex)
            {
                const string expectedMessage = "Unable to create an instance of the type " +
                                               "DryPants.Test.Settings.DryAppSettingsTest+CustomClassWithoutConstructor.\r\n" +
                                               "Implement TypeConvertAppSetting to convert to it manually.";
                Assert.AreEqual(expectedMessage, ex.Message);
                throw;
            }
#pragma warning restore 168
        }

        [TestMethod]
        public void GetAppSettingString_ReturnsValidStringResult_WhenAppSettingIsNotMocked()
        {
            var appSettings = new RealAppSettings();
            Assert.AreEqual("TestAppSettingValue", appSettings.TestAppSetting);
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
                get { return GetAppSettingFor(() => BadAppSetting); ; }
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