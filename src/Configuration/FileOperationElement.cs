namespace Johnson.ProfilePhotoHopper.Configuration {

	[System.Serializable]
	public sealed class FileOperationElement : System.Configuration.ConfigurationElement, INamedConfigurationElement {

		#region .ctor
		public FileOperationElement() : base() {
		}
		#endregion .ctor


		#region properties
		[System.Configuration.ConfigurationProperty( "name", IsRequired = true, IsKey = true )]
		public System.String Name {
			get {
				return (System.String)this[ "name" ];
			}
			set {
				this[ "name" ] = value;
			}
		}

		[System.IO.IODescription( "The name of the Type which implements the IFileRecognizer interface." )]
		[System.Configuration.ConfigurationProperty( "typeName", IsRequired = true, IsKey = false )]
		public System.String TypeName {
			get {
				return (System.String)this[ "typeName" ];
			}
			set {
				this[ "typeName" ] = value;
			}
		}

		[System.IO.IODescription( "The assembly which exposes the named Type." )]
		[System.Configuration.ConfigurationProperty( "assembly", IsRequired = true, IsKey = false )]
		public System.String Assembly {
			get {
				return (System.String)this[ "assembly" ];
			}
			set {
				this[ "assembly" ] = value;
			}
		}
		#endregion properties

	}

}