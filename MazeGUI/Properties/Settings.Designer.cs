﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Configuration;

namespace MazeGUI.Properties
{


    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {

        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }
        public string ServerIP {
            get
            {
                return ConfigurationSettings.AppSettings["server"];
            }
            internal set
            {
                ConfigurationSettings.AppSettings["server"] = value;
            }
        }
        public int ServerPort
        {
            get
            {
                
                return int.Parse(ConfigurationSettings.AppSettings["port"]);
            }
            internal set
            {
                ConfigurationSettings.AppSettings["port"] = value.ToString();
            }
        }
        public int MazeRows
        {
            get
            {
                return int.Parse(ConfigurationSettings.AppSettings["MazeRows"]);
            }
            internal set
            {
                ConfigurationSettings.AppSettings["MazeRows"] = value.ToString();
            }
        }
        public int MazeCols
        {
            get
            {
                return int.Parse(ConfigurationSettings.AppSettings["MazeCols"]);
            }
            internal set
            {
                ConfigurationSettings.AppSettings["MazeCols"] = value.ToString();
            }
        }
        public int SearchAlgorithm
        {
            get
            {
                if( int.Parse(ConfigurationSettings.AppSettings["SearchAlgorithm"]) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            internal set
            {
                ConfigurationSettings.AppSettings["SearchAlgorithm"] = value.ToString();
            }
        }
    }
}
