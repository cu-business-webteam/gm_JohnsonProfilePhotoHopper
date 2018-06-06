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
			var pickupDir = args[ 0 ];
			var fileOpSection = Configuration.FileOperationSection.GetSection();
			foreach ( var destination in fileOpSection.FileOperations.OfType<Configuration.FileOperationElement>() ) {
				ProcessFiles( pickupDir, destination );
			}
			var defDrop = fileOpSection.Path;
			foreach ( var file in System.IO.Directory.EnumerateFiles( pickupDir ) ) {
				System.IO.File.Move( file, System.IO.Path.Combine( defDrop, System.IO.Path.GetFileName( file ) ) );
			}

			return 0;
		}

		private static void ProcessFiles( System.String source, Configuration.FileOperationElement process ) {
			var netIdExpression = theAppSettings[ "netIdExpression" ];
			var regexName = theAppSettings[ "netIdExpressionName" ];

			var methodInfo = theDbNetIdType.GetMethod( process.MethodName, new System.Type[ 0 ] );
			var fileList = System.IO.Directory.EnumerateFiles( source ).Select(
				x => new {
					PathName = x,
					Name = System.IO.Path.GetFileName( x ),
					NameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension( x )
				}
			).Where(
				x => System.Text.RegularExpressions.Regex.IsMatch(
					x.NameWithoutExtension, netIdExpression,
					System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline
				)
			).Select(
				x => new {
					PathName = x.PathName,
					Name = x.Name,
					NameWithoutExtension = x.NameWithoutExtension,
					NetId = System.Text.RegularExpressions.Regex.Match(
						x.NameWithoutExtension, netIdExpression,
						System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline
					).Groups[ regexName ].Captures[ 0 ].Value
				}
			).Join(
				(System.Collections.Generic.IEnumerable<System.String>)methodInfo.Invoke( null, null ),
				outer => outer.NetId,
				inner => inner,
				( x, y ) => x
			);
			System.String path = process.Path;
			System.IO.Directory.CreateDirectory( path );
			System.String destinationName = null;
			foreach ( var file in fileList ) {
				destinationName = System.IO.Path.Combine( path, file.Name );
				System.IO.File.Delete( destinationName );
				System.IO.File.Move( file.PathName, destinationName );
			};
		}

	}

}