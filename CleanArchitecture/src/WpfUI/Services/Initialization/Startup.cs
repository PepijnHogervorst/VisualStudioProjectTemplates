using Domain.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace WpfUI.Services.Initialization;

internal class Startup
{
    #region Private fields
    private readonly IEnumerable<IStartupInitializer> _startupInitializers;
    private readonly ILogger<Startup> _logger;
    #endregion


    #region Constructor
    public Startup(IEnumerable<IStartupInitializer> startupInitializers, ILogger<Startup> logger)
    {
        _startupInitializers = startupInitializers;
        _logger = logger;
    }
    #endregion


    #region Public methods
    public async Task InitializeAsync()
    {
        foreach (var initializer in _startupInitializers.OrderBy(i => i.Order))
        {
            try
            {
                await initializer.Initialize();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Initializer {Type} exception: {Message}", initializer.GetType(), ex.Message);
            }
        }
    }
    #endregion
}
