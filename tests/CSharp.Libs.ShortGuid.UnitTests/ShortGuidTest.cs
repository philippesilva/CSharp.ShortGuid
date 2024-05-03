namespace Philippe.ShortGuid.UnitTests
{
	public class ShortGuidTest
	{
		private readonly Guid Guid = new("dad730fb-7a79-4eb2-ad33-8219344e9d3e");
		private readonly string Value = "+zDX2nl6sk6tM4IZNE6dPg==";

		[Fact]
		public void Instance_NewShortGuidWithGuid_ReturnSuccess()
		{
			var text = new ShortGuid(Guid);

			Assert.Equal(Value, text.Value);
			Assert.Equal(Guid, text.Guid);
		}

		[Fact]
		public void Instance_NewShortGuidWithShort_ReturnSuccess()
		{
			var text = new ShortGuid(Value);

			Assert.Equal(Value, text.Value);
			Assert.Equal(Guid, text.Guid);
		}

		[Fact]
		public void Equals_NewShortGuid_ReturnSuccess()
		{
			var shortguid = ShortGuid.NewShortGuid();
			var shortguid_1 = shortguid;
			var shortguid_2 = shortguid;

			Assert.True(shortguid_1.Equals(shortguid_2));
			Assert.Equal(shortguid_1.Value, shortguid_2.Value);
			Assert.Equal(shortguid_1.Guid, shortguid_2.Guid);
		}

		[Fact]
		public void NoEquals_NewShortGuid_ReturnSuccess()
		{
			var shortguid_1 = ShortGuid.NewShortGuid();
			var shortguid_2 = ShortGuid.NewShortGuid();

			Assert.False(shortguid_1.Equals(shortguid_2));
			Assert.NotEqual(shortguid_1.Value, shortguid_2.Value);
			Assert.NotEqual(shortguid_1.Guid, shortguid_2.Guid);
		}

		[Fact]
		public void Instance_NewEmptyShortGuid_ReturnSuccess()
		{
			var shortGuid = ShortGuid.Empty;

			Assert.Equal("AAAAAAAAAAAAAAAAAAAAAA==", shortGuid.Value);
			Assert.Equal(Guid.Empty, shortGuid.Guid);
		}

		[Fact]
		public void ImplicitOperator_WithString_ReturnSuccess()
		{
			ShortGuid shortGuid = Value;

			Assert.Equal(Value, shortGuid.Value);
		}

		[Fact]
		public void ImplicitOperator_WithGuid_ReturnSuccess()
		{
			ShortGuid shortGuid = Value;

			Assert.Equal(Guid, shortGuid.Guid);
		}
	}
}