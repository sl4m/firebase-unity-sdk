namespace Firebase.AppCheck {

  /// <summary>
  /// Error codes used by App Check.
  /// </summary>
  public enum AppCheckError {
    /// The operation was a success, no error occurred.
    None = 0,
    /// A network connection error.
    ServerUnreachable = 1,
    /// Invalid configuration error. Currently, an exception is thrown but this
    /// error is reserved for future implementations of invalid configuration
    /// detection.
    InvalidConfiguration = 2,
    /// System keychain access error. Ensure that the app has proper keychain
    /// access.
    SystemKeychain = 3,
    /// Selected AppCheckProvider is not supported on the current platform
    /// or OS version.
    UnsupportedProvider = 4,
    /// An unknown error occurred.
    Unknown = 5,
  }

  /// Struct to hold tokens emitted by the Firebase App Check service which are
  /// minted upon a successful application verification. These tokens are the
  /// federated output of a verification flow, the structure of which is
  /// independent of the mechanism by which the application was verified.
  public struct AppCheckToken {
    /// A Firebase App Check token.
    public string Token;

    /// The time at which the token will expire in milliseconds since epoch.
    public ulong ExpireTimeMillis;
  }

  /// @brief Passed to the FirebaseAppCheck.TokenChanged event.
  ///
  /// The AppCheck Token is passed via these arguments to the
  /// FirebaseAppCheck.TokenChanged event.
  public sealed class TokenChangedEventArgs : System.EventArgs {
    /// A Firebase App Check token.
    public AppCheckToken Token { get; }
  }

  /**
  * Interface for a provider that generates {@link AppCheckToken}s. This provider
  * can be called at any time by any Firebase library that depends (optionally or
  * otherwise) on {@link AppCheckToken}s. This provider is responsible for
  * determining if it can create a new token at the time of the call and
  * returning that new token if it can.
  */
  public interface IAppCheckProvider {
    /**
    * Returns an AppCheckToken or throws an exception with an error code and
    * error message.
    */
    System.Threading.Tasks.Task<AppCheckToken> GetTokenAsync();
  }

  /** Interface for a factory that generates {@link AppCheckProvider}s. */
  public interface IAppCheckProviderFactory {
    /**
    * Gets the {@link AppCheckProvider} associated with the given {@link
    * FirebaseApp} instance, or creates one if none already exists.
    */
    IAppCheckProvider CreateProvider(FirebaseApp app);
  }

  /// @brief Firebase app check object.
  public sealed class FirebaseAppCheck {
    /**
    * Gets the instance of {@code AppCheck} associated with the default {@link
    * FirebaseApp} instance.
    */
    public static FirebaseAppCheck DefaultInstance {
      get;
    }
  
    /**
    * Gets the instance of {@code AppCheck} associated with the given {@link
    * FirebaseApp} instance.
    */
    public static FirebaseAppCheck GetInstance(FirebaseApp app);

    /**
    * Installs the given {@link AppCheckProviderFactory}, overwriting any that
    * were previously associated with this {@code FirebaseAppCheck} instance.
    * Any {@link AppCheckTokenListener}s attached to this 
    * {@code FirebaseAppCheck} instance will be transferred from existing
    * factories to the newly installed one.
    *
    * <p>Automatic token refreshing will only occur if the global {@code
    * isDataCollectionDefaultEnabled} flag is set to true. To allow automatic
    * token refreshing for Firebase App Check without changing the {@code
    * isDataCollectionDefaultEnabled} flag for other Firebase SDKs, call
    * {@link #setTokenAutoRefreshEnabled(bool)} after installing the {@code
    * factory}.
    *
    * This method should be called before initializing the Firebase App.
    */
    public static void SetAppCheckProviderFactory(
        IAppCheckProviderFactory factory);

    /** Sets the {@code isTokenAutoRefreshEnabled} flag. */
    public void SetTokenAutoRefreshEnabled(bool isTokenAutoRefreshEnabled);

    /**
    * Requests a Firebase App Check token. This method should be used ONLY if you
    * need to authorize requests to a non-Firebase backend. Requests to Firebase
    * backends are authorized automatically if configured.
    */
    public System.Threading.Tasks.Task<AppCheckToken>
        GetAppCheckTokenAsync(bool forceRefresh);

    /// Called on the client when an AppCheckToken is created or changed.
    public System.EventHandler<TokenChangedEventArgs> TokenChanged;
  }
}