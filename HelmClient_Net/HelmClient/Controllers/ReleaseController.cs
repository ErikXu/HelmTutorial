using System.IO;
using System.Threading.Tasks;
using Helm.Charts;
using Helm.Helm;
using k8s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelmClient.Controllers
{
    [Route("api/releases")]
    public class ReleaseController : Controller
    {
        [HttpPost("{name}")]
        public async Task<IActionResult> Install(string name, IFormFile file)
        {
            var client = await GetClient();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;
                var chart = ChartPackage.Open(stream);
                var release = await client.InstallRelease(chart.Serialize(), string.Empty, name, true);
                return Ok(release.Manifest);
            }
        }

        [HttpDelete("{name}/{purge}")]
        public async Task<IActionResult> Uninstall(string name, bool purge)
        {
            var client = await GetClient();
            var result = await client.UninstallRelease(name, purge);
            return Ok(result.Info);
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> Update(string name, IFormFile file)
        {
            var client = await GetClient();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var chart = ChartPackage.Open(stream);
                var release = await client.UpdateRelease(chart.Serialize(), string.Empty, name);
                return Ok(release.Manifest);
            }
        }

        [HttpPut("{name}/{version}")]
        public async Task<IActionResult> Rollback(string name, int version)
        {
            var client = await GetClient();
            var result = await client.RollbackRelease(name, version);
            return Ok(result.Info);
        }

        private static async Task<TillerClient> GetClient()
        {
            var kubeconfig = System.IO.File.ReadAllText("admin.conf");
            var config = KubernetesClientConfiguration.BuildConfigFromConfigFile(kubeconfig: kubeconfig);
            var kubernetes = new Kubernetes(config);

            var locator = new TillerLocator(kubernetes);
            var endPoint = await locator.Locate();
            var client = new TillerClient(endPoint.ToString());
            return client;
        }
    }
}
