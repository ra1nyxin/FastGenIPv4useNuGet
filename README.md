# FastGenIPv4useNuGet

[![Build and Dynamic Release](https://github.com/ra1nyxin/FastGenIPv4useNuGet/actions/workflows/release.yml/badge.svg)](https://github.com/ra1nyxin/FastGenIPv4useNuGet/actions/workflows/release.yml)
![.NET Version](https://img.shields.io/badge/.NET-8.0-blue.svg)
![Platform](https://img.shields.io/badge/Platform-Win--x64-orange.svg)
![License](https://img.shields.io/badge/License-MIT-green.svg)

FastGenIPv4useNuGet is a high-performance utility designed to generate massive amounts of public IPv4 addresses. It consumes the custom NuGet package `ra1nyxin.RandomIpGen` and automates the distribution via GitHub Actions.

## Key Features

- **CSPRNG Support**: Utilizes `System.Security.Cryptography.RandomNumberGenerator` for cryptographically strong randomness.
- **Zero-Allocation Logic**: Internal IP formatting leverages `Span<char>` and `stackalloc` to minimize GC pressure.
- **Strict Filtering**: Automatically excludes RFC 1918 private ranges, Loopback, APIPA, CGNAT, and Multicast addresses.
- **CI/CD Integrated**: Fully automated build and release pipeline with timestamped versioning.

## Architecture

The project consists of two main components:
1. **Upstream Package**: `ra1nyxin.RandomIpGen` (v1.0.2) providing the core generation algorithm.
2. **Consumer CLI**: A .NET 8 console application that orchestrates bulk generation and file I/O.

## Usage

### Download
Navigate to the [Releases](https://github.com/ra1nyxin/FastGenIPv4useNuGet/releases) page and download the latest `FastGenIP_yyyyMMdd_HHmm.zip`.

### Local Execution
The executable is self-contained and does not require a pre-installed .NET runtime.
```powershell
./FastGenIP_20260302_0851.exe

```

Result will be saved to `ips.txt` in the current directory.

## Build and Deployment

### Prerequisites

* GitHub Personal Access Token (PAT) with `read:packages` scope.
* Secret `GH_TOKEN` configured in repository settings.

### Manual Build

```powershell
dotnet restore --configfile nuget.config
dotnet publish -c Release -r win-x64 --self-contained true

```

## Dependency Management

This project pulls the core engine from a private/scoped GitHub NuGet registry. Authentication is handled via `nuget.config` utilizing environment variable injection to ensure credential security.

## License

This project is licensed under the MIT License.
