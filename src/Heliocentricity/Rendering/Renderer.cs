using System;
using System.IO;
using System.Text;
using Heliocentricity.Common.Logging;
using Spark;
using Spark.FileSystem;

namespace Heliocentricity.Rendering
{
    public interface IRenderer
    {
        void Render(dynamic model, RunnerOptions runnerOptions);
    }
    public class Renderer : IRenderer
    {
        private readonly ILogger _logger;

        public Renderer(ILogger logger)
        {
            _logger = logger;
        }

        public void Render(dynamic model, RunnerOptions runnerOptions)
        {
            _logger.Debug(string.Format("Rendering {0}", model.FileName));

            var viewEngine = new SparkViewEngine
                                 {
                                     DefaultPageBaseType = typeof (SparkView).FullName,
                                     ViewFolder = new FileSystemViewFolder(Path.Combine(runnerOptions.WorkingDirectory, "_templates"))
                                 };

            var view = (SparkView) viewEngine.CreateInstance(new SparkViewDescriptor().AddTemplate("post.spark"));
            view.Model = model;

            using(var writer = new StreamWriter(Console.OpenStandardOutput(), Encoding.UTF8))
            {
                view.RenderView(writer);
            }
        }
    }
}