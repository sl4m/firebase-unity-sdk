#include "firebase/app.h"
#include "firebase/app_check/firebase_app_check.h"

// Create a custom AppCheck provider.

public class YourCustomAppCheckProvider : AppCheckProvider {
  public Task<AppCheckToken> GetTokenAsync() {
    return Task<AppCheckToken>.Run( () => {
      // Logic to exchange proof of authenticity for an App Check token and
      //   expiration time.
      // ...

      // Refresh the token early to handle clock skew.
      ulong expMillis = expirationFromServer * 1000 - 60000;

      // Create an AppCheckToken struct.
      AppCheckToken appCheckToken = new AppCheckToken(tokenFromServer, expMillis);
      // Return a token or throw an exception.
      return appCheckToken;
    } );
  }
}

// Create a factory for a custom provider.

class YourCustomAppCheckProviderFactory : IAppCheckProviderFactory {
  public static YourCustomAppCheckProviderFactory GetInstance() {
    return new YourCustomAppCheckProviderFactory();
  }

  IAppCheckProvider CreateProvider(FirebaseApp app) {
    return new YourCustomAppCheckProvider(app);
  }
}

// Initialize App Check (with a given provider factory)

// Note: SetAppCheckProviderFactory must be called before App::Create()
// to be compatible with iOS

FirebaseAppCheck.SetAppCheckProviderFactory(
    YourCustomAppCheckProviderFactory.GetInstance());
FirebaseApp app = FirebaseApp.Create();
FirebaseAppCheck appCheck = FirebaseAppCheck.GetInstance();

// Add a listener for token changes.

static void MyAppCheckListener(object sender, TokenChangedEventArgs args)
{
    // Use the token to authorize requests to non-firebase backends.
    // ...
    AppCheckToken token = args.Token;
}

appCheck.TokenChanged += MyAppCheckListener;
