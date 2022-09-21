namespace Firebase.AppCheck {

  /**
  * Implementation of an {@link IAppCheckProviderFactory} that builds {@link
  * SafetyNetAppCheckProviderFactory}s.
  */
  public sealed class SafetyNetAppCheckProviderFactory : IAppCheckProviderFactory {
    /**
    * Gets an instance of this class for installation into a {@link
    * com.google.firebase.appcheck.AppCheck} instance.
    */
    public static SafetyNetAppCheckProviderFactory GetInstance();

    /**
    * Gets the {@link IAppCheckProvider} associated with the given {@link
    * FirebaseApp} instance, or creates one if none already exists.
    */
    IAppCheckProvider CreateProvider(FirebaseApp app);
  }
}