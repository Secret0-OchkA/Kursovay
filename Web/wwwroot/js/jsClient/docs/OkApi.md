# MyApiV1.OkApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**checkAuth**](OkApi.md#checkAuth) | **GET** /api/Ok/OkAuth | for check auth
[**checkConnectToApi**](OkApi.md#checkConnectToApi) | **GET** /api/Ok | for check connect



## checkAuth

> checkAuth()

for check auth

### Example

```javascript
import MyApiV1 from 'my_api_v1';
let defaultClient = MyApiV1.ApiClient.instance;
// Configure Bearer access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new MyApiV1.OkApi();
apiInstance.checkAuth((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters

This endpoint does not need any parameter.

### Return type

null (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined


## checkConnectToApi

> checkConnectToApi()

for check connect

### Example

```javascript
import MyApiV1 from 'my_api_v1';
let defaultClient = MyApiV1.ApiClient.instance;
// Configure Bearer access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new MyApiV1.OkApi();
apiInstance.checkConnectToApi((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters

This endpoint does not need any parameter.

### Return type

null (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined

