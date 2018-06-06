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
	
		[System.Configuration.ConfigurationProperty( "path", IsRequired = true, IsKey = false )]
		public System.String Path {
			get {
				return (System.String)this[ "path" ];
			}
			set {
				this[ "path" ] = value;
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