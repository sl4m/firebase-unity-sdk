namespace Firebase.AppCheck {

  /**
  * Implementation of an {@link IAppCheckProviderFactory} that builds {@link
  * DeviceCheckProviderFactory}s.
  */
  public sealed class DeviceCheckProviderFactory : IAppCheckProviderFactory {
    /**
    * Gets an instance of this class for installation into a {@link
    * com.google.firebase.appcheck.AppCheck} instance.
    */
    public static DeviceCheckProviderFactory GetInstance();

    /**
    * Gets the {@link IAppCheckProvider} associated with the given {@link
    * FirebaseApp} instance, or creates one if none already exists.
    */
    IAppCheckProvider CreateProvider(FirebaseApp app);
  }
}