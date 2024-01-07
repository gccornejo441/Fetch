namespace Fetch.Mobile.Services.Settings;

public class SettingsServices : ISettingsService
{
    #region Setting Constants
    private const string AccessToken = "access_token";
    #endregion

    #region Setting Properties
        
    #endregion
    public string AuthAccessToken
    {
        get => Preferences.Get(AccessToken, AuthAccessToken);
        set => Preferences.Set(AccessToken, value);
    }

    public string AuthIdToken
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public bool UseMocks
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public string IdentityEndpointBase
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public string GatewayShoppingEndpointBase
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public string GatewayMarketingEndpointBase
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public bool UseFakeLocation
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public string Latitude
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public string Longitude
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public bool AllowGpsLocation
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }
}
