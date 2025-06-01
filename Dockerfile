# -------------------
# Build stage
# -------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy toàn bộ mã nguồn và build
COPY . ./
RUN dotnet publish -c Release -o /out

# -------------------
# Runtime stage
# -------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy kết quả publish từ stage build
COPY --from=build /out ./

# Expose default HTTP port (trong container là 80)
EXPOSE 80

# Dùng đúng tên file DLL của bạn
ENTRYPOINT ["dotnet", "khaithocode_deploy_webapi.dll"]