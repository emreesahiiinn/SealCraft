using System.Text;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace SealCraft.Presentation.SecretManager;

public static class AwsSecretsManagerHelper
{
    public static async Task<IConfiguration> LoadSecretsAsync(string secretName, string region)
    {
        var configurationBuilder = new ConfigurationBuilder();

        try
        {
            var accessKeyId = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
            var secretAccessKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY");

            if (string.IsNullOrEmpty(accessKeyId) || string.IsNullOrEmpty(secretAccessKey))
                throw new Exception("AWS Access Key ID or Secret Access Key is not set in environment variables.");

            var client =
                new AmazonSecretsManagerClient(accessKeyId, secretAccessKey, RegionEndpoint.GetBySystemName(region));

            var request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT"
            };

            var response = await client.GetSecretValueAsync(request);

            if (!string.IsNullOrEmpty(response.SecretString))
            {
                var secretJson = response.SecretString;

                configurationBuilder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(secretJson)));
            }
            else
            {
                throw new Exception("Data from Secrets Manager is empty!");
            }
        }
        catch (AmazonSecretsManagerException ex)
        {
            Console.WriteLine($"AWS Secrets Manager error: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error: {ex.Message}");
            throw;
        }

        return configurationBuilder.Build();
    }
}