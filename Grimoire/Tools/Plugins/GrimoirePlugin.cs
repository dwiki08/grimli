using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Grimoire.Tools.Plugins
{
	public class GrimoirePlugin
	{
		public string Name { get; }

		public string Author
		{
			get
			{
				IGrimoirePlugin plugin = this._plugin;
				return ((plugin != null) ? plugin.Author : null) ?? string.Empty;
			}
		}

		public string Description
		{
			get
			{
				IGrimoirePlugin plugin = this._plugin;
				return ((plugin != null) ? plugin.Description : null) ?? string.Empty;
			}
		}

		public string LastError { get; private set; }

		public GrimoirePlugin(string dllFilePath)
		{
			this._pluginPath = dllFilePath;
			this.Name = Path.GetFileName(dllFilePath);
		}

		private Type[] TryGetTypes(Assembly asm)
		{
			Type[] result;
			try
			{
				result = asm.GetTypes();
			}
			catch (ReflectionTypeLoadException ex)
			{
				result = (from t in ex.Types
				where t != null
				select t).ToArray<Type>();
			}
			return result;
		}

		public bool Load()
		{
			bool result;
			try
			{
				if (!File.Exists(this._pluginPath))
				{
					this.LastError = "Could not find file: " + this._pluginPath;
					result = false;
				}
				else
				{
					Assembly asm = Assembly.LoadFile(this._pluginPath);
					Type[] source;
					Type type;
					if ((source = this.TryGetTypes(asm)) == null)
					{
						this.LastError = "Unable to retrieve any types in the assembly.";
						result = false;
					}
					else if ((type = source.FirstOrDefault((Type t) => t.IsDefined(typeof(GrimoirePluginEntry), true))) == null)
					{
						this.LastError = "Could not find a class marked with the GrimoirePluginEntry attribute.";
						result = false;
					}
					else
					{
						this._plugin = (IGrimoirePlugin)Activator.CreateInstance(type);
						this._plugin.Load();
						GrimoirePlugin.LoadedPlugins.Add(this);
						result = true;
					}
				}
			}
			catch (Exception ex)
			{
				this.LastError = "Failure! This is either not a Grimoire plugin, or its code does not conform to the Grimoire standard.\n" + ex.Message + "\n" + ex.StackTrace;
				result = false;
			}
			return result;
		}

		public bool Unload()
		{
			bool result;
			try
			{
				this._plugin.Unload();
				GrimoirePlugin.LoadedPlugins.Remove(this);
				result = true;
			}
			catch (Exception ex)
			{
				this.LastError = "Failed to unload plugin!\n" + ex.Message + "\n" + ex.StackTrace;
				result = false;
			}
			return result;
		}

		public static List<GrimoirePlugin> LoadedPlugins = new List<GrimoirePlugin>();

		private readonly string _pluginPath;

		private IGrimoirePlugin _plugin;
	}
}
