using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Grimoire.Tools.Plugins
{
	// Token: 0x02000016 RID: 22
	public class GrimoirePlugin
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00010801 File Offset: 0x0000EA01
		public string Name { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00010809 File Offset: 0x0000EA09
		public string Author
		{
			get
			{
				IGrimoirePlugin plugin = this._plugin;
				return ((plugin != null) ? plugin.Author : null) ?? string.Empty;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00010826 File Offset: 0x0000EA26
		public string Description
		{
			get
			{
				IGrimoirePlugin plugin = this._plugin;
				return ((plugin != null) ? plugin.Description : null) ?? string.Empty;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00010843 File Offset: 0x0000EA43
		// (set) Token: 0x06000127 RID: 295 RVA: 0x0001084B File Offset: 0x0000EA4B
		public string LastError { get; private set; }

		// Token: 0x06000128 RID: 296 RVA: 0x00010854 File Offset: 0x0000EA54
		public GrimoirePlugin(string dllFilePath)
		{
			this._pluginPath = dllFilePath;
			this.Name = Path.GetFileName(dllFilePath);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00010870 File Offset: 0x0000EA70
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

		// Token: 0x0600012A RID: 298 RVA: 0x000108C8 File Offset: 0x0000EAC8
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

		// Token: 0x0600012B RID: 299 RVA: 0x000109CC File Offset: 0x0000EBCC
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

		// Token: 0x04000120 RID: 288
		public static List<GrimoirePlugin> LoadedPlugins = new List<GrimoirePlugin>();

		// Token: 0x04000121 RID: 289
		private readonly string _pluginPath;

		// Token: 0x04000122 RID: 290
		private IGrimoirePlugin _plugin;
	}
}
