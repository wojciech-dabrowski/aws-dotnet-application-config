param(
    [Parameter(Mandatory = $True)]
    [string]$deployBucketName
)

dotnet publish -c Release
dotnet lambda deploy-serverless `
    --configuration Release `
    --region eu-west-1 `
    --stack-name aws-application-config `
    --s3-bucket $deployBucketName `
    --s3-prefix AwsApplicationConfig.Lambda/ `
    --template serverless.yaml