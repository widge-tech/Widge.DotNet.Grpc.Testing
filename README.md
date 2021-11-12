# Widge.DotNet.Grpc.Testing

## 安装依赖

```bash
dotnet restore
```

## 启动运行

```bash
dotnet run
```

## 打包发布

```bash
# dotnet publish -c Release -o <out_dir>
dotnet publish --configuration Release
```

## 构建镜像

```bash
docker build --pull --rm -f "Dockerfile" -t <name=grpc.testing>:<version=latest> <workspace=".">
# example: docker build --pull --rm -f "Dockerfile" -t grpc.testing:latest "."
```
