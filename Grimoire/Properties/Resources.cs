using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Grimoire.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		internal Resources()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Grimoire.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static byte[] aqlitegrimoire
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("aqlitegrimoire", Resources.resourceCulture);
			}
		}

		internal static string defaulttext
		{
			get
			{
				return Resources.ResourceManager.GetString("defaulttext", Resources.resourceCulture);
			}
		}

		internal static string statementcmds
		{
			get
			{
				return Resources.ResourceManager.GetString("statementcmds", Resources.resourceCulture);
			}
		}

		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;
	}
}
