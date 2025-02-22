namespace Belin.FreeMobile;

using System.Net.Http.Headers;

/// <summary>
/// Sends messages by SMS to a <see href="https://mobile.free.fr">FreeMobile</see> account.
/// </summary>
/// <param name="account">The Free Mobile account.</param>
/// <param name="apiKey">The Free Mobile API key.</param>
/// <param name="baseUrl">The base URL of the remote API endpoint.</param>
public class Client(string account, string apiKey, string baseUrl = "https://smsapi.free-mobile.fr") {

	/// <summary>
	/// The Free Mobile account.
	/// </summary>
	public string Account { get; private set; } = account;

	/// <summary>
	/// The Free Mobile API key.
	/// </summary>
	public string ApiKey { get; private set; } = apiKey;

	/// <summary>
	/// The base URL of the remote API endpoint.
	/// </summary>
	public Uri BaseUrl { get; private set; } = new Uri(baseUrl.EndsWith('/') ? baseUrl : $"{baseUrl}/");

	/// <summary>
	/// Sends an SMS message to the underlying account.
	/// </summary>
	/// <param name="text">The message text.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
	public void SendMessage(string text, CancellationToken cancellationToken = default) {
		using var httpClient = new HttpClient();
		using var request = CreateRequest(text);
		using var response = httpClient.Send(request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}

	/// <summary>
	/// Sends an SMS message to the underlying account.
	/// </summary>
	/// <param name="text">The message text.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the message has been sent.</returns>
	/// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
	public async Task SendMessageAsync(string text, CancellationToken cancellationToken = default) {
		using var httpClient = new HttpClient();
		using var request = CreateRequest(text);
		using var response = await httpClient.SendAsync(request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}

	/// <summary>
	/// Creates the HTTP request corresponding to the specified message.
	/// </summary>
	/// <param name="text">The message text.</param>
	/// <returns>The newly created HTTP request message.</returns>
	private HttpRequestMessage CreateRequest(string text) {
		var trimmedText = text.Trim();
		var query = new Dictionary<string, string>() {
			{ "msg", trimmedText.Length > 160 ? trimmedText[0..160] : trimmedText },
			{ "pass", ApiKey },
			{ "user", Account }
		};

		var queryString = string.Join('&', query.Select(item => $"{item.Key}={Uri.EscapeDataString(item.Value)}"));
		var request = new HttpRequestMessage(HttpMethod.Get, new Uri(BaseUrl, $"sendmsg?{queryString}"));
		request.Headers.UserAgent.Add(new ProductInfoHeaderValue($".NET/{Environment.Version}"));
		return request;
	}
}
