using System.Collections.Generic;
using Heliocentricity.Common.Logging;
using Heliocentricity.Rendering;

namespace Heliocentricity.Correlation
{
    public interface ICorrelator
    {
        void Correlate(dynamic modelCollection, RunnerOptions runnerOptions);
    }

    /// <summary>
    /// TODO: Come up with another name for this, it's 3AM, but this name doesn't make sense, IMO
    /// This is responsible for figuring out what to do with the models. Figure out which views need
    /// to be rendered, some models might need a few rendered for each one, etc.
    /// </summary>
    public class Correlator : ICorrelator
    {
        private readonly ILogger _logger;
        private readonly IRenderer _renderer;

        public Correlator(ILogger logger, IRenderer renderer)
        {
            _logger = logger;
            _renderer = renderer;
        }

        public void Correlate(dynamic modelCollection, RunnerOptions runnerOptions)
        {
            var dictionary = modelCollection as IDictionary<string, object>;

            foreach(var model in dictionary)
            {
                foreach(var file in model.Value as dynamic)
                {
                    _renderer.Render(file, runnerOptions);
                }
            }
        }
    }
}