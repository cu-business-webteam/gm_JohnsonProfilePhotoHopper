using System.Linq;

namespace Johnson.ProfilePhotoHopper {

	public static class Program {

		#region fields
		private static readonly System.Collections.Specialized.NameValueCollection theAppSettings;
		private static readonly System.Type theDbNetIdType;
		#endregion fields


		#region .ctor
		static Program() {
			theAppSettings = System.Configuration.ConfigurationManager.AppSettings;
			theDbNetIdType = typeof( DbNetId );
		}
		#endregion .ctor


		public static System.Int32 Main( System.String[] args ) {
			var section = Configuration.FileOperationSection.GetSection();
			var fileOperations = section.FileOperations.OfType<Configuration.FileOperationElement>();
			System.Collections.Generic.ICollection<Johnson.ProfilePhotoRecognizer.IFileRecognizer> recognizers = new System.Collections.Generic.List<Johnson.ProfilePhotoRecognizer.IFileRecognizer>();
			System.Reflection.Assembly asm = null;
			foreach ( var fo in fileOperations ) {
				asm = System.Reflection.Assembly.LoadFrom( fo.Assembly );
				recognizers.Add( (Johnson.ProfilePhotoRecognizer.IFileRecognizer)System.Activator.CreateInstance( asm.GetType( fo.TypeName ) ) );
			}

			var pickupDir = args[ 0 ];
			System.String dest = null;
			foreach ( var filePathName in System.IO.Directory.GetFiles( pickupDir ) ) {
				foreach ( var rec in recognizers ) {
					dest = rec.IsRecognized( filePathName );
					if ( !System.String.IsNullOrEmpty( dest ) ) {
						System.IO.File.Copy( filePathName, dest, true );
						System.IO.File.Delete( filePathName );
						break;
					}
				}
				if ( System.String.IsNullOrEmpty( dest ) ) {
					dest = section.Path;
					System.IO.File.Copy( filePathName, dest, true );
					System.IO.File.Delete( filePathName );
				}
			}

			return 0;
		}

	}

}