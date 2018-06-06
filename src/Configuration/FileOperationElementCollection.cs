namespace Johnson.ProfilePhotoHopper.Configuration {

	[System.Serializable]
	public class FileOperationElementCollection : NamedConfigurationElementCollectionBase<FileOperationElement> {

		#region .ctor
		public FileOperationElementCollection() : base() {
		}
		public FileOperationElementCollection( System.Collections.IComparer comparer ) : base( comparer ) {
		}
		#endregion .ctor


		#region methods
		protected override System.Object GetElementKey( System.Configuration.ConfigurationElement element ) {
			if ( null == element ) {
				throw new System.ArgumentNullException( "element" );
			}
			var probe = ( element as FileOperationElement );
			if ( null == probe ) {
				throw new System.ArgumentException();
			}
			return probe.Name;
		}
		#endregion methods

	}

}