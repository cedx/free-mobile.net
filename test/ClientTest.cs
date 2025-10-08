namespace Belin.FreeMobile;

/// <summary>
/// Tests the features of the <see cref="Client"/> class.
/// </summary>
[TestClass]
public sealed class ClientTest {

	[TestMethod]
	public async Task NetworkError() {
		// It should throw a `HttpRequestException` if a network error occurred.
		var client = new Client("anonymous", "secret", "http://localhost:10000");
		await ThrowsAsync<HttpRequestException>(() => client.SendMessage("Hello World!"));
	}

	[TestMethod]
	public async Task InvalidCredentials() {
		// It should throw a `HttpRequestException` if the credentials are invalid.
		var client = new Client("anonymous", "secret");
		await ThrowsAsync<HttpRequestException>(() => client.SendMessage("Hello World!"));
	}

	[TestMethod]
	public async Task ValidCredentials() {
		// It should send SMS messages if the credentials are valid.
		var client = new Client(Environment.GetEnvironmentVariable("FREEMOBILE_ACCOUNT")!, Environment.GetEnvironmentVariable("FREEMOBILE_API_KEY")!);
		await client.SendMessage("Hello Cédric, from .NET!");
	}
}
