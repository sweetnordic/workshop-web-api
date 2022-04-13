@description('Dein Kürzel - 3-4 Zeichen')
@minLength(3)
@maxLength(4)
param Name string

@description('Describes plan\'s pricing tier and instance size. Check details at https://azure.microsoft.com/en-us/pricing/details/app-service/')
@allowed([
  'B1'
  'S1'
])
param sku string = 'S1'

var Location = resourceGroup().location
var aspName = '${toLower(Name)}-asp'
var webAppAspName = '${toLower(Name)}-aspapi-${uniqueString(resourceGroup().id)}'
var webAppNodeName = '${toLower(Name)}-nodeapi-${uniqueString(resourceGroup().id)}'

resource asp 'Microsoft.Web/serverfarms@2021-03-01' = {
  name: aspName
  location: Location
  sku: {
    name: sku
    capacity: 1
  }
}

resource webAppAsp 'Microsoft.Web/sites@2021-03-01' = {
  name: webAppAspName
  location: Location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    siteConfig: {
      minTlsVersion: '1.2'
      scmMinTlsVersion: '1.2'
      http20Enabled: true
      webSocketsEnabled: true
      remoteDebuggingEnabled: false
      ftpsState: 'Disabled'
    }
    serverFarmId: asp.id
    httpsOnly: true
  }
}

resource webAppNode 'Microsoft.Web/sites@2021-03-01' = {
  name: webAppNodeName
  location: Location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    siteConfig: {
      minTlsVersion: '1.2'
      scmMinTlsVersion: '1.2'
      http20Enabled: true
      webSocketsEnabled: true
      remoteDebuggingEnabled: false
      ftpsState: 'Disabled'
      appSettings: [
        {
          name: 'WEBSITE_NODE_DEFAULT_VERSION'
          value: '12.15.0'
        }
      ]
    }
    serverFarmId: asp.id
    httpsOnly: true
  }
}

resource slotAsp 'Microsoft.Web/sites/slots@2021-03-01' = {
  name: '${webAppAspName}/swap'
  location: Location
  properties: {
    cloningInfo: {
      sourceWebAppId: webAppAsp.id
      sourceWebAppLocation: Location
    }
    serverFarmId: asp.id
  }
}

resource slotNode 'Microsoft.Web/sites/slots@2021-03-01' = {
  name: '${webAppNodeName}/swap'
  location: Location
  properties: {
    cloningInfo: {
      sourceWebAppId: webAppNode.id
      sourceWebAppLocation: Location
    }
    serverFarmId: asp.id
  }
}
