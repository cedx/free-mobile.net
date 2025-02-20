namespace Belin.FreeMobile;

/// <summary>
/// Tests the features of the <see cref="Client"/> class.
/// </summary>
[TestClass]
public sealed class ClientTest {

	[TestMethod("It should throw a `HttpRequestException` if a network error occurred")]
	public void NetworkError() {
		var client = new Client("anonymous", "secret", "http://localhost:10000");
		Throws<HttpRequestException>(() => client.SendMessage("Hello World! [sync]"));
	}

	[TestMethod("It should throw a `HttpRequestException` if a network error occurred")]
	public void NetworkErrorAsync() {
		var client = new Client("anonymous", "secret", "http://localhost:10000");
		ThrowsAsync<HttpRequestException>(() => client.SendMessageAsync("Hello World! [async]"));
	}

	[TestMethod("It should throw a `HttpRequestException` if the credentials are invalid")]
	public void InvalidCredentials() {
		var client = new Client("anonymous", "secret");
		Throws<HttpRequestException>(() => client.SendMessage("Hello World! [sync]"));
	}

	[TestMethod("It should throw a `HttpRequestException` if the credentials are invalid")]
	public void InvalidCredentialsAsync() {
		var client = new Client("anonymous", "secret");
		ThrowsAsync<HttpRequestException>(() => client.SendMessageAsync("Hello World! [async]"));
	}

	[TestMethod("It should send SMS messages if the credentials are valid")]
	public void ValidCredentials() {
		var client = new Client(Environment.GetEnvironmentVariable("FREEMOBILE_ACCOUNT")!, Environment.GetEnvironmentVariable("FREEMOBILE_API_KEY")!);
		client.SendMessage("Hello Cédric, from .NET! [sync]");
		IsTrue(true);
	}

	[TestMethod("It should send SMS messages if the credentials are valid")]
	public async Task ValidCredentialsAsync() {
		var client = new Client(Environment.GetEnvironmentVariable("FREEMOBILE_ACCOUNT")!, Environment.GetEnvironmentVariable("FREEMOBILE_API_KEY")!);
		await client.SendMessageAsync("Hello Cédric, from .NET! [async]");
		IsTrue(true);
	}
}
