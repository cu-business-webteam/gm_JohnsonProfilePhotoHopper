namespace Johnson.ProfilePhotoHopper.Configuration {

	[System.Serializable]
	public sealed class FileOperationElement : System.Configuration.ConfigurationElement {

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

		[System.Configuration.ConfigurationProperty( "methodName", IsRequired = true, IsKey = false )]
		public System.String MethodName {
			get {
				return (System.String)this[ "methodName" ];
			}
			set {
				this[ "methodName" ] = value;
			}
		}

		[System.IO.IODescription( "The destination directory" )]
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

	}

}