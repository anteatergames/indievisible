namespace IndieVisible.Infra.CrossCutting.Identity.Model
{
	public class TwoFactorRecoveryCode
	{
		public string Code { get; set; }

		public bool Redeemed { get; set; }
	}
}