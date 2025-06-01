echo "🔄 Pulling latest code from GitHub..."
git pull

echo "🛑 Stopping and removing old container..."
docker stop khaithocode_webapi_container || true
docker rm khaithocode_webapi_container || true

echo "🐳 Building Docker image..."
docker build -t khaithocode_deploy_webapi .

echo "🚀 Starting new container..."
docker run -d -p 5123:80 --name khaithocode_webapi_container  khaithocode_deploy_webapi

echo "✅ Deployed successfully!"