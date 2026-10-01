using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Extensions
{
	public static class IdentityExtentions
	{
		public static int GetUserID(this ClaimsPrincipal claimsPrincipal)
		{
			if (claimsPrincipal == null)
			{
				return default;
			}

			if (claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier) == null)
			{
				return default;
			}

			string? userID = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(userID))
			{
				return default;
			}
			else
			{
				return int.Parse(userID);
			}
		}

		public static int GetUserID(this IPrincipal principal) 
		{
			if (principal == null) 
			{
				return default;
			}

			var user = (ClaimsPrincipal)principal;

			return user.GetUserID();
		}
	}
}
