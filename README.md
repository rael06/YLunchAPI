# YLunchApi

ASP.NET Core (.NET 6) API of YLunch: restaurants, products, orders, JWT authentication. MySQL through Entity Framework Core (Pomelo). Front end: `rael06/YLunchUI`.

## Development

```bash
dotnet build YLunchApi.sln
dotnet test tests/YLunchApi.UnitTests
```

The API reads its settings from the environment or a `.env` file (`DotNetEnv`): `Host`, `Port`, `JwtSecret`, `DbHost`, `DbPort`, `DbName`, `DbUser`, `DbPassword`.

## Deployment

The API runs on the VPS at `https://ylunch-api.rael-calitro.ovh`, deployed with [Kamal 2](https://kamal-deploy.org) (`config/deploy.yml`) following the conventions of the platform repository `rael06/vps`. GitHub Actions (`.github/workflows/ci-cd.yml`) builds and runs the unit tests on every push and pull request, and on `master` builds the image on the runner, sends it to the VPS through the SSH tunnel and switches `kamal-proxy` once `/Trials/anonymous` answers: no downtime.

- **Image** (`Dockerfile`): published with the .NET 6 SDK, runs on `mcr.microsoft.com/dotnet/aspnet:6.0-jammy-chiseled` (no shell) as the non-root user 1654, read-only.
- **Database**: the Kamal accessory `ylunch-db` (`mysql:9.2.0`) on the Docker volume `ylunch-db-data`. `kamal deploy` does not touch it; Actions → CI/CD → Run workflow with « Boot the MySQL accessory » starts it (only when no other MySQL uses the volume). Administration through an SSH tunnel to `127.0.0.1:3309` on the VPS; nightly encrypted dumps by the `Database backups` workflow of `rael06/vps`.
- **Settings** are in `config/deploy.yml`; the GitHub environment `production`, restricted to `master`, holds the secrets: `DbPassword`, `JwtSecret`, `MYSQL_ROOT_PASSWORD`, `MYSQL_PASSWORD` and the connection secrets `KAMAL_SSH_KEY`, `VPS_HOST`, `VPS_SSH_PORT`, `VPS_KNOWN_HOSTS`.
- The repository variable `DEPLOY_ENABLED` (`true`/`false`) turns deployments on or off.
- Rollback: `kamal app containers -q` lists the versions kept on the VPS, `kamal rollback <version>` switches back (see `docs/runbooks/workstation.md` in `rael06/vps`).
