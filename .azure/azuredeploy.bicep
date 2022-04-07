@description('Name des App Service')
@minLength(4)
@maxLength(4)
param Name string = ''

@description('Region der Ressourcen')
param location string = resourceGroup().location

@description('Describes plan\'s pricing tier and instance size. Check details at https://azure.microsoft.com/en-us/pricing/details/app-service/')
@allowed([
  'F1'
  'B1'
  'S1'
  'P1'
])
param sku string = 'B1'

var aspName = '${toLower(Name)}-asp'
var webAppNodeName = '${toLower(Name)}-api-${uniqueString(resourceGroup().id)}'
var webAppAspName = '${toLower(Name)}-api-${uniqueString(resourceGroup().id)}'

resource asp 'Microsoft.Web/serverfarms@2021-03-01' = {
  name: aspName
  location: location
  sku: {
    name: sku
    capacity: 1
    skuCapacity: {
      default: 1
      minimum: 1
      maximum: 1
    }
  }
}

resource webAppAsp 'Microsoft.Web/sites@2021-03-01' = {
  name: webAppAspName
  location: location
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
  location: location
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
  location: location
  properties: {
    cloningInfo: {
      sourceWebAppId: webAppAsp.id
      sourceWebAppLocation: location
    }
  }
}

resource slotNode 'Microsoft.Web/sites/slots@2021-03-01' = {
  name: '${webAppNodeName}/swap'
  location: location
  properties: {
    cloningInfo: {
      sourceWebAppId: webAppNode.id
      sourceWebAppLocation: location
    }
  }
}
