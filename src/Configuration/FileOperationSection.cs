using System.Linq;

namespace Johnson.ProfilePhotoHopper.Configuration {

	[System.Serializable]
	public sealed class FileOperationSection : System.Configuration.ConfigurationSection {

		#region fields
		public const System.String DefaultSectionName = "johnson.fileOperations";
		#endregion fields


		#region .ctor
		public FileOperationSection() : base() {
		}
		#endregion .ctor


		#region properties
		[System.Configuration.ConfigurationProperty( "fileOperations", IsDefaultCollection = false, IsRequired = false )]
		[System.Configuration.ConfigurationCollection( typeof( FileOperationElementCollection ),
			AddItemName = "add",
			ClearItemsName = "clear",
			RemoveItemName = "remove"
		)]
		public FileOperationElementCollection FileOperations {
			get {
				return (FileOperationElementCollection)base[ "fileOperations" ];
			}
		}

		/// <summary>The default send-to destination.</summary>
		[System.IO.IODescription( "The default send-to destination." )]
		[System.Configuration.ConfigurationProperty( "defaultPath", IsRequired = true, IsKey = false )]
		public System.String DefaultPath {
			get {
				return (System.String)this[ "defaultPath" ];
			}
			set {
				this[ "defaultPath" ] = value;
			}
		}
		#endregion properties


		#region static methods
		public static FileOperationSection GetSection() {
			return ( System.Configuration.ConfigurationManager.GetSection( FileOperationSection.DefaultSectionName ) as FileOperationSection );
		}
		#endregion static methods

	}

}