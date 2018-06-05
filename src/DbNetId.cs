using System.Linq;

namespace Johnson.ProfilePhotoHopper {

	[System.Serializable]
	public sealed class DbNetId : Oits.Configuration.DbMap.ReturnValueBase {

		public DbNetId() : base() {
		}
		public DbNetId( System.String netId ) : this() {
			this.NetId = netId;
		}

		public System.String NetId {
			get;
			set;
		}

		public static implicit operator System.String( DbNetId obj ) {
			return ( null == obj )
				? null
				: obj.NetId
			;
		}
		public static explicit operator DbNetId( System.String obj ) {
			var q = obj.TrimToNull();
			return System.String.IsNullOrEmpty( q )
				? null
				: new DbNetId( q )
			;
		}

		public static System.Collections.Generic.IEnumerable<System.String> GetFaculty() {
			var group = Oits.Configuration.DbMap.DbMapSection.GetSection().Groups[ "JgsmDataSecure" ];
			using ( var cnxn = group.CreateConnection() ) {
				var cmd = group.Commands[ "GetJsFaculty" ];
				return cmd.ExecuteReaderSingleResult<DbNetId>( cnxn, null, new DbNetId(), group.Results[ "GetJsFaculty" ] ).Select(
					x => x.NetId
				);
			}
		}

	}

}