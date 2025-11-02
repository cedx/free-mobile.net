namespace Belin.FreeMobile;

using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Headers;

/// <summary>
/// Sends messages by SMS to a <see href="https://mobile.free.fr">FreeMobile</see> account.
/// </summary>
public class Client {

	/// <summary>
	/// The base URL of the remote API endpoint.
	/// </summary>
	public Uri BaseUrl { get; }

	/// <summary>
	/// The Free Mobile user name and password.
	/// </summary>
	private readonly NetworkCredential credential;

	/// <summary>
	/// Creates a new client.
	/// </summary>
	/// <param name="credential">The Free Mobile user name and password.</param>
	/// <param name="baseUrl">The base URL of the remote API endpoint.</param>
	public Client(NetworkCredential credential, [StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl = "https://smsapi.free-mobile.fr") {
		this.BaseUrl = new(baseUrl.EndsWith('/') ? baseUrl : $"{baseUrl}/");
		this.credential = credential;
	}

	/// <summary>
	/// Creates a new client.
	/// </summary>
	/// <param name="userName">The Free Mobile user name.</param>
	/// <param name="password">The Free Mobile password.</param>
	/// <param name="baseUrl">The base URL of the remote API endpoint.</param>
	public Client(string userName, string password, [StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl = "https://smsapi.free-mobile.fr"):
		this(new NetworkCredential(userName, password), baseUrl) {}

	/// <summary>
	/// Sends an SMS message to the underlying account.
	/// </summary>
	/// <param name="text">The message text.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the message has been sent.</returns>
	/// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
	public async Task SendMessage(string text, CancellationToken cancellationToken = default) {
		using var request = await CreateRequest(text, cancellationToken);
		using var httpClient = new HttpClient();
		using var response = await httpClient.SendAsync(request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}

	/// <summary>
	/// Creates the HTTP request corresponding to the specified message.
	/// </summary>
	/// <param name="text">The message text.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The newly created HTTP request message.</returns>
	private async Task<HttpRequestMessage> CreateRequest(string text, CancellationToken cancellationToken = default) {
		var trimmedText = text.Trim();
		using var query = new FormUrlEncodedContent(new Dictionary<string, string> {
			["msg"] = trimmedText.Length > 160 ? trimmedText[0..160] : trimmedText,
			["pass"] = credential.Password,
			["user"] = credential.UserName
		});

		var request = new HttpRequestMessage(HttpMethod.Get, new Uri(BaseUrl, $"sendmsg?{await query.ReadAsStringAsync(cancellationToken)}"));
		request.Headers.UserAgent.Add(new ProductInfoHeaderValue(".NET", Environment.Version.ToString(3)));
		return request;
	}
}
