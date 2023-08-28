const { env } = require('process')

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:38510'

const PROXY_CONFIG = [
  {
    context: [
      '/weatherforecast',
      '/_configuration',
      '/.well-known',
      '/Identity',
      '/connect',
      '/ApplyDatabaseMigrations',
      '/_framework'
    ],
    target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  },
  {
    context: [
      '/api/**'
    ],
    target: 'https://localhost:7009',
    secure: false
  }
]

module.exports = PROXY_CONFIG
